using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Class with one property
/// </summary>
[Equable]
internal partial class ClassWithOneProperty : IEquatable<ClassWithOneProperty>
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
}