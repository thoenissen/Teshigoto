namespace Teshigoto.Generators.Core;

/// <summary>
/// Escaping utilities
/// </summary>
internal static class Escape
{
    #region Fields

    /// <summary>
    /// Characters of a symbol which should be replaced
    /// </summary>
    private static readonly char[] SymbolCharacters = ['<', '>', ',', ' '];

    #endregion // Fields

    #region Methods

    /// <summary>
    /// Escape a symbol name
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Escaped name of the symbol</returns>
    public static string SymbolName(ITypeSymbol symbol)
    {
        var displayString = symbol.ToDisplayString();
        var stringBuilder = new StringBuilder(displayString.Length);

        foreach (var character in displayString)
        {
            if (SymbolCharacters.Contains(character))
            {
                stringBuilder.Append('_');
            }
            else
            {
                stringBuilder.Append(character);
            }
        }

        return stringBuilder.ToString();
    }

    #endregion // Methods
}