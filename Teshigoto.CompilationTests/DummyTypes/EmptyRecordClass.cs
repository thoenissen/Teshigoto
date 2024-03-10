using System;

namespace Teshigoto.CompilationTests.DummyTypes;

/// <summary>
/// Empty record class
/// </summary>
public record class EmptyRecordClass : IComparable<EmptyRecordClass>,
                                       IComparable
{
    #region IComparable

    /// <inheritdoc/>
    public int CompareTo(EmptyRecordClass? other)
    {
        return 0;
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        return 0;
    }

    #endregion // IComparable
}