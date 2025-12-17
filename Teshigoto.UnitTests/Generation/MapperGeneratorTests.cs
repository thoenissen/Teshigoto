using Teshigoto.Generators;
using Teshigoto.UnitTests.Generation.Base;
using Teshigoto.UnitTests.Generation.Resources;

namespace Teshigoto.UnitTests.Generation;

/// <summary>
/// Tests for the <see cref="MapperGenerator"/>-class
/// </summary>
[TestClass]
public class MapperGeneratorTests : SourceGeneratorTestBase<MapperGenerator>
{
    /// <summary>
    /// Mapping method
    /// </summary>
    [TestMethod]
    public void Mapping() => AssertGenerationResult(MapperResources.MappingGenerated, MapperResources.Mapping);

    /// <summary>
    /// Extension mapping method
    /// </summary>
    [TestMethod]
    public void MappingExtension() => AssertGenerationResult(MapperResources.MappingExtensionGenerated, MapperResources.MappingExtension);
}