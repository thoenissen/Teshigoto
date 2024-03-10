using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Struct with one property
/// </summary>
[Comparable]
internal partial struct StructWithOneProperty : IComparable<StructWithOneProperty>
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
}