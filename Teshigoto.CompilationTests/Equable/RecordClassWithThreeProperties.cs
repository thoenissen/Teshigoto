using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.DummyTypes;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Record class with three properties
/// </summary>
[Equable]
internal partial record class RecordClassWithThreeProperties : IEquatable<RecordClassWithThreeProperties>,
                                                               IEqualityOperators<RecordClassWithThreeProperties>,
                                                               IFactory<RecordClassWithThreeProperties, int, string, DummyRecordClass?>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    /// <param name="propertyThree">Property 3</param>
    public RecordClassWithThreeProperties(int propertyOne, string propertyTwo, DummyRecordClass? propertyThree)
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
    public DummyRecordClass? PropertyThree { get; }

    #endregion // Properties

    #region IFactory

    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <param name="value2">Value 2</param>
    /// <param name="value3">Value 3</param>
    /// <returns>Created value</returns>
    public static RecordClassWithThreeProperties Create(int value1, string value2, DummyRecordClass? value3)
    {
        return new RecordClassWithThreeProperties(value1, value2, value3);
    }

    #endregion // IFactory
}