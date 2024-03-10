using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

using Teshigoto.Annotation;
using Teshigoto.Generators.Core;
using Teshigoto.Generators.Core.Extensions;
using Teshigoto.Generators.Data;
using Teshigoto.Generators.Enumerations;
using Teshigoto.Generators.Equable;

namespace Teshigoto.Generators.Comparable;

/// <summary>
/// Base class for generating IComparable implementation
/// </summary>
internal abstract class ComparableGeneratorBase
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
    protected ComparableGeneratorBase(CompilationMetaData metaData)
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
        WriteOpenNamespaceAndTypeDeclaration();
        WriteImplementation();
        WriteCloseNamespaceAndTypeDeclaration();

        return BuildSourceString();
    }

    #endregion // Public methods

    #region Protected methods

    /// <summary>
    /// Writes the compare operators
    /// </summary>
    protected abstract void WriteCompareOperators();

    /// <summary>
    /// Write the <see cref="IComparable.CompareTo(object)"/> method
    /// </summary>
    protected abstract void WriteCompareToObject();

    /// <summary>
    /// Writes the <see cref="IComparable{T}.CompareTo(T)"/> method
    /// </summary>
    protected abstract void WriteCompareToSpecifiedType();

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
                || orderAttribute.ConstructorArguments[0].Values.Any(obj => (GeneratorType?)(int?)obj.Value == GeneratorType.Comparable))
            {
                return new MemberSortingKey(MemberSortingType.Attribute, (long?)orderAttribute.ConstructorArguments[1].Value ?? 0);
            }
        }

        return new MemberSortingKey(MemberSortingType.Location, symbol.Locations.FirstOrDefault(location => location.IsInSource)?.SourceSpan.Start ?? 0);
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
        bool isIgnored = Symbol.IsRecord
                         && symbol.Name == "EqualityContract";

        if (isIgnored == false)
        {
            var ignoreAttribute = symbol.GetAttributes()
                                        .FirstOrDefault(obj => SymbolEqualityComparer.Default.Equals(obj.AttributeClass, MetaData.IgnoreAttribute));

            if (ignoreAttribute != null)
            {
                isIgnored = ignoreAttribute.ConstructorArguments.Length == 0
                            || ignoreAttribute.ConstructorArguments[0].Values.Any(obj => (GeneratorType?)(int?)obj.Value == GeneratorType.Comparable);
            }
        }

        return isIgnored;
    }

    /// <summary>
    /// Writes the summary of the <see cref="IComparable.CompareTo(object)"/> implementation
    /// </summary>
    protected void WriteCompareToObjectSummary()
    {
        WriteLine("/// <inheritdoc/>");
    }

    /// <summary>
    /// Writes the summary of the <see cref="IComparable{T}.CompareTo(T)"/> implementation
    /// </summary>
    protected void WriteCompareToSpecifiedTypeSummary()
    {
        WriteLine("/// <inheritdoc/>");
    }

    /// <summary>
    /// Writes the summary of the less operator
    /// </summary>
    protected void WriteLessOperatorSummary()
    {
        WriteLine("/// <summary>");
        WriteLine($"/// Returns a value that indicates whether a <see cref=\"T:{SymbolName}\" /> value is less than another <see cref=\"T:{SymbolName}\" /> value.");
        WriteLine("/// </summary>");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\" /> is less than <paramref name=\"right\" />; otherwise, false.</returns>");
    }

    /// <summary>
    /// Writes the summary of the less equal operator
    /// </summary>
    protected void WriteLessEqualOperatorSummary()
    {
        WriteLine("/// <summary>");
        WriteLine($"/// Returns a value that indicates whether a <see cref=\"T:{SymbolName}\" /> value is less than or equal to another <see cref=\"T:{SymbolName}\" /> value.");
        WriteLine("/// </summary>");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\" /> is less than or equal to <paramref name=\"right\" />; otherwise, false.</returns>");
    }

    /// <summary>
    /// Writes the summary of the greater operator
    /// </summary>
    protected void WriteGreaterOperatorSummary()
    {
        WriteLine("/// <summary>");
        WriteLine($"/// Returns a value that indicates whether a <see cref=\"T:{SymbolName}\" /> value is greater than another <see cref=\"T:{SymbolName}\" /> value.");
        WriteLine("/// </summary>");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\" /> is greater than <paramref name=\"right\" />; otherwise, false.</returns>");
    }

    /// <summary>
    /// Writes the summary of the greater equal operator
    /// </summary>
    protected void WriteGreaterEqualOperatorSummary()
    {
        WriteLine("/// <summary>");
        WriteLine($"/// Returns a value that indicates whether a <see cref=\"T:{SymbolName}\" /> value is greater than or equal to another <see cref=\"T:{SymbolName}\" /> value.");
        WriteLine("/// </summary>");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\" /> is greater than <paramref name=\"right\" />; otherwise, false.</returns>");
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
    private void WriteOpenNamespaceAndTypeDeclaration()
    {
        foreach (var symbol in SymbolWalker.ContainingNamespaceAndTypes(Symbol)
                                           .Reverse())
        {
            if (symbol is INamespaceSymbol namespaceSymbol)
            {
                WriteNamespace(namespaceSymbol);
                WriteLine();
            }
            else
            {
                WriteTypeDeclaration(symbol);
                WriteLine();
                WriteOpenBracket();
            }
        }

        WriteTypeDeclaration(Symbol);
        WriteLine($" : global::System.IComparable<{SymbolName}>, global::System.IComparable");
        WriteOpenBracket();
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
    private void WriteTypeDeclaration(ISymbol symbol)
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

        Write($"partial {keyword} {typeName}");
    }

    /// <summary>
    /// Write all missing closing brackets
    /// </summary>
    private void WriteCloseNamespaceAndTypeDeclaration()
    {
        while (_writer.Indent > 0)
        {
            _writer.Indent -= 4;
            _writer.Write("}");

            if (_writer.Indent > 0)
            {
                _writer.WriteLine();
            }
        }
    }

    /// <summary>
    /// Write the implementation of <see cref="IComparable"/>, <see cref="IComparable{T}"/>
    /// </summary>
    private void WriteImplementation()
    {
        // operator <
        // operator <=
        // operator >
        // operator >=
        WriteCompareOperators();

        // CompareTo(object? obj)
        WriteCompareToObject();

        // CompareTo({symbol}? other)
        WriteCompareToSpecifiedType();
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