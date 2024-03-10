using Teshigoto.Generators.Core;
using Teshigoto.Generators.Core.Extensions;

namespace Teshigoto.Generators.Comparable;

/// <summary>
/// Generator to implement <see cref="IComparable"/> for reference types
/// </summary>
internal class ClassComparableGenerator : ComparableGeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Meta information</param>
    public ClassComparableGenerator(CompilationMetaData metaData)
        : base(metaData)
    {
    }

    #endregion // Constructor

    #region ComparableGeneratorBase

    /// <inheritdoc/>
    protected override void WriteCompareOperators()
    {
        // operator <
        WriteLessOperatorSummary();
        WriteLine($"public static bool operator <({SymbolName}? left, {SymbolName}? right)");
        WriteOpenBracket();
        WriteLine($"return global::System.Collections.Generic.Comparer<{SymbolName}>.Default.Compare(left, right) < 0;");
        WriteCloseBracket();
        WriteLine();

        // operator <=
        WriteLessEqualOperatorSummary();
        WriteLine($"public static bool operator <=({SymbolName}? left, {SymbolName}? right)");
        WriteOpenBracket();
        WriteLine($"return global::System.Collections.Generic.Comparer<{SymbolName}>.Default.Compare(left, right) <= 0;");
        WriteCloseBracket();
        WriteLine();

        // operator >
        WriteGreaterOperatorSummary();
        WriteLine($"public static bool operator >({SymbolName}? left, {SymbolName}? right)");
        WriteOpenBracket();
        WriteLine($"return global::System.Collections.Generic.Comparer<{SymbolName}>.Default.Compare(left, right) > 0;");
        WriteCloseBracket();
        WriteLine();

        // operator >=
        WriteGreaterEqualOperatorSummary();
        WriteLine($"public static bool operator >=({SymbolName}? left, {SymbolName}? right)");
        WriteOpenBracket();
        WriteLine($"return global::System.Collections.Generic.Comparer<{SymbolName}>.Default.Compare(left, right) >= 0;");
        WriteCloseBracket();
        WriteLine();
    }

    /// <inheritdoc/>
    protected override void WriteCompareToObject()
    {
        WriteCompareToObjectSummary();
        WriteLine("public int CompareTo(object? obj)");
        WriteOpenBracket();
        WriteLine("if (obj is null)");
        WriteOpenBracket();
        WriteLine("return 1;");
        WriteCloseBracket();
        WriteLine();
        WriteLine("if (ReferenceEquals(this, obj))");
        WriteOpenBracket();
        WriteLine("return 0;");
        WriteCloseBracket();
        WriteLine();
        WriteLine($"if (obj is {SymbolName} other)");
        WriteOpenBracket();
        WriteLine("return CompareTo(other);");
        WriteCloseBracket();
        WriteLine();
        WriteLine($"throw new global::System.ArgumentException($\"Object must be of type {{nameof({SymbolName})}}\");");
        WriteCloseBracket();
        WriteLine();
    }

    /// <inheritdoc/>
    protected override void WriteCompareToSpecifiedType()
    {
        WriteCompareToSpecifiedTypeSummary();
        WriteLine($"public int CompareTo({SymbolName}? other)");
        WriteOpenBracket();
        WriteLine("if (other is null)");
        WriteOpenBracket();
        WriteLine("return 1;");
        WriteCloseBracket();
        WriteLine();
        WriteLine("if (ReferenceEquals(this, other))");
        WriteOpenBracket();
        WriteLine("return 0;");
        WriteCloseBracket();
        WriteLine();
        WriteLine($"var comparison = global::System.Collections.Generic.Comparer<{SymbolMembers[0].GetFieldOrPropertyType().ToFullQualifiedDisplayString()}>.Default.Compare({SymbolMembers[0].Name}, other.{SymbolMembers[0].Name});");

        foreach (var member in SymbolMembers.Skip(1))
        {
            WriteLine();
            WriteLine("if (comparison == 0)");
            WriteOpenBracket();
            WriteLine($"comparison = global::System.Collections.Generic.Comparer<{member.GetFieldOrPropertyType().ToFullQualifiedDisplayString()}>.Default.Compare({member.Name}, other.{member.Name});");
        }

        for (int i = 1; i < SymbolMembers.Count; i++)
        {
            WriteCloseBracket();
        }

        WriteLine();
        WriteLine("return comparison;");
        WriteCloseBracket();
    }

    #endregion // ComparableGeneratorBase
}