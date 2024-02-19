using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Struct with one property
/// </summary>
[Equable]
internal partial struct StructWithOneProperty : IEquatable<StructWithOneProperty>
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