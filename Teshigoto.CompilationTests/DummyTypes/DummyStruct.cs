using System;

namespace Teshigoto.CompilationTests.DummyTypes;

/// <summary>
/// Dummy class
/// </summary>
public struct DummyStruct : IComparable<DummyStruct>,
                            IComparable
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    public DummyStruct()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="value">Value</param>
    public DummyStruct(int value)
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
    public int CompareTo(DummyStruct other)
    {
        return Value.CompareTo(other.Value);
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is not DummyStruct)
        {
            throw new InvalidOperationException();
        }

        return CompareTo((DummyStruct)obj);
    }

    #endregion // IComparable
}