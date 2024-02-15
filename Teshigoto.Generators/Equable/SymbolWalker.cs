namespace Teshigoto.Generators.Equable;

/// <summary>
/// Waking through symbols
/// </summary>
internal static class SymbolWalker
{
    #region Methods

    /// <summary>
    /// Get containing namespaces and all types
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Returns the containing namespace and alle types</returns>
    public static IEnumerable<INamespaceOrTypeSymbol> ContainingNamespaceAndTypes(ISymbol symbol)
    {
        while (symbol.ContainingSymbol is INamespaceOrTypeSymbol namespaceOrTypeSymbol)
        {
            yield return namespaceOrTypeSymbol;

            if (namespaceOrTypeSymbol.IsNamespace)
            {
                yield break;
            }

            symbol = namespaceOrTypeSymbol;
        }
    }

    /// <summary>
    /// Get properties and fields of a type
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Returns all properties and field of the given type</returns>
    public static IEnumerable<ISymbol> GetPropertiesAndFields(ITypeSymbol symbol)
    {
        foreach (var member in symbol.GetMembers()
                                     .Where(member => member.IsStatic == false))
        {
            switch (member)
            {
                case IPropertySymbol { IsIndexer: false } propertySymbol:
                    {
                        yield return propertySymbol;
                    }
                    break;

                case IFieldSymbol { CanBeReferencedByName: true } fieldSymbol:
                    {
                        yield return fieldSymbol;
                    }
                    break;
            }
        }
    }

    #endregion // Methods
}