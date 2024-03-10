using Teshigoto.Annotation;
using Teshigoto.Generators;
using Teshigoto.UnitTests.Generation.Base;
using Teshigoto.UnitTests.Generation.Resources;

namespace Teshigoto.UnitTests.Generation;

/// <summary>
/// Tests for the <see cref="ComparableGenerator"/>-class
/// </summary>
[TestClass]
public class ComparableGeneratorTests : SourceGeneratorTestBase<ComparableGenerator>
{
    #region Class

    /// <summary>
    /// Class with one property
    /// </summary>
    [TestMethod]
    public void ClassWithOneProperty() => AssertGenerationResult(ComparableResources.ClassWithOnePropertyGenerated, ComparableResources.ClassWithOneProperty);

    /// <summary>
    /// Class with two properties
    /// </summary>
    [TestMethod]
    public void ClassWithTwoProperties() => AssertGenerationResult(ComparableResources.ClassWithTwoPropertiesGenerated, ComparableResources.ClassWithTwoProperties);

    /// <summary>
    /// Class with three properties
    /// </summary>
    [TestMethod]
    public void ClassWithThreeProperties() => AssertGenerationResult(ComparableResources.ClassWithThreePropertiesGenerated, ComparableResources.ClassWithThreeProperties);

    /// <summary>
    /// Class with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void ClassWithIgnoreAttribute() => AssertGenerationResult(ComparableResources.ClassWithIgnoreAttributeGenerated, ComparableResources.ClassWithIgnoreAttribute);

    /// <summary>
    /// Class with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void ClassWithExplicitIgnoreAttribute() => AssertGenerationResult(ComparableResources.ClassWithExplicitIgnoreAttributeGenerated, ComparableResources.ClassWithExplicitIgnoreAttribute);

    #endregion // Class

    #region Record class

    /// <summary>
    /// Record class with one property
    /// </summary>
    [TestMethod]
    public void RecordClassWithOneProperty() => AssertGenerationResult(ComparableResources.RecordClassWithOnePropertyGenerated, ComparableResources.RecordClassWithOneProperty);

    /// <summary>
    /// Record class with two properties
    /// </summary>
    [TestMethod]
    public void RecordClassWithTwoProperties() => AssertGenerationResult(ComparableResources.RecordClassWithTwoPropertiesGenerated, ComparableResources.RecordClassWithTwoProperties);

    /// <summary>
    /// Record class with three properties
    /// </summary>
    [TestMethod]
    public void RecordClassWithThreeProperties() => AssertGenerationResult(ComparableResources.RecordClassWithThreePropertiesGenerated, ComparableResources.RecordClassWithThreeProperties);

    /// <summary>
    /// Record class with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithIgnoreAttribute() => AssertGenerationResult(ComparableResources.RecordClassWithIgnoreAttributeGenerated, ComparableResources.RecordClassWithIgnoreAttribute);

    /// <summary>
    /// Record class with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void RecordClassWithExplicitIgnoreAttribute() => AssertGenerationResult(ComparableResources.RecordClassWithExplicitIgnoreAttributeGenerated, ComparableResources.RecordClassWithExplicitIgnoreAttribute);

    #endregion // Record class

    #region Struct

    /// <summary>
    /// Struct with one property
    /// </summary>
    [TestMethod]
    public void StructWithOneProperty() => AssertGenerationResult(ComparableResources.StructWithOnePropertyGenerated, ComparableResources.StructWithOneProperty);

    /// <summary>
    /// Struct with two properties
    /// </summary>
    [TestMethod]
    public void StructWithTwoProperties() => AssertGenerationResult(ComparableResources.StructWithTwoPropertiesGenerated, ComparableResources.StructWithTwoProperties);

    /// <summary>
    /// Struct with three properties
    /// </summary>
    [TestMethod]
    public void StructWithThreeProperties() => AssertGenerationResult(ComparableResources.StructWithThreePropertiesGenerated, ComparableResources.StructWithThreeProperties);

    /// <summary>
    /// Record struct with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithIgnoreAttribute() => AssertGenerationResult(ComparableResources.RecordStructWithIgnoreAttributeGenerated, ComparableResources.RecordStructWithIgnoreAttribute);

    /// <summary>
    /// Record struct with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void RecordStructWithExplicitIgnoreAttribute() => AssertGenerationResult(ComparableResources.RecordStructWithExplicitIgnoreAttributeGenerated, ComparableResources.RecordStructWithExplicitIgnoreAttribute);

    #endregion // Struct

    #region Record struct

    /// <summary>
    /// Record struct with one property
    /// </summary>
    [TestMethod]
    public void RecordStructWithOneProperty() => AssertGenerationResult(ComparableResources.RecordStructWithOnePropertyGenerated, ComparableResources.RecordStructWithOneProperty);

    /// <summary>
    /// Record struct with two properties
    /// </summary>
    [TestMethod]
    public void RecordStructWithTwoProperties() => AssertGenerationResult(ComparableResources.RecordStructWithTwoPropertiesGenerated, ComparableResources.RecordStructWithTwoProperties);

    /// <summary>
    /// Record struct with three properties
    /// </summary>
    [TestMethod]
    public void RecordStructWithThreeProperties() => AssertGenerationResult(ComparableResources.RecordStructWithThreePropertiesGenerated, ComparableResources.RecordStructWithThreeProperties);

    /// <summary>
    /// Struct with <see cref="Annotation.IgnoreAttribute"/>
    /// </summary>
    [TestMethod]
    public void StructWithIgnoreAttribute() => AssertGenerationResult(ComparableResources.StructWithIgnoreAttributeGenerated, ComparableResources.StructWithIgnoreAttribute);

    /// <summary>
    /// Struct with <see cref="Annotation.IgnoreAttribute"/> and <see cref="GeneratorType.Equatable"/>
    /// </summary>
    [TestMethod]
    public void StructWithExplicitIgnoreAttribute() => AssertGenerationResult(ComparableResources.StructWithExplicitIgnoreAttributeGenerated, ComparableResources.StructWithExplicitIgnoreAttribute);

    #endregion // Record struct
}