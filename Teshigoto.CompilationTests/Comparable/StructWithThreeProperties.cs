using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.DummyTypes;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Struct with three properties
/// </summary>
[Comparable]
internal partial struct StructWithThreeProperties : IComparable<StructWithThreeProperties>,
                                                    IComparableOperators<StructWithThreeProperties>,
                                                    IFactory<StructWithThreeProperties, int, string, DummyStruct?>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    /// <param name="propertyThree">Property 3</param>
    public StructWithThreeProperties(int propertyOne, string propertyTwo, DummyStruct? propertyThree)
    {
        PropertyOne = propertyOne;
        PropertyTwo = propertyTwo;
        PropertyThree = propertyThree;
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

    /// <summary>
    /// Property 3
    /// </summary>
    public DummyStruct? PropertyThree { get; }

    #endregion // Properties

    #region IFactory

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <param name="value2">Value 2</param>
    /// <param name="value3">Value 3</param>
    /// <returns>Created value</returns>
    public static StructWithThreeProperties Create(int value1, string value2, DummyStruct? value3)
    {
        return new StructWithThreeProperties(value1, value2, value3);
    }

    #endregion // IFactory
}