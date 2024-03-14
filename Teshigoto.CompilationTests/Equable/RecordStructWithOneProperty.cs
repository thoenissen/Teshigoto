using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Record struct with one property
/// </summary>
[Equable]
internal partial record struct RecordStructWithOneProperty : IEquatable<RecordStructWithOneProperty>,
                                                             IEqualityOperators<RecordStructWithOneProperty>,
                                                             IFactory<RecordStructWithOneProperty, int>
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

    #region IFactory

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <returns>Created value</returns>
    public static RecordStructWithOneProperty Create(int value1)
    {
        return new RecordStructWithOneProperty(value1);
    }

    #endregion // IFactory
}