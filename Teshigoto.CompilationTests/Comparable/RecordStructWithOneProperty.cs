using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Record struct with one property
/// </summary>
[Comparable]
internal partial record struct RecordStructWithOneProperty : IFactory<RecordStructWithOneProperty, int>,
                                                             IComparableOperators<RecordStructWithOneProperty>,
                                                             IComparable,
                                                             IComparable<RecordStructWithOneProperty>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="property">Property</param>
    public RecordStructWithOneProperty(int property)
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
    public static RecordStructWithOneProperty Create(int value)
    {
        return new RecordStructWithOneProperty(value);
    }

    #endregion // IOneProperty
}