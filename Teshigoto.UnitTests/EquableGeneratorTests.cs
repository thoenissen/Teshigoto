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
    /// Class with one reference type property
    /// </summary>
    [TestMethod]
    public void ClassWithOneProperty() => AssertGenerationResult(EquableResources.ClassWithOneProperty, EquableResources.ClassWithOnePropertyGenerated);
}