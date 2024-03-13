using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Record struct with <see cref="IgnoreAttribute"/>
/// </summary>
[Comparable]
internal partial record struct RecordStructWithIgnoreAttribute : IComparable<RecordStructWithIgnoreAttribute>,
                                                                 IComparableOperators<RecordStructWithIgnoreAttribute>,
                                                                 IFactory<RecordStructWithIgnoreAttribute, int, int, int, int>
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
    public RecordStructWithIgnoreAttribute(int field, int ignoredField, int property, int ignoredProperty)
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

    #region IFactory

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <param name="value2">Value 2</param>
    /// <param name="value3">Value 3</param>
    /// <param name="value4">Value 4</param>
    /// <returns>Created value</returns>
    public static RecordStructWithIgnoreAttribute Create(int value1, int value2, int value3, int value4)
    {
        return new RecordStructWithIgnoreAttribute(value1, value2, value3, value4);
    }

    #endregion // IFactory
}