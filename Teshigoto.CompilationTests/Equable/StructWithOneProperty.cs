using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Struct with one property
/// </summary>
[Equable]
internal partial struct StructWithOneProperty : IEquatable<StructWithOneProperty>,
                                                IEqualityOperators<StructWithOneProperty>,
                                                IFactory<StructWithOneProperty, int>
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

    #region IFactory

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <returns>Created value</returns>
    public static StructWithOneProperty Create(int value1)
    {
        return new StructWithOneProperty(value1);
    }

    #endregion // IFactory
}