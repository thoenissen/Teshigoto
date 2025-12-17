using Teshigoto.Generators;
using Teshigoto.UnitTests.Generation.Base;
using Teshigoto.UnitTests.Generation.Resources;

namespace Teshigoto.UnitTests.Generation;

/// <summary>
/// Tests for the <see cref="ProxyGenerator"/>-class
/// </summary>
[TestClass]
public class ProxyGeneratorTests : SourceGeneratorTestBase<ProxyGenerator>
{
    /// <summary>
    /// Test class generation
    /// </summary>
    [TestMethod]
    public void Class()
    {
        AssertGenerationResult(ProxyResources.ClassGenerated, ProxyResources.Class);
    }
}