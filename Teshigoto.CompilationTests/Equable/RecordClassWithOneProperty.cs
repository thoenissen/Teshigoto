using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Record class with one property
/// </summary>
[Equable]
internal partial record class RecordClassWithOneProperty : IEquatable<RecordClassWithOneProperty>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="property">Property</param>
    public RecordClassWithOneProperty(int property)
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