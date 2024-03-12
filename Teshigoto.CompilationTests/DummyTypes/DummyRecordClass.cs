using System;

namespace Teshigoto.CompilationTests.DummyTypes;

/// <summary>
/// Dummy record class
/// </summary>
public class DummyRecordClass : IComparable<DummyRecordClass>,
                                IComparable
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    public DummyRecordClass()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value">Value</param>
    public DummyRecordClass(int value)
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
    public int CompareTo(DummyRecordClass? other)
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
        return CompareTo(obj as DummyRecordClass);
    }

    #endregion // IComparable
}