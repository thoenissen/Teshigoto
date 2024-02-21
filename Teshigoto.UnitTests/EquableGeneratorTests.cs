using Teshigoto.Annotation;
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
    #region Class

    /// <summary>
    /// Class with one property
    /// </summary>
    [TestMethod]
    public void ClassWithOneProperty() => AssertGenerationResult(EquableResources.ClassWithOneProperty, EquableResources.ClassWithOnePropertyGenerated);

    /// <summary>
    /// Class with two properties
    /// </summary>
    [TestMethod]
    public void ClassWithTwoProperties() => AssertGenerationResult(EquableResources.ClassWithTwoProperties, EquableResources.ClassWithTwoPropertiesGenerated);

    /// <summary>
    /// Class with three properties
    /// </summary>
    [TestMethod]
    public void ClassWithThreeProperties() => AssertGenerationResult(EquableResources.ClassWithThreeProperties, EquableResources.ClassWithThreePropertiesGenerated);

    /// <summary>
    /// Class with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithIgnoreAttribute() => AssertGenerationResult(EquableResources.ClassWithIgnoreAttribute, EquableResources.ClassWithIgnoreAttributeGenerated);

    /// <summary>
    /// Class with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void ClassWithExplicitIgnoreAttribute() => AssertGenerationResult(EquableResources.ClassWithExplicitIgnoreAttribute, EquableResources.ClassWithExplicitIgnoreAttributeGenerated);

    #endregion // Class

    #region Record class

    /// <summary>
    /// Record class with one property
    /// </summary>
    [TestMethod]
    public void RecordClassWithOneProperty() => AssertGenerationResult(EquableResources.RecordClassWithOneProperty, EquableResources.RecordClassWithOnePropertyGenerated);

    /// <summary>
    /// Record class with two properties
    /// </summary>
    [TestMethod]
    public void RecordClassWithTwoProperties() => AssertGenerationResult(EquableResources.RecordClassWithTwoProperties, EquableResources.RecordClassWithTwoPropertiesGenerated);

    /// <summary>
    /// Record class with three properties
    /// </summary>
    [TestMethod]
    public void RecordClassWithThreeProperties() => AssertGenerationResult(EquableResources.RecordClassWithThreeProperties, EquableResources.RecordClassWithThreePropertiesGenerated);

    /// <summary>
    /// Record class with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithIgnoreAttribute() => AssertGenerationResult(EquableResources.RecordClassWithIgnoreAttribute, EquableResources.RecordClassWithIgnoreAttributeGenerated);

    /// <summary>
    /// Record class with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithExplicitIgnoreAttribute() => AssertGenerationResult(EquableResources.RecordClassWithExplicitIgnoreAttribute, EquableResources.RecordClassWithExplicitIgnoreAttributeGenerated);

    #endregion // Record class

    #region Struct

    /// <summary>
    /// Struct with one property
    /// </summary>
    [TestMethod]
    public void StructWithOneProperty() => AssertGenerationResult(EquableResources.StructWithOneProperty, EquableResources.StructWithOnePropertyGenerated);

    /// <summary>
    /// Struct with two properties
    /// </summary>
    [TestMethod]
    public void StructWithTwoProperties() => AssertGenerationResult(EquableResources.StructWithTwoProperties, EquableResources.StructWithTwoPropertiesGenerated);

    /// <summary>
    /// Struct with three properties
    /// </summary>
    [TestMethod]
    public void StructWithThreeProperties() => AssertGenerationResult(EquableResources.StructWithThreeProperties, EquableResources.StructWithThreePropertiesGenerated);

    /// <summary>
    /// Record struct with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithIgnoreAttribute() => AssertGenerationResult(EquableResources.RecordStructWithIgnoreAttribute, EquableResources.RecordStructWithIgnoreAttributeGenerated);

    /// <summary>
    /// Record struct with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithExplicitIgnoreAttribute() => AssertGenerationResult(EquableResources.RecordStructWithExplicitIgnoreAttribute, EquableResources.RecordStructWithExplicitIgnoreAttributeGenerated);

    #endregion // Struct

    #region Record struct

    /// <summary>
    /// Record struct with one property
    /// </summary>
    [TestMethod]
    public void RecordStructWithOneProperty() => AssertGenerationResult(EquableResources.RecordStructWithOneProperty, EquableResources.RecordStructWithOnePropertyGenerated);

    /// <summary>
    /// Record struct with two properties
    /// </summary>
    [TestMethod]
    public void RecordStructWithTwoProperties() => AssertGenerationResult(EquableResources.RecordStructWithTwoProperties, EquableResources.RecordStructWithTwoPropertiesGenerated);

    /// <summary>
    /// Record struct with three properties
    /// </summary>
    [TestMethod]
    public void RecordStructWithThreeProperties() => AssertGenerationResult(EquableResources.RecordStructWithThreeProperties, EquableResources.RecordStructWithThreePropertiesGenerated);

    /// <summary>
    /// Struct with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithIgnoreAttribute() => AssertGenerationResult(EquableResources.StructWithIgnoreAttribute, EquableResources.StructWithIgnoreAttributeGenerated);

    /// <summary>
    /// Struct with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void StructWithExplicitIgnoreAttribute() => AssertGenerationResult(EquableResources.StructWithExplicitIgnoreAttribute, EquableResources.StructWithExplicitIgnoreAttributeGenerated);

    #endregion // Record struct
}