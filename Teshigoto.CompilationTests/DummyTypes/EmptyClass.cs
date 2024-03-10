using System;

namespace Teshigoto.CompilationTests.DummyTypes;

/// <summary>
/// Empty class
/// </summary>
public class EmptyClass : IComparable<EmptyClass>,
                          IComparable
{
    #region IComparable

    /// <inheritdoc/>
    public int CompareTo(EmptyClass? other)
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