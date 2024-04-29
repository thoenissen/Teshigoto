using System.Collections.Immutable;
using System.Reflection;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using Teshigoto.UnitTests.Generation.Resources;

namespace Teshigoto.UnitTests.Generation.Base;

/// <summary>
/// Base class for tests of source generators
/// </summary>
/// <typeparam name="TGenerator">Type of the generator to be tested</typeparam>
public class SourceGeneratorTestBase<TGenerator>
    where TGenerator : IIncrementalGenerator, new()
{
    #region Methods

    #region Protected methods

    /// <summary>
    /// Asserts the generation result
    /// </summary>
    /// <param name="expectedGeneratedSource">Generated source</param>
    /// <param name="sources">Sources</param>
    protected void AssertGenerationResult(string expectedGeneratedSource, params string[] sources)
    {
        var runResult = RunCompilation(sources);

        Assert.AreEqual(0, runResult.Diagnostics.Length, $"Compilation failed with {runResult.Diagnostics.Length} diagnostics:{Environment.NewLine}{string.Join(Environment.NewLine, runResult.Diagnostics)}");
        Assert.AreEqual(1, runResult.Results.Length, "Count of generator results mismatched");
        Assert.AreEqual(1, runResult.Results[0].GeneratedSources.Length, "Count of generated sources mismatched");
        Assert.AreEqual(expectedGeneratedSource, runResult.Results[0].GeneratedSources[0].SourceText.ToString());
    }

    /// <summary>
    /// Returns the <see cref="MetadataReference"/>s which are need to compile the source
    /// </summary>
    /// <returns>Enumerable of needed references</returns>
    protected virtual IEnumerable<MetadataReference> GetMetadataReferences()
    {
        yield return MetadataReference.CreateFromFile(Assembly.Load("Teshigoto.Annotation").Location);
        yield return MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location);
        yield return MetadataReference.CreateFromFile(Assembly.Load("System.Private.CoreLib").Location);
        yield return MetadataReference.CreateFromFile(Assembly.Load("netstandard").Location);
    }

    #endregion // Protected methods

    #region Private methods

    /// <summary>
    /// Get additional sources
    /// </summary>
    /// <returns>List of <see cref="SyntaxTree"/>-objects of all additional sources</returns>
    private static IEnumerable<SyntaxTree> GetAdditionalSources()
    {
        yield return CSharpSyntaxTree.ParseText(DummyTypes.DummyClass);
        yield return CSharpSyntaxTree.ParseText(DummyTypes.DummyRecordClass);
        yield return CSharpSyntaxTree.ParseText(DummyTypes.DummyRecordStruct);
        yield return CSharpSyntaxTree.ParseText(DummyTypes.DummyStruct);

        yield return CSharpSyntaxTree.ParseText(Interfaces.IComparableOperators);
        yield return CSharpSyntaxTree.ParseText(Interfaces.IEqualityOperators);
        yield return CSharpSyntaxTree.ParseText(Interfaces.IFactory1);
        yield return CSharpSyntaxTree.ParseText(Interfaces.IFactory2);
        yield return CSharpSyntaxTree.ParseText(Interfaces.IFactory3);
        yield return CSharpSyntaxTree.ParseText(Interfaces.IFactory4);
    }

    /// <summary>
    /// Runs the generator
    /// </summary>
    /// <param name="compilation">Compilation</param>
    /// <returns>Returns the run result and the diagnostics</returns>
    private static (GeneratorDriverRunResult RunResult, ImmutableArray<Diagnostic> Diagnostics) RunGenerator(CSharpCompilation compilation)
    {
        var generator = new TGenerator();

        var driver = CSharpGeneratorDriver.Create(generator)
                                          .RunGeneratorsAndUpdateCompilation(compilation, out _, out var diagnostics);

        return (driver.GetRunResult(), diagnostics);
    }

    /// <summary>
    /// Runs the compilation
    /// </summary>
    /// <param name="sources">Sources</param>
    /// <returns>Results</returns>
    private GeneratorDriverRunResult RunCompilation(string[] sources)
    {
        var compilation = CreateCompilation(sources);

        var result = RunGenerator(compilation);

        var errors = result.Diagnostics
                           .Where(diagnostic => diagnostic.Severity == DiagnosticSeverity.Error)
                           .ToList();

        if (errors.Count > 0)
        {
            Assert.Fail($"The compilation executed with errors!{Environment.NewLine} => {string.Join($"{Environment.NewLine} => ", errors.Select(obj => obj.GetMessage()))}");
        }

        return result.RunResult;
    }

    /// <summary>
    /// Creates the compilation
    /// </summary>
    /// <param name="sources">Sources</param>
    /// <returns>Compilation result</returns>
    private CSharpCompilation CreateCompilation(string[] sources)
    {
        var syntaxTrees = sources.Select(source => CSharpSyntaxTree.ParseText(source));
        var compilation = CSharpCompilation.Create("SourceGeneratorTestBase_TestAssembly",
                                                   GetAdditionalSources().Concat(syntaxTrees),
                                                   GetMetadataReferences(),
                                                   new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        return compilation;
    }

    #endregion // Private methods

    #endregion // Methods
}