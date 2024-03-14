﻿using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Class with two properties
/// </summary>
[Equable]
internal partial class ClassWithTwoProperties : IEquatable<ClassWithTwoProperties>,
                                                IEqualityOperators<ClassWithTwoProperties>,
                                                IFactory<ClassWithTwoProperties, int, string>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    public ClassWithTwoProperties(int propertyOne, string propertyTwo)
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
    public static ClassWithTwoProperties Create(int value1, string value2)
    {
        return new ClassWithTwoProperties(value1, value2);
    }

    #endregion // IFactory
}