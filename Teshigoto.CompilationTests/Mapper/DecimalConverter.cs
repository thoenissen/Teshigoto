namespace Teshigoto.CompilationTests.Mapper;

/// <summary>
/// Mapping converter
/// </summary>
public class DecimalConverter
{
    /// <summary>
    /// Convert value
    /// </summary>
    /// <param name="value">Value</param>
    /// <returns>Converted value</returns>
    public static float Convert(decimal value)
    {
        return (float)value;
    }
}