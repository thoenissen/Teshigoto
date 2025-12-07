using Teshigoto.Annotation;

namespace Teshigoto.UnitTests;

public class MapperSource
{
    public int Value { get; set; }
}

public class MapperDestination
{
    public int Value { get; set; }
}

[GenerateMapper]
public partial class Mapper
{
    public static partial void Map(in MapperSource source, in MapperDestination destination);
}