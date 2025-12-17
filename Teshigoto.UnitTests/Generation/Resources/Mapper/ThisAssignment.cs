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

public partial class MapperDestination
{
    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial MapperDestination(MapperSource source);

    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public partial void Assign(MapperSource source);

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