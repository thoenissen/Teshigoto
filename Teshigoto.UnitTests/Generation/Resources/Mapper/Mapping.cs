using Teshigoto.Annotation;

namespace Teshigoto.UnitTests;

public class MapperSource
{
    public int Value { get; set; }
    public int IntValue { get; set; }
    public long LongValue { get; set; }
    public decimal DecimalValue { get; set; }
}

public class MapperDestination
{
    public int Value { get; set; }
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

[GenerateMapper]
public partial class Mapper
{
    [MapMember("Value", "Value")]
    [MapMember("IntValue", "LongValue")]
    [MapMember("LongValue", "IntValue", Cast = true)]
    [MapMember("DecimalValue", "FloatValue", Converter = typeof(DecimalConverter))]
    public static partial void Map(MapperSource source, MapperDestination destination);
}