using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Struct with one property
/// </summary>
[Comparable]
internal partial struct StructWithOneProperty : IOneValueFactory<StructWithOneProperty, int>,
                                                IComparableOperators<StructWithOneProperty>,
                                                IComparable,
                                                IComparable<StructWithOneProperty>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="property">Property</param>
    public StructWithOneProperty(int property)
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
    public static StructWithOneProperty Create(int value)
    {
        return new StructWithOneProperty(value);
    }

    #endregion // IOneProperty
}