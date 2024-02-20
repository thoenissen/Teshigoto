using System;

using Teshigoto.Annotation;
using Teshigoto.CompilationTests.DummyTypes;

namespace Teshigoto.CompilationTests.Equable;

/// <summary>
/// Record struct with three properties
/// </summary>
[Equable]
internal partial record struct RecordStructWithThreeProperties : IEquatable<RecordStructWithThreeProperties>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyOne">Property 1</param>
    /// <param name="propertyTwo">Property 2</param>
    /// <param name="propertyThree">Property 3</param>
    public RecordStructWithThreeProperties(int propertyOne, string propertyTwo, EmptyRecordStruct? propertyThree)
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
    public EmptyRecordStruct? PropertyThree { get; }

    #endregion // Properties
}