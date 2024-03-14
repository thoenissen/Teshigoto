using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Record struct with two properties
/// </summary>
[Equable]
internal partial record struct RecordStructWithTwoProperties : IEquatable<RecordStructWithTwoProperties>,
                                                               IEqualityOperators<RecordStructWithTwoProperties>,
                                                               IFactory<RecordStructWithTwoProperties, int, string>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    public RecordStructWithTwoProperties(int propertyOne, string propertyTwo)
    {
        PropertyOne = propertyOne;
        PropertyTwo = propertyTwo;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Property 1
    /// </summary>
    public int PropertyOne { get; }

    /// <summary>
    /// Property 2
    /// </summary>
    public string PropertyTwo { get; }

    #endregion // Properties

    #region IFactory

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <param name="value2">Value 2</param>
    /// <returns>Created value</returns>
    public static RecordStructWithTwoProperties Create(int value1, string value2)
    {
        return new RecordStructWithTwoProperties(value1, value2);
    }

    #endregion // IFactory
}