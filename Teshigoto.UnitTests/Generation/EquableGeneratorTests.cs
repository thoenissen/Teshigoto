using Teshigoto.Annotation;
using Teshigoto.Generators;
using Teshigoto.UnitTests.Generation.Base;
using Teshigoto.UnitTests.Generation.Resources;

namespace Teshigoto.UnitTests.Generation;

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
    public void ClassWithOneProperty() => AssertGenerationResult(EquableResources.ClassWithOnePropertyGenerated, EquableResources.ClassWithOneProperty);

    /// <summary>
    /// Class with two properties
    /// </summary>
    [TestMethod]
    public void ClassWithTwoProperties() => AssertGenerationResult(EquableResources.ClassWithTwoPropertiesGenerated, EquableResources.ClassWithTwoProperties);

    /// <summary>
    /// Class with three properties
    /// </summary>
    [TestMethod]
    public void ClassWithThreeProperties() => AssertGenerationResult(EquableResources.ClassWithThreePropertiesGenerated, EquableResources.ClassWithThreeProperties);

    /// <summary>
    /// Class with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithIgnoreAttribute() => AssertGenerationResult(EquableResources.ClassWithIgnoreAttributeGenerated, EquableResources.ClassWithIgnoreAttribute);

    /// <summary>
    /// Class with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void ClassWithExplicitIgnoreAttribute() => AssertGenerationResult(EquableResources.ClassWithExplicitIgnoreAttributeGenerated, EquableResources.ClassWithExplicitIgnoreAttribute);

    #endregion // Class

    #region Record class

    /// <summary>
    /// Record class with one property
    /// </summary>
    [TestMethod]
    public void RecordClassWithOneProperty() => AssertGenerationResult(EquableResources.RecordClassWithOnePropertyGenerated, EquableResources.RecordClassWithOneProperty);

    /// <summary>
    /// Record class with two properties
    /// </summary>
    [TestMethod]
    public void RecordClassWithTwoProperties() => AssertGenerationResult(EquableResources.RecordClassWithTwoPropertiesGenerated, EquableResources.RecordClassWithTwoProperties);

    /// <summary>
    /// Record class with three properties
    /// </summary>
    [TestMethod]
    public void RecordClassWithThreeProperties() => AssertGenerationResult(EquableResources.RecordClassWithThreePropertiesGenerated, EquableResources.RecordClassWithThreeProperties);

    /// <summary>
    /// Record class with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithIgnoreAttribute() => AssertGenerationResult(EquableResources.RecordClassWithIgnoreAttributeGenerated, EquableResources.RecordClassWithIgnoreAttribute);

    /// <summary>
    /// Record class with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithExplicitIgnoreAttribute() => AssertGenerationResult(EquableResources.RecordClassWithExplicitIgnoreAttributeGenerated, EquableResources.RecordClassWithExplicitIgnoreAttribute);

    #endregion // Record class

    #region Struct

    /// <summary>
    /// Struct with one property
    /// </summary>
    [TestMethod]
    public void StructWithOneProperty() => AssertGenerationResult(EquableResources.StructWithOnePropertyGenerated, EquableResources.StructWithOneProperty);

    /// <summary>
    /// Struct with two properties
    /// </summary>
    [TestMethod]
    public void StructWithTwoProperties() => AssertGenerationResult(EquableResources.StructWithTwoPropertiesGenerated, EquableResources.StructWithTwoProperties);

    /// <summary>
    /// Struct with three properties
    /// </summary>
    [TestMethod]
    public void StructWithThreeProperties() => AssertGenerationResult(EquableResources.StructWithThreePropertiesGenerated, EquableResources.StructWithThreeProperties);

    /// <summary>
    /// Record struct with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithIgnoreAttribute() => AssertGenerationResult(EquableResources.RecordStructWithIgnoreAttributeGenerated, EquableResources.RecordStructWithIgnoreAttribute);

    /// <summary>
    /// Record struct with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithExplicitIgnoreAttribute() => AssertGenerationResult(EquableResources.RecordStructWithExplicitIgnoreAttributeGenerated, EquableResources.RecordStructWithExplicitIgnoreAttribute);

    #endregion // Struct

    #region Record struct

    /// <summary>
    /// Record struct with one property
    /// </summary>
    [TestMethod]
    public void RecordStructWithOneProperty() => AssertGenerationResult(EquableResources.RecordStructWithOnePropertyGenerated, EquableResources.RecordStructWithOneProperty);

    /// <summary>
    /// Record struct with two properties
    /// </summary>
    [TestMethod]
    public void RecordStructWithTwoProperties() => AssertGenerationResult(EquableResources.RecordStructWithTwoPropertiesGenerated, EquableResources.RecordStructWithTwoProperties);

    /// <summary>
    /// Record struct with three properties
    /// </summary>
    [TestMethod]
    public void RecordStructWithThreeProperties() => AssertGenerationResult(EquableResources.RecordStructWithThreePropertiesGenerated, EquableResources.RecordStructWithThreeProperties);

    /// <summary>
    /// Struct with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithIgnoreAttribute() => AssertGenerationResult(EquableResources.StructWithIgnoreAttributeGenerated, EquableResources.StructWithIgnoreAttribute);

    /// <summary>
    /// Struct with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void StructWithExplicitIgnoreAttribute() => AssertGenerationResult(EquableResources.StructWithExplicitIgnoreAttributeGenerated, EquableResources.StructWithExplicitIgnoreAttribute);

    #endregion // Record struct
}