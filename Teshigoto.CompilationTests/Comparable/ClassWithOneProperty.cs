using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Class with one property
/// </summary>
[Comparable]
internal partial class ClassWithOneProperty : IComparable<ClassWithOneProperty>, IComparable
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