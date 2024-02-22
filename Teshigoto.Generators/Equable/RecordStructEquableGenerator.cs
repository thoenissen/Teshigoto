using Teshigoto.Generators.Core;

namespace Teshigoto.Generators.Equable;

/// <summary>
/// Generation of IEquatable implementation for a record struct
/// </summary>
internal class RecordStructEquableGenerator : EquableGeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Meta information</param>
    public RecordStructEquableGenerator(CompilationMetaData metaData)
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
        WriteLine($"public bool Equals({SymbolName} other)");
        WriteOpenBracket();
        Write("return ");
        IncrementIndention("return ".Length);
        WriteMembersEqualityComparison(false);
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
        WriteMembersGetHashCode();
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
        WriteLine($"partial record struct {Symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)} : global::System.IEquatable<{SymbolName}>");
        WriteOpenBracket();
        WriteEquals();
        WriteLine();
        WriteGetHashCode();
        WriteCloseBracket();
    }

    #endregion // EquableGeneratorBase
}