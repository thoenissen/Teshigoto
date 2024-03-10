using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Class with one property
/// </summary>
[Comparable]
internal partial class ClassWithOneProperty : IOneValueFactory<ClassWithOneProperty, int>,
                                              IComparableOperators<ClassWithOneProperty>,
                                              IComparable,
                                              IComparable<ClassWithOneProperty>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="property">Property</param>
    public ClassWithOneProperty(int property)
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
    public static ClassWithOneProperty Create(int value)
    {
        return new ClassWithOneProperty(value);
    }

    #endregion // IOneProperty
}