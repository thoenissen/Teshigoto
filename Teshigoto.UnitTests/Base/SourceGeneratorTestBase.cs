using System.Collections.Immutable;
using System.Reflection;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using Teshigoto.UnitTests.Resources;

namespace Teshigoto.UnitTests.Base;

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
    /// <param name="source">Source</param>
    /// <param name="expectedGeneratedSource">Generated source</param>
    protected void AssertGenerationResult(string source, string expectedGeneratedSource)
    {
        var runResult = RunCompilation(source);

        Assert.AreEqual(runResult.Diagnostics.Length, 0, $"Compilation failed with {runResult.Diagnostics.Length} diagnostics:{Environment.NewLine}{string.Join(Environment.NewLine, runResult.Diagnostics)}");
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
    /// <param name="source">Source</param>
    /// <returns>Results</returns>
    private GeneratorDriverRunResult RunCompilation(string source)
    {
        var compilation = CreateCompilation(source);

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
    /// <param name="source">Source</param>
    /// <returns>Compilation result</returns>
    private CSharpCompilation CreateCompilation(string source)
    {
        var syntaxTree = CSharpSyntaxTree.ParseText(source);
        var compilation = CSharpCompilation.Create("SourceGeneratorTestBase_TestAssembly",
                                                   GetAdditionalSources().Concat([syntaxTree]),
                                                   GetMetadataReferences(),
                                                   new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        return compilation;
    }

    /// <summary>
    /// Get additional sources
    /// </summary>
    /// <returns>List of <see cref="SyntaxTree"/>-objects of all additional sources</returns>
    private IEnumerable<SyntaxTree> GetAdditionalSources()
    {
        yield return CSharpSyntaxTree.ParseText(DummyTypes.EmptyClass);
        yield return CSharpSyntaxTree.ParseText(DummyTypes.EmptyRecordClass);
        yield return CSharpSyntaxTree.ParseText(DummyTypes.EmptyRecordStruct);
        yield return CSharpSyntaxTree.ParseText(DummyTypes.EmptyStruct);
    }

    #endregion // Private methods

    #endregion // Methods
}