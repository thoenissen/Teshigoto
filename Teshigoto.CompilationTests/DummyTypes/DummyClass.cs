using System;

namespace Teshigoto.CompilationTests.DummyTypes;

/// <summary>
/// Dummy class
/// </summary>
public class DummyClass : IComparable<DummyClass>,
                          IComparable
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    public DummyClass()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value">Value</param>
    public DummyClass(int value)
    {
        Value = value;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Value
    /// </summary>
    public int Value { get; }

    #endregion // Properties

    #region IComparable

    /// <inheritdoc/>
    public int CompareTo(DummyClass? other)
    {
        if (other == null)
        {
            return 1;
        }

        return Value.CompareTo(other.Value);
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        return CompareTo(obj as DummyClass);
    }

    #endregion // IComparable
}