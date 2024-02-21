﻿// <auto-generated>
//     This code was generated by Teshigoto.Generators.
//     Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

#nullable enable

namespace Teshigoto.CompilationTests.Equable;

internal partial class ClassWithExplicitIgnoreAttribute : global::System.IEquatable<global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute>
{
    /// <summary>
    /// Returns a value that indicates whether the values of two <see cref="global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute"/> objects are equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, false.</returns>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public static bool operator ==(global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute? left, global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute? right)
    {
        if (left is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    /// <summary>
    /// Returns a value that indicates whether the values of two <see cref="global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute"/> objects have different values.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.</returns>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public static bool operator !=(global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute? left, global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute? right)
    {
        if (left is null)
        {
            return true;
        }

        return left.Equals(right) == false;
    }

    /// <inheritdoc />
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public override bool Equals(object? obj)
    {
        return Equals(obj as global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute);
    }

    /// <inheritdoc />
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public virtual bool Equals(global::Teshigoto.CompilationTests.Equable.ClassWithExplicitIgnoreAttribute? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return other.GetType() == this.GetType()
               && global::System.Collections.Generic.EqualityComparer<global::System.Int32>.Default.Equals(this._field, other._field)
               && global::System.Collections.Generic.EqualityComparer<global::System.Int32>.Default.Equals(this.Property, other.Property);
    }

    /// <inheritdoc />
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public override int GetHashCode()
    {
        var hash = new global::System.HashCode();

        hash.Add(this._field);
        hash.Add(this.Property);

        return hash.ToHashCode();
    }
}