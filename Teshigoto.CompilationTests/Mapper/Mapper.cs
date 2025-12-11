using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Mapper;

/// <summary>
/// Mapper
/// </summary>
public partial class Mapper
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
    public static partial void Map(MapperSource source, MapperDestination destination);

    /// <summary>
    /// Maps data from the specified source to the specified destination.
    /// </summary>
    /// <param name="source">The source object containing the data to be mapped.</param>
    /// <param name="destination">The destination object that receives the mapped data.</param>
    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void Instance(MapperSource source, MapperDestination destination);

    /// <summary>
    /// Maps data from the specified source to the specified destination.
    /// </summary>
    /// <param name="source">The source object containing the data to be mapped.</param>
    /// <param name="destination">The destination object that receives the mapped data.</param>
    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void RefSource(ref MapperSource source, MapperDestination destination);

    /// <summary>
    /// Maps data from the specified source to the specified destination.
    /// </summary>
    /// <param name="source">The source object containing the data to be mapped.</param>
    /// <param name="destination">The destination object that receives the mapped data.</param>
    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void InSource(in MapperSource source, MapperDestination destination);

    /// <summary>
    /// Maps data from the specified source to the specified destination.
    /// </summary>
    /// <param name="source">The source object containing the data to be mapped.</param>
    /// <param name="destination">The destination object that receives the mapped data.</param>
    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void RefReadonlySource(ref readonly MapperSource source, MapperDestination destination);

    /// <summary>
    /// Maps data from the specified source to the specified destination.
    /// </summary>
    /// <param name="source">The source object containing the data to be mapped.</param>
    /// <param name="destination">The destination object that receives the mapped data.</param>
    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void RefDestination(MapperSource source, ref MapperDestination destination);
}