﻿using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Struct with two properties
/// </summary>
[Equable]
internal partial struct StructWithTwoProperties : IEquatable<StructWithTwoProperties>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    public StructWithTwoProperties(int propertyOne, string propertyTwo)
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
}