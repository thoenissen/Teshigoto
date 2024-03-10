﻿// <auto-generated>
//     This code was generated by Teshigoto.Generators.
//     Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

#nullable enable

namespace Teshigoto.CompilationTests.Comparable;

partial record RecordClassWithIgnoreAttribute : global::System.IComparable<global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute>, global::System.IComparable
{
    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute" /> value is less than another <see cref="T:global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is less than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator <(global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? left, global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? right)
    {
        return global::System.Collections.Generic.Comparer<global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute>.Default.Compare(left, right) < 0;
    }

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute" /> value is less than or equal to another <see cref="T:global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, false.</returns>
    public static bool operator <=(global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? left, global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? right)
    {
        return global::System.Collections.Generic.Comparer<global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute>.Default.Compare(left, right) <= 0;
    }

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute" /> value is greater than another <see cref="T:global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator >(global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? left, global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? right)
    {
        return global::System.Collections.Generic.Comparer<global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute>.Default.Compare(left, right) > 0;
    }

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute" /> value is greater than or equal to another <see cref="T:global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator >=(global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? left, global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? right)
    {
        return global::System.Collections.Generic.Comparer<global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute>.Default.Compare(left, right) >= 0;
    }

    /// <inheritdoc/>
    public int CompareTo(object? obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (ReferenceEquals(this, obj))
        {
            return 0;
        }

        if (obj is global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute other)
        {
            return CompareTo(other);
        }

        throw new global::System.ArgumentException($"Object must be of type {nameof(global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute)}");
    }

    /// <inheritdoc/>
    public int CompareTo(global::Teshigoto.CompilationTests.Comparable.RecordClassWithIgnoreAttribute? other)
    {
        if (other is null)
        {
            return 1;
        }

        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        var comparison = global::System.Collections.Generic.Comparer<int>.Default.Compare(_field, other._field);

        if (comparison == 0)
        {
            comparison = global::System.Collections.Generic.Comparer<int>.Default.Compare(Property, other.Property);
        }

        return comparison;
    }
}