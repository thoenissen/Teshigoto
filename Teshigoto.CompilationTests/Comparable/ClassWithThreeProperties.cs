using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.DummyTypes;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Class with three properties
/// </summary>
[Comparable]
internal partial class ClassWithThreeProperties : IComparable<ClassWithThreeProperties>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    /// <param name="propertyThree">Property 3</param>
    public ClassWithThreeProperties(int propertyOne, string propertyTwo, EmptyClass? propertyThree)
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
    public EmptyClass? PropertyThree { get; }

    #endregion // Properties
}