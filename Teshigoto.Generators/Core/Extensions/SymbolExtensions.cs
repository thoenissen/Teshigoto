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

    #endregion // Methods
}