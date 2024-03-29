﻿// <auto-generated>
//     This code was generated by Teshigoto.Generators.
//     Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

#nullable enable

namespace Teshigoto.CompilationTests.Comparable;

partial struct StructWithOneProperty : global::System.IComparable<global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty>, global::System.IComparable
{
    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty" /> value is less than another <see cref="T:global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is less than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator <(global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty left, global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty right)
    {
        return left.CompareTo(right) < 0;
    }

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty" /> value is less than or equal to another <see cref="T:global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, false.</returns>
    public static bool operator <=(global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty left, global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty right)
    {
        return left.CompareTo(right) <= 0;
    }

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty" /> value is greater than another <see cref="T:global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator >(global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty left, global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty right)
    {
        return left.CompareTo(right) > 0;
    }

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty" /> value is greater than or equal to another <see cref="T:global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator >=(global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty left, global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty right)
    {
        return left.CompareTo(right) >= 0;
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (obj is global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty other)
        {
            return CompareTo(other);
        }

        throw new global::System.ArgumentException($"Object must be of type {nameof(global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty)}");
    }

    /// <inheritdoc/>
    public int CompareTo(global::Teshigoto.CompilationTests.Comparable.StructWithOneProperty other)
    {
        var comparison = global::System.Collections.Generic.Comparer<int>.Default.Compare(Property, other.Property);

        return comparison;
    }
}