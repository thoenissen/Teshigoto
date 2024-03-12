using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Record class with one property
/// </summary>
[Comparable]
internal partial record class RecordClassWithOneProperty : IFactory<RecordClassWithOneProperty, int>,
                                                           IComparableOperators<RecordClassWithOneProperty>,
                                                           IComparable,
                                                           IComparable<RecordClassWithOneProperty>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="property">Property</param>
    public RecordClassWithOneProperty(int property)
    {
        Property = property;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Property
    /// </summary>
    public int Property { get; }

    #endregion // Properties

    #region IOneProperty

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value">Value</param>
    /// <returns>Created value</returns>
    public static RecordClassWithOneProperty Create(int value)
    {
        return new RecordClassWithOneProperty(value);
    }

    #endregion // IOneProperty
}