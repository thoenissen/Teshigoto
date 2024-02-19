﻿using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

using Teshigoto.Generators.Core;
using Teshigoto.Generators.Core.Extensions;

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
        foreach (var member in SymbolWalker.GetPropertiesAndFields(Symbol))
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
                        WriteEqualityComparison(propertySymbol, propertySymbol.Type);
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
        var symbolName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.WithMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier));
        var symbolType = type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

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