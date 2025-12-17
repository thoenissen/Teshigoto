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

public static partial class MapperExtensions
{
    [GenerateMapper]
    [MapMember("Value1", "Value1")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public static partial void Extension(this MapperSource source, MapperDestination destination);
}