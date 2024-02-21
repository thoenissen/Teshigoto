using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Struct with <see cref="IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/> argument
/// </summary>
[Equable]
internal partial struct StructWithExplicitIgnoreAttribute
{
    #region Fields

    /// <summary>
    /// Field
    /// </summary>
    private int _field;

    /// <summary>
    /// Ignored field
    /// </summary>
    [Ignore([GeneratorType.Equatable])]
    private int _ignoredField;

    #endregion // Fields

    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="field">Field</param>
    /// <param name="ignoredField">Ignored field</param>
    /// <param name="property">Property</param>
    /// <param name="ignoredProperty">Ignored property</param>
    public StructWithExplicitIgnoreAttribute(int field, int ignoredField, int property, int ignoredProperty)
    {
        _field = field;
        _ignoredField = ignoredField;
        Property = property;
        IgnoredProperty = ignoredProperty;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Property
    /// </summary>
    public int Property { get; set; }

    /// <summary>
    /// Ignored property
    /// </summary>
    [Ignore([GeneratorType.Equatable])]
    public int IgnoredProperty { get; set; }

    #endregion // Properties
}