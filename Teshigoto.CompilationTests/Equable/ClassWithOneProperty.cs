using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Class with one property
/// </summary>
[Equable]
internal partial class ClassWithOneProperty : IEquatable<ClassWithOneProperty>,
                                              IEqualityOperators<ClassWithOneProperty>,
                                              IFactory<ClassWithOneProperty, int>
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

    #region IFactory

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <returns>Created value</returns>
    public static ClassWithOneProperty Create(int value1)
    {
        return new ClassWithOneProperty(value1);
    }

    #endregion // IFactory
}