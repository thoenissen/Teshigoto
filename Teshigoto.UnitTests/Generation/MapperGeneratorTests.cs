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
    /// Simple member mapping by name
    /// </summary>
    [TestMethod]
    public void SimpleMapping() => AssertGenerationResult(MapperResources.SimpleMappingGenerated, MapperResources.SimpleMapping);
}