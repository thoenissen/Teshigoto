﻿using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Comparable;

/// <summary>
/// Record class with two properties
/// </summary>
[Comparable]
internal partial record class RecordClassWithTwoProperties : IComparable<RecordClassWithTwoProperties>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    public RecordClassWithTwoProperties(int propertyOne, string propertyTwo)
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