using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Mapper;

/// <summary>
/// Destination
/// </summary>
public partial class MapperDestination
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="source">The source object containing the data to be mapped.</param>
    [GenerateMapper]
    [MapMember(nameof(MapperSource.Value1), nameof(Value1))]
    [MapMember(nameof(MapperSource.IntValue), nameof(LongValue))]
    [MapMember(nameof(MapperSource.LongValue), nameof(IntValue), Cast = true)]
    [MapMember(nameof(MapperSource.DecimalValue), nameof(FloatValue), Converter = typeof(DecimalConverter))]
    public partial MapperDestination(MapperSource source);

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Value
    /// </summary>
    public int Value1 { get; set; }

    /// <summary>
    /// Value
    /// </summary>
    public int Value2 { get; set; }

    /// <summary>
    /// Long value
    /// </summary>
    public long LongValue { get; set; }

    /// <summary>
    /// Int value
    /// </summary>
    public int IntValue { get; set; }

    /// <summary>
    /// Float value
    /// </summary>
    public float FloatValue { get; set; }

    #endregion // Properties

    #region Methods

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="source">The source object containing the data to be mapped.</param>
    [GenerateMapper]
    [MapMember(nameof(MapperSource.Value1), nameof(Value1))]
    [MapMember(nameof(MapperSource.IntValue), nameof(LongValue))]
    [MapMember(nameof(MapperSource.LongValue), nameof(IntValue), Cast = true)]
    [MapMember(nameof(MapperSource.DecimalValue), nameof(FloatValue), Converter = typeof(DecimalConverter))]
    public partial void Assign(MapperSource source);

    #endregion // Methods
}