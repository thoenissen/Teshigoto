using Teshigoto.Generators.Core;
using Teshigoto.Generators.Core.Extensions;

namespace Teshigoto.Generators.Equable;

/// <summary>
/// Generation of IEquatable implementation for a record class
/// </summary>
internal class RecordClassEquableGenerator : EquableGeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Meta information</param>
    public RecordClassEquableGenerator(CompilationMetaData metaData)
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
        // Equals({symbol}? other)
        WriteEqualsSpecifiedType();
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

        bool addAndOperator;
        var baseTypeName = Symbol.BaseType?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

        if (baseTypeName == "object")
        {
            Write("return ");

            addAndOperator = false;
        }
        else
        {
            Write($"return base.Equals(other as {baseTypeName})");

            addAndOperator = true;
        }

        IncrementIndention("return ".Length);

        WriteMembersEqualityComparison(addAndOperator);
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

        if (Symbol.BaseType?.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat) != "object")
        {
            WriteLine("hash.Add(base.GetHashCode());");
        }

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
        WriteLine($"partial record class {Symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)} : global::System.IEquatable<{SymbolName}>");
        WriteOpenBracket();
        WriteEquals();
        WriteLine();
        WriteGetHashCode();
        WriteCloseBracket();
    }

    #endregion // EquableGeneratorBase
}