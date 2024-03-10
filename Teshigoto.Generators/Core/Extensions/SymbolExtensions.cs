namespace Teshigoto.Generators.Core.Extensions;

/// <summary>
/// Extension method for <see cref="ISymbol"/>
/// </summary>
internal static class SymbolExtensions
{
    #region Methods

    /// <summary>
    /// Get the full qualified display string of a symbol (<see cref="SymbolDisplayFormat.FullyQualifiedFormat"/>)
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Full qualified display string</returns>
    public static string ToFullQualifiedDisplayString(this ISymbol symbol)
    {
        return symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
    }

    /// <summary>
    /// Return the type of the field or property
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Type of the field or property</returns>
    public static ITypeSymbol GetFieldOrPropertyType(this ISymbol symbol)
    {
        return symbol switch
               {
                   IFieldSymbol fieldSymbol => fieldSymbol.Type,
                   IPropertySymbol propertySymbol => propertySymbol.Type,
                   _ => null
               };
    }

    #endregion // Methods
}