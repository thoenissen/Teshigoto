using Teshigoto.Generators;
using Teshigoto.UnitTests.Base;
using Teshigoto.UnitTests.Resources;

namespace Teshigoto.UnitTests;

/// <summary>
/// Tests for the <see cref="EquableGenerator"/>-class
/// </summary>
[TestClass]
public class EquableGeneratorTests : SourceGeneratorTestBase<EquableGenerator>
{
    /// <summary>
    /// Class with one <see cref="ValueType"/>-property
    /// </summary>
    [TestMethod]
    public void ClassWithOneProperty() => AssertGenerationResult(EquableResources.ClassWithOneProperty, EquableResources.ClassWithOnePropertyGenerated);

    /// <summary>
    /// Record class with one <see cref="ValueType"/>-property
    /// </summary>
    [TestMethod]
    public void RecordClassWithOneProperty() => AssertGenerationResult(EquableResources.RecordClassWithOneProperty, EquableResources.RecordClassWithOnePropertyGenerated);

    /// <summary>
    /// Struct with one <see cref="ValueType"/>-property
    /// </summary>
    [TestMethod]
    public void StructWithOneProperty() => AssertGenerationResult(EquableResources.StructWithOneProperty, EquableResources.StructWithOnePropertyGenerated);

    /// <summary>
    /// Record struct with one <see cref="ValueType"/>-property
    /// </summary>
    [TestMethod]
    public void RecordStructWithOneProperty() => AssertGenerationResult(EquableResources.RecordStructWithOneProperty, EquableResources.RecordStructWithOnePropertyGenerated);
}