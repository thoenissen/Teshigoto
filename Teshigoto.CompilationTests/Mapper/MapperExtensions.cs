using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Mapper;

/// <summary>
/// Mapper extension methods
/// </summary>
internal static partial class MapperExtensions
{
    /// <summary>
    /// Maps data from the specified source to the specified destination.
    /// </summary>
    /// <param name="source">The source object containing the data to be mapped.</param>
    /// <param name="destination">The destination object that receives the mapped data.</param>
    [GenerateMapper]
    [MapMember("Value", "Value")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public static partial void Map(this MapperSource source, MapperDestination destination);
}