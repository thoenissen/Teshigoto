using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Record class with one property
/// </summary>
[Comparable]
internal partial record class RecordClassWithOneProperty : IComparable<RecordClassWithOneProperty>
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