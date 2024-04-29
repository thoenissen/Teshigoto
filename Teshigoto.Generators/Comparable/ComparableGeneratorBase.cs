using Teshigoto.Annotation;
using Teshigoto.Generators.Base;
using Teshigoto.Generators.Core;
using Teshigoto.Generators.Equable;

namespace Teshigoto.Generators.Comparable;

/// <summary>
/// Base class for generating IComparable implementation
/// </summary>
internal abstract class ComparableGeneratorBase : GeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Meta information</param>
    protected ComparableGeneratorBase(CompilationMetaData metaData)
        : base(metaData)
    {
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Fields of the current symbol
    /// </summary>
    protected List<IFieldSymbol> SymbolFields { get; private set; }

    /// <summary>
    /// Members of the current symbol
    /// </summary>
    /// <remarks>The list is already sorted.</remarks>
    protected List<ISymbol> SymbolMembers { get; private set; }

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

        using (WriteGroup(WriteOpenNamespaceAndTypeDeclaration, WriteCloseNamespaceAndParentType))
        {
            WriteImplementation();
        }

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
    /// Check if the symbol is ignored
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Is the symbol ignored?</returns>
    protected bool IsSymbolIgnored(ISymbol symbol)
    {
        var isIgnored = Symbol.IsRecord
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
        WriteXmlDocSummary($"Returns a value that indicates whether a <see cref=\"T:{SymbolName}\" /> value is less than another <see cref=\"T:{SymbolName}\" /> value.");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\" /> is less than <paramref name=\"right\" />; otherwise, false.</returns>");
    }

    /// <summary>
    /// Writes the summary of the less equal operator
    /// </summary>
    protected void WriteLessEqualOperatorSummary()
    {
        WriteXmlDocSummary($"Returns a value that indicates whether a <see cref=\"T:{SymbolName}\" /> value is less than or equal to another <see cref=\"T:{SymbolName}\" /> value.");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\" /> is less than or equal to <paramref name=\"right\" />; otherwise, false.</returns>");
    }

    /// <summary>
    /// Writes the summary of the greater operator
    /// </summary>
    protected void WriteGreaterOperatorSummary()
    {
        WriteXmlDocSummary($"Returns a value that indicates whether a <see cref=\"T:{SymbolName}\" /> value is greater than another <see cref=\"T:{SymbolName}\" /> value.");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\" /> is greater than <paramref name=\"right\" />; otherwise, false.</returns>");
    }

    /// <summary>
    /// Writes the summary of the greater equal operator
    /// </summary>
    protected void WriteGreaterEqualOperatorSummary()
    {
        WriteXmlDocSummary($"Returns a value that indicates whether a <see cref=\"T:{SymbolName}\" /> value is greater than or equal to another <see cref=\"T:{SymbolName}\" /> value.");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\" /> is greater than <paramref name=\"right\" />; otherwise, false.</returns>");
    }

    #endregion // Protected methods

    #region Private methods

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

    #endregion // Private methods

    #endregion // Methods

    #region GeneratorBase

    /// <inheritdoc/>
    protected override void Initialize(ITypeSymbol symbol)
    {
        base.Initialize(symbol);

        SymbolFields = Symbol.GetMembers()
                             .OfType<IFieldSymbol>()
                             .ToList();
        SymbolMembers = SymbolWalker.GetPropertiesAndFields(Symbol)
                                    .Where(obj => IsSymbolIgnored(obj) == false)
                                    .OrderBy(GetMemberSortKey)
                                    .ToList();
    }

    #endregion // GeneratorBase
}