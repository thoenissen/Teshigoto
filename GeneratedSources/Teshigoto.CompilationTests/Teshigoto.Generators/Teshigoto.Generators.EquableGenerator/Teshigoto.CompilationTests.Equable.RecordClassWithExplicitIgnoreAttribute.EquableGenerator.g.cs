﻿// <auto-generated>
//     This code was generated by Teshigoto.Generators.
//     Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

#nullable enable

namespace Teshigoto.CompilationTests.Equable;

internal partial record class RecordClassWithExplicitIgnoreAttribute : global::System.IEquatable<global::Teshigoto.CompilationTests.Equable.RecordClassWithExplicitIgnoreAttribute>
{
    /// <inheritdoc />
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public virtual bool Equals(global::Teshigoto.CompilationTests.Equable.RecordClassWithExplicitIgnoreAttribute? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return global::System.Collections.Generic.EqualityComparer<global::System.Type>.Default.Equals(this.EqualityContract, other.EqualityContract)
               && global::System.Collections.Generic.EqualityComparer<global::System.Int32>.Default.Equals(this._field, other._field)
               && global::System.Collections.Generic.EqualityComparer<global::System.Int32>.Default.Equals(this.Property, other.Property);
    }

    /// <inheritdoc />
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Teshigoto.Generators", "1.0.0.0")]
    public override int GetHashCode()
    {
        var hash = new global::System.HashCode();

        hash.Add(this.EqualityContract);
        hash.Add(this._field);
        hash.Add(this.Property);

        return hash.ToHashCode();
    }
}