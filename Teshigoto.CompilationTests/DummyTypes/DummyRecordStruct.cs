using System;

namespace Teshigoto.CompilationTests.DummyTypes;

/// <summary>
/// Dummy class
/// </summary>
public record struct DummyRecordStruct : IComparable<DummyRecordStruct>,
                                         IComparable
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    public DummyRecordStruct()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value">Value</param>
    public DummyRecordStruct(int value)
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
    public int CompareTo(DummyRecordStruct other)
    {
        return Value.CompareTo(other.Value);
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is not DummyRecordStruct)
        {
            throw new InvalidOperationException();
        }

        return CompareTo((DummyRecordStruct)obj);
    }

    #endregion // IComparable
}