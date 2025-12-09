namespace Teshigoto.Generators.Mapper;

/// <summary>
/// Mapping information
/// </summary>
internal struct MappingInformation
{
    /// <summary>
    /// Source name
    /// </summary>
    public string SourceName;

    /// <summary>
    /// Converter
    /// </summary>
    public INamedTypeSymbol Converter;

    /// <summary>
    /// Cast
    /// </summary>
    public bool Cast;
}