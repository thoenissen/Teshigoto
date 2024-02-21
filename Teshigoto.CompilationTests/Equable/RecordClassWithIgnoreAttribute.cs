using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Record class with <see cref="IgnoreAttribute"/>
/// </summary>
[Equable]
internal partial record class RecordClassWithIgnoreAttribute
{
    #region Fields

    /// <summary>
    /// Field
    /// </summary>
    private int _field;

    /// <summary>
    /// Ignored field
    /// </summary>
    [Ignore]
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
    public RecordClassWithIgnoreAttribute(int field, int ignoredField, int property, int ignoredProperty)
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
    [Ignore]
    public int IgnoredProperty { get; set; }

    #endregion // Properties
}