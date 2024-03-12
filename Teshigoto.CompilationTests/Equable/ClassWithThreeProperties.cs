using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.DummyTypes;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Class with three properties
/// </summary>
[Equable]
internal partial class ClassWithThreeProperties : IEquatable<ClassWithThreeProperties>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    /// <param name="propertyThree">Property 3</param>
    public ClassWithThreeProperties(int propertyOne, string propertyTwo, DummyClass? propertyThree)
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
    public DummyClass? PropertyThree { get; }

    #endregion // Properties
}