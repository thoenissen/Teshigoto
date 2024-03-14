using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Record class with one property
/// </summary>
[Equable]
internal partial record class RecordClassWithOneProperty : IEquatable<RecordClassWithOneProperty>,
                                                           IEqualityOperators<RecordClassWithOneProperty>,
                                                           IFactory<RecordClassWithOneProperty, int>
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

    #region IFactory

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <returns>Created value</returns>
    public static RecordClassWithOneProperty Create(int value1)
    {
        return new RecordClassWithOneProperty(value1);
    }

    #endregion // IFactory
}