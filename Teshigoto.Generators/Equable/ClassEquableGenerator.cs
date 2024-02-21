using Teshigoto.Generators.Core;
using Teshigoto.Generators.Core.Extensions;

namespace Teshigoto.Generators.Equable;

/// <summary>
/// Generation of IEquatable implementation for a class
/// </summary>
internal class ClassEquableGenerator : EquableGeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Meta information</param>
    public ClassEquableGenerator(CompilationMetaData metaData)
        : base(metaData)
    {
    }

    #endregion // Constructor

    #region Methods

    /// <summary>
    /// Writes the equals methods and operators
    /// </summary>
    private void WriteEquals()
    {
        // operator ==
        WriteEqualsOperator();

        // operator !=
        WriteNotEqualsOperator();

        // Equals(object? obj)
        WriteEqualsObject();

        // Equals({symbol}? other)
        WriteEqualsSpecifiedType();
    }

    /// <summary>
    /// Writes the equals operator (operator ==)
    /// </summary>
    private void WriteEqualsOperator()
    {
        WriteLine("/// <summary>");
        WriteLine($"/// Returns a value that indicates whether the values of two <see cref=\"{SymbolName}\"/> objects are equal.");
        WriteLine("/// </summary>");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if the <paramref name=\"left\"/> and <paramref name=\"right\"/> parameters have the same value; otherwise, false.</returns>");
        WriteGeneratedCodeAttribute();
        WriteLine($"public static bool operator ==({SymbolName}? left, {SymbolName}? right)");
        WriteOpenBracket();
        WriteLine("if (left is null)");
        WriteOpenBracket();
        WriteLine("return false;");
        WriteCloseBracket();
        WriteLine();
        WriteLine("return left.Equals(right);");
        WriteCloseBracket();
        WriteLine();
    }

    /// <summary>
    /// Writes the not equals operator (operator !=)
    /// </summary>
    private void WriteNotEqualsOperator()
    {
        WriteLine("/// <summary>");
        WriteLine($"/// Returns a value that indicates whether the values of two <see cref=\"{SymbolName}\"/> objects have different values.");
        WriteLine("/// </summary>");
        WriteLine("/// <param name=\"left\">The first value to compare.</param>");
        WriteLine("/// <param name=\"right\">The second value to compare.</param>");
        WriteLine("/// <returns>true if <paramref name=\"left\"/> and <paramref name=\"right\"/> are not equal; otherwise, false.</returns>");
        WriteGeneratedCodeAttribute();
        WriteLine($"public static bool operator !=({SymbolName}? left, {SymbolName}? right)");
        WriteOpenBracket();
        WriteLine("if (left is null)");
        WriteOpenBracket();
        WriteLine("return true;");
        WriteCloseBracket();
        WriteLine();
        WriteLine("return left.Equals(right) == false;");
        WriteCloseBracket();
        WriteLine();
    }

    /// <summary>
    /// Writes the Equals(object? obj) method
    /// </summary>
    private void WriteEqualsObject()
    {
        WriteLine("/// <inheritdoc />");
        WriteGeneratedCodeAttribute();
        WriteLine("public override bool Equals(object? obj)");
        WriteOpenBracket();
        WriteLine($"return Equals(obj as {SymbolName});");
        WriteCloseBracket();
        WriteLine();
    }

    /// <summary>
    /// Writes the Equals({symbol}? other) method
    /// </summary>
    private void WriteEqualsSpecifiedType()
    {
        WriteLine("/// <inheritdoc />");
        WriteGeneratedCodeAttribute();

        if (Symbol.IsSealed)
        {
            WriteLine($"public bool Equals({SymbolName}? other)");
        }
        else
        {
            WriteLine($"public virtual bool Equals({SymbolName}? other)");
        }

        WriteOpenBracket();
        WriteLine("if (other is null)");
        WriteOpenBracket();
        WriteLine("return false;");
        WriteCloseBracket();
        WriteLine();
        WriteLine("if (ReferenceEquals(this, other))");
        WriteOpenBracket();
        WriteLine("return true;");
        WriteCloseBracket();
        WriteLine();

        var baseTypeName = Symbol.BaseType?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

        if (baseTypeName == "object")
        {
            if (Symbol.IsSealed)
            {
                Write($"return other is {SymbolName}");
            }
            else
            {
                Write("return other.GetType() == this.GetType()");
            }
        }
        else
        {
            Write($"return base.Equals(other as {baseTypeName})");
        }

        IncrementIndention("return ".Length);

        WriteMembersEqualityComparison(true);
        WriteLine(";");

        DecrementIndention("return ".Length);

        WriteCloseBracket();
    }

    /// <summary>
    /// Writes the GetHashCode method
    /// </summary>
    private void WriteGetHashCode()
    {
        WriteLine("/// <inheritdoc />");
        WriteGeneratedCodeAttribute();
        WriteLine("public override int GetHashCode()");
        WriteOpenBracket();
        WriteLine("var hash = new global::System.HashCode();");
        WriteLine();

        foreach (var member in SymbolWalker.GetPropertiesAndFields(Symbol))
        {
            if (IsSymbolIgnored(member))
            {
                continue;
            }

            switch (member)
            {
                case IPropertySymbol propertySymbol:
                    {
                        WriteLine($"hash.Add(this.{propertySymbol.ToFullQualifiedDisplayString()});");
                    }
                    break;

                case IFieldSymbol fieldSymbol:
                    {
                        WriteLine($"hash.Add(this.{fieldSymbol.ToFullQualifiedDisplayString()});");
                    }
                    break;

                default:
                    throw new NotSupportedException($"Member of type {member.GetType()} not supported");
            }
        }

        WriteLine();
        WriteLine("return hash.ToHashCode();");
        WriteCloseBracket();
    }

    #endregion // Methods

    #region EquableGeneratorBase

    /// <inheritdoc/>
    protected override void WriteImplementation()
    {
        WriteDeclaredAccessibility(Symbol.DeclaredAccessibility);
        WriteLine($"partial class {Symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)} : global::System.IEquatable<{SymbolName}>");
        WriteOpenBracket();
        WriteEquals();
        WriteLine();
        WriteGetHashCode();
        WriteCloseBracket();
    }

    #endregion // EquableGeneratorBase
}