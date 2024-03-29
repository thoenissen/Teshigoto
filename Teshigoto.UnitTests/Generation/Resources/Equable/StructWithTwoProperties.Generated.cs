﻿// <auto-generated>
//     This code was generated by Teshigoto.Generators.
//     Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

#nullable enable

namespace Teshigoto.CompilationTests.Equable;

internal partial struct StructWithTwoProperties : global::System.IEquatable<global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties>
{
    /// <summary>
    /// Returns a value that indicates whether the values of two <see cref="global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties"/> objects are equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, false.</returns>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public static bool operator ==(global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties left, global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Returns a value that indicates whether the values of two <see cref="global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties"/> objects have different values.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.</returns>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public static bool operator !=(global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties left, global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties right)
    {
        return left.Equals(right) == false;
    }

    /// <inheritdoc />
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public override bool Equals(object? obj)
    {
        return obj is global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties other
               && Equals(other);
    }

    /// <inheritdoc />
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public bool Equals(global::Teshigoto.CompilationTests.Equable.StructWithTwoProperties other)
    {
        return global::System.Collections.Generic.EqualityComparer<global::System.Int32>.Default.Equals(this.PropertyOne, other.PropertyOne)
               && global::System.Collections.Generic.EqualityComparer<global::System.String>.Default.Equals(this.PropertyTwo, other.PropertyTwo);
    }

    /// <inheritdoc />
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public override int GetHashCode()
    {
        var hash = new global::System.HashCode();

        hash.Add(this.PropertyOne);
        hash.Add(this.PropertyTwo);

        return hash.ToHashCode();
    }
}