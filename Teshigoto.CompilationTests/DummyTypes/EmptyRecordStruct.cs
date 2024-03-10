using System;

namespace Teshigoto.CompilationTests.DummyTypes;

/// <summary>
/// Empty record struct
/// </summary>
public record struct EmptyRecordStruct : IComparable<EmptyRecordStruct>,
                                         IComparable
{
    #region IComparable

    /// <inheritdoc/>
    public int CompareTo(EmptyRecordStruct other)
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