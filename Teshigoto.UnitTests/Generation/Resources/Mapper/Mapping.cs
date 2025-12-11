using Teshigoto.Annotation;

namespace Teshigoto.UnitTests;

public class MapperSource
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
    public int IntValue { get; set; }
    public long LongValue { get; set; }
    public decimal DecimalValue { get; set; }
}

public class MapperDestination
{
    public int Value1 { get; set; }
    public int Value2 { get; set; }
    public long LongValue { get; set; }
    public int IntValue { get; set; }
    public float FloatValue { get; set; }
}

public class DecimalConverter
{
    public static float Convert(decimal value)
    {
        return (float)value;
    }
}

public partial class Mapper
{
    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public static partial void Static(MapperSource source, MapperDestination destination);

    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void Instance(MapperSource source, MapperDestination destination);

    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void RefSource(ref MapperSource source, MapperDestination destination);

    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void InSource(in MapperSource source, MapperDestination destination);

    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void RefReadonlySource(ref readonly MapperSource source, MapperDestination destination);

    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void RefDestination(MapperSource source, ref MapperDestination destination);
}