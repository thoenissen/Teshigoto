using Teshigoto.Annotation;
using Teshigoto.Generators.Base;
using Teshigoto.Generators.Core;
using Teshigoto.Generators.Core.Extensions;

namespace Teshigoto.Generators.Equable;

/// <summary>
/// Base class for generating IEquatable implementation
/// </summary>
internal abstract class EquableGeneratorBase : GeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Meta information</param>
    protected EquableGeneratorBase(CompilationMetaData metaData)
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

        using (WriteGroup(WriteOpenNamespaceAndParentType, WriteCloseNamespaceAndParentType))
        {
            WriteImplementation();
        }

        return BuildSourceString();
    }

    #endregion // Public methods

    #region Protected methods

    /// <summary>
    /// Write the implementation of <see cref="object.GetHashCode"/>, <see cref="object.Equals(object)"/> and <see cref="IEquatable{T}.Equals(T)"/>
    /// </summary>
    protected abstract void WriteImplementation();

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

    /// <summary>
    /// Write the equality comparison of each member
    /// </summary>
    /// <param name="addAndOperator">Should the &amp;&amp; operator added on the first member?</param>
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
    /// Check if the property relevant for the implementation
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Is the property relevant for the implementation?</returns>
    private bool IsPropertyRelevant(IPropertySymbol symbol)
    {
        var isRelevant = symbol.GetMethod != null
                         && SymbolFields.Exists(field => SymbolEqualityComparer.Default.Equals(field.AssociatedSymbol, symbol));

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

        WriteLine();
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

    #endregion // Private methods

    #endregion // Methods
}