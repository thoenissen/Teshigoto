using System;

namespace Teshigoto.CompilationTests.DummyTypes;

/// <summary>
/// Empty struct
/// </summary>
public struct EmptyStruct : IComparable<EmptyStruct>,
                            IComparable
{
    #region IComparable

    /// <inheritdoc/>
    public int CompareTo(EmptyStruct other)
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