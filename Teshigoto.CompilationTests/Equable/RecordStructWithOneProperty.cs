using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Record struct with one property
/// </summary>
[Equable]
internal partial record struct RecordStructWithOneProperty : IEquatable<RecordStructWithOneProperty>
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
}