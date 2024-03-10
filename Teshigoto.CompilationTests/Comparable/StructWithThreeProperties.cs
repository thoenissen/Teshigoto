using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.DummyTypes;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Struct with three properties
/// </summary>
[Comparable]
internal partial struct StructWithThreeProperties : IComparable<StructWithThreeProperties>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    /// <param name="propertyThree">Property 3</param>
    public StructWithThreeProperties(int propertyOne, string propertyTwo, EmptyStruct? propertyThree)
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
    public EmptyStruct? PropertyThree { get; }

    #endregion // Properties
}