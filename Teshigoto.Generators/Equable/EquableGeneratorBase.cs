using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

using Teshigoto.Annotation;
using Teshigoto.Generators.Core;
using Teshigoto.Generators.Core.Extensions;
using Teshigoto.Generators.Data;
using Teshigoto.Generators.Enumerations;

namespace Teshigoto.Generators.Equable;

/// <summary>
/// Base class for generating IEquatable implementation
/// </summary>
internal abstract class EquableGeneratorBase
{
    #region Fields

    /// <summary>
    /// Size of the indention
    /// </summary>
    private const int IndentionSize = 4;

    /// <summary>
    /// <see cref="GeneratedCodeAttribute"/> for the generated code
    /// </summary>
    private static readonly string GenerateCodeAttribute = $"[global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"{Assembly.GetExecutingAssembly().GetName().Name}\", \"{Assembly.GetExecutingAssembly().GetName().Version}\")]";

    /// <summary>
    /// Buffer for the generated code
    /// </summary>
    private StringWriter _buffer;

    /// <summary>
    /// Writer for the generated code
    /// </summary>
    private IndentedTextWriter _writer;

    #endregion // Fields

    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Meta information</param>
    protected EquableGeneratorBase(CompilationMetaData metaData)
    {
        MetaData = metaData;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Meta information about the current compilation
    /// </summary>
    protected CompilationMetaData MetaData { get; }

    /// <summary>
    /// Symbol to generate the implementation for
    /// </summary>
    protected ITypeSymbol Symbol { get; private set; }

    /// <summary>
    /// Fields of the current symbol
    /// </summary>
    protected List<IFieldSymbol> SymbolFields { get; private set; }

    /// <summary>
    /// Members of the current symbol
    /// </summary>
    /// <remarks>The list is already sorted.</remarks>
    protected List<ISymbol> SymbolMembers { get; private set; }

    /// <summary>
    /// Fully qualified name of the symbol
    /// </summary>
    protected string SymbolName { get; private set; }

    #endregion // Properties

    #region Methods

    #region Public methods

    /// <summary>
    /// Generate the implementation for the given symbol
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Generated source code</returns>
    public string Generate(ITypeSymbol symbol)
    {
        Initialize(symbol);

        WriteOpenNamespaceAndParentType();

        WriteImplementation();

        WriteCloseNamespaceAndParentType();

        return BuildSourceString();
    }

    #endregion // Public methods

    #region Protected methods

    /// <summary>
    /// Write the implementation of <see cref="object.GetHashCode"/>, <see cref="object.Equals(object)"/> and <see cref="IEquatable{T}.Equals(T)"/>
    /// </summary>
    protected abstract void WriteImplementation();

    /// <summary>
    /// Write an opening bracket (<c>'{'</c>) and increase the indention
    /// </summary>
    protected void WriteOpenBracket()
    {
        WriteLine("{");

        _writer.Indent += IndentionSize;
    }

    /// <summary>
    /// Write a closing bracket (<c>'}'</c>) and decrease the indention
    /// </summary>
    protected void WriteCloseBracket()
    {
        _writer.Indent -= IndentionSize;

        WriteLine("}");
    }

    /// <summary>
    /// Write the <see cref="GeneratedCodeAttribute"/>
    /// </summary>
    protected void WriteGeneratedCodeAttribute()
    {
        WriteLine(GenerateCodeAttribute);
    }

    /// <summary>
    /// Write a characters (without line break) to the generated code
    /// </summary>
    /// <param name="characters">Characters</param>
    protected void Write(string characters)
    {
        _writer.Write(characters);
    }

    /// <summary>
    /// Writes an empty line to the generated code
    /// </summary>
    protected void WriteLine()
    {
        var currentIndent = _writer.Indent;

        _writer.Indent = 0;
        _writer.WriteLine();
        _writer.Indent = currentIndent;
    }

    /// <summary>
    /// Writes a line to the generated code
    /// </summary>
    /// <param name="line">Line</param>
    protected void WriteLine(string line)
    {
        _writer.WriteLine(line);
    }

    /// <summary>
    /// Decrements the indention
    /// </summary>
    /// <param name="characters">Characters to decrement</param>
    protected void DecrementIndention(int? characters = null)
    {
        _writer.Indent -= characters ?? IndentionSize;
    }

    /// <summary>
    /// Increments the indention
    /// </summary>
    /// <param name="characters">Characters to increment</param>
    protected void IncrementIndention(int? characters = null)
    {
        _writer.Indent += characters ?? IndentionSize;
    }

    /// <summary>
    /// Write the equality comparison of each member
    /// </summary>
    /// <param name="addAndOperator">Should the && operator added on the first member?</param>
    protected void WriteMembersEqualityComparison(bool addAndOperator)
    {
        foreach (var member in SymbolMembers)
        {
            if (addAndOperator)
            {
                WriteLine();
                Write("&& ");
            }

            addAndOperator = true;

            switch (member)
            {
                case IPropertySymbol propertySymbol:
                    {
                        if (IsPropertyRelevant(propertySymbol))
                        {
                            WriteEqualityComparison(propertySymbol, propertySymbol.Type);
                        }
                    }
                    break;

                case IFieldSymbol fieldSymbol:
                    {
                        WriteEqualityComparison(fieldSymbol, fieldSymbol.Type);
                    }
                    break;

                default:
                    throw new NotSupportedException($"Member of type {member.GetType()} not supported");
            }
        }
    }

    /// <summary>
    /// Create the sorting key for the member
    /// </summary>
    /// <param name="symbol">Member symbol</param>
    /// <returns>Sorting key</returns>
    private MemberSortingKey GetMemberSortKey(ISymbol symbol)
    {
        foreach (var orderAttribute in symbol.GetAttributes()
                                             .Where(obj => SymbolEqualityComparer.Default.Equals(obj.AttributeClass, MetaData.OrderAttribute)))
        {
            if (orderAttribute.ConstructorArguments.Length == 0
                || orderAttribute.ConstructorArguments[0].Values.Any(obj => (GeneratorType?)(int?)obj.Value == GeneratorType.Equatable))
            {
                return new MemberSortingKey(MemberSortingType.Attribute, (long?)orderAttribute.ConstructorArguments[1].Value ?? 0);
            }
        }

        return new MemberSortingKey(MemberSortingType.Location, symbol.Locations.FirstOrDefault(location => location.IsInSource)?.SourceSpan.Start ?? 0);
    }

    /// <summary>
    /// Check if the property relevant for the implementation
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Is the property relevant for the implementation?</returns>
    private bool IsPropertyRelevant(IPropertySymbol symbol)
    {
        var isRelevant = symbol.GetMethod != null
                         && SymbolFields.Any(field => SymbolEqualityComparer.Default.Equals(field.AssociatedSymbol, symbol));

        if (isRelevant == false)
        {
            var includeAttribute = symbol.GetAttributes()
                                         .FirstOrDefault(obj => SymbolEqualityComparer.Default.Equals(obj.AttributeClass, MetaData.IncludeAttribute));

            if (includeAttribute != null)
            {
                isRelevant = includeAttribute.ConstructorArguments.Length == 0
                             || includeAttribute.ConstructorArguments[0].Values.Any(obj => (GeneratorType?)(int?)obj.Value == GeneratorType.Equatable);
            }
        }

        return isRelevant;
    }

    /// <summary>
    /// Write the call of add method for each member
    /// </summary>
    protected void WriteMembersGetHashCode()
    {
        foreach (var member in SymbolMembers)
        {
            switch (member)
            {
                case IPropertySymbol propertySymbol:
                    {
                        if (IsPropertyRelevant(propertySymbol))
                        {
                            WriteLine($"hash.Add(this.{propertySymbol.ToFullQualifiedDisplayString()});");
                        }
                    }
                    break;

                case IFieldSymbol fieldSymbol:
                    {
                        WriteLine($"hash.Add(this.{fieldSymbol.ToFullQualifiedDisplayString()});");
                    }
                    break;

                default:
                    throw new NotSupportedException($"Member of type {member.GetType()} not supported");
            }
        }
    }

    /// <summary>
    /// Writes the declared accessibility
    /// </summary>
    /// <param name="accessibility">Accessibility</param>
    protected void WriteDeclaredAccessibility(Accessibility accessibility)
    {
        var accessibilityString = accessibility switch
                                  {
                                      Accessibility.Public => "public",
                                      Accessibility.Internal => "internal",
                                      Accessibility.Protected => "protected",
                                      Accessibility.ProtectedAndInternal => "private protected",
                                      Accessibility.ProtectedOrInternal => "protected internal",
                                      Accessibility.Private => "private",
                                      _ => throw new ArgumentOutOfRangeException($"Accessibility {accessibility} not supported")
                                  };

        Write(accessibilityString);
        Write(" ");
    }

    /// <summary>
    /// Check if the symbol is ignored
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Is the symbol ignored?</returns>
    protected bool IsSymbolIgnored(ISymbol symbol)
    {
        var ignoreAttribute = symbol.GetAttributes()
                                    .FirstOrDefault(obj => SymbolEqualityComparer.Default.Equals(obj.AttributeClass, MetaData.IgnoreAttribute));

        if (ignoreAttribute != null)
        {
            return ignoreAttribute.ConstructorArguments.Length == 0
                   || ignoreAttribute.ConstructorArguments[0].Values.Any(obj => (GeneratorType?)(int?)obj.Value == GeneratorType.Equatable);
        }

        return false;
    }

    #endregion // Protected methods

    #region Private methods

    /// <summary>
    /// Initialize the generator
    /// </summary>
    /// <param name="symbol">Symbol</param>
    private void Initialize(ITypeSymbol symbol)
    {
        Symbol = symbol;
        SymbolName = Symbol.ToFullQualifiedDisplayString();
        SymbolFields = Symbol.GetMembers()
                             .OfType<IFieldSymbol>()
                             .ToList();
        SymbolMembers = SymbolWalker.GetPropertiesAndFields(Symbol)
                                    .Where(obj => IsSymbolIgnored(obj) == false)
                                    .OrderBy(GetMemberSortKey)
                                    .ToList();

        _buffer = new StringWriter(new StringBuilder(4096));
        _writer = new IndentedTextWriter(_buffer, " ");

        WriteLine("// <auto-generated>");
        WriteLine("//     This code was generated by Teshigoto.Generators.");
        WriteLine($"//     Version: {Assembly.GetExecutingAssembly().GetName().Version}");
        WriteLine("//");
        WriteLine("//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.");
        WriteLine("// </auto-generated>");
        WriteLine();
        WriteLine("#nullable enable");
        WriteLine();
    }

    /// <summary>
    /// Write namespace and parent types
    /// </summary>
    private void WriteOpenNamespaceAndParentType()
    {
        foreach (var symbol in SymbolWalker.ContainingNamespaceAndTypes(Symbol)
                                           .Reverse())
        {
            if (symbol is INamespaceSymbol namespaceSymbol)
            {
                WriteNamespace(namespaceSymbol);
            }
            else
            {
                WriteParentSymbol(symbol);
            }
        }

        _writer.WriteLine();
    }

    /// <summary>
    /// Write the file-scoped namespace
    /// </summary>
    /// <param name="symbol">Symbol of the namespace</param>
    private void WriteNamespace(INamespaceSymbol symbol)
    {
        var namespaceName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithGlobalNamespaceStyle(SymbolDisplayGlobalNamespaceStyle.Omitted));

        if (string.IsNullOrEmpty(namespaceName) == false)
        {
            WriteLine($"namespace {namespaceName};");
        }
    }

    /// <summary>
    /// Write a parent type
    /// </summary>
    /// <param name="symbol">Symbol of the parent type</param>
    private void WriteParentSymbol(ISymbol symbol)
    {
        var typeDeclarationSyntax = symbol.DeclaringSyntaxReferences
                                          .Select(x => x.GetSyntax())
                                          .OfType<TypeDeclarationSyntax>()
                                          .First();

        var keyword = typeDeclarationSyntax.Kind() switch
                      {
                          SyntaxKind.ClassDeclaration => "class",
                          SyntaxKind.RecordDeclaration => "record",
                          SyntaxKind.RecordStructDeclaration => "record struct",
                          SyntaxKind.StructDeclaration => "struct",
                          var unknownKind => throw new ArgumentOutOfRangeException($"Syntax kind {unknownKind} not supported")
                      };

        var typeName = symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);

        WriteLine($"partial {keyword} {typeName}");
        WriteOpenBracket();
    }

    /// <summary>
    /// Write all missing closing brackets
    /// </summary>
    private void WriteCloseNamespaceAndParentType()
    {
        while (_writer.Indent > 0)
        {
            _writer.Indent--;
            _writer.Write("}");

            if (_writer.Indent > 0)
            {
                _writer.WriteLine();
            }
        }
    }

    /// <summary>
    /// Write equality comparison for a member
    /// </summary>
    /// <param name="symbol">Symbol of the member</param>
    /// <param name="type">Type of the member</param>
    private void WriteEqualityComparison(ISymbol symbol, ITypeSymbol type)
    {
        var symbolName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        var symbolType = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier));

        Write($"global::System.Collections.Generic.EqualityComparer<{symbolType}>.Default.Equals(this.{symbolName}, other.{symbolName})");
    }

    /// <summary>
    /// Build the source string
    /// </summary>
    /// <returns>Source string</returns>
    private string BuildSourceString()
    {
        var builder = _buffer.GetStringBuilder();

        for (var i = builder.Length - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(builder[i]))
            {
                builder.Length = i;
            }
            else
            {
                break;
            }
        }

        return builder.ToString();
    }

    #endregion // Private methods

    #endregion // Methods
}