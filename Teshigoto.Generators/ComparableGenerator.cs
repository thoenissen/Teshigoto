using Teshigoto.Annotation;
using Teshigoto.Generators.Comparable;
using Teshigoto.Generators.Core;

namespace Teshigoto.Generators;

/// <summary>
/// Automatically implements the <see cref="IComparable{T}"/>-interface for the class
/// </summary>
[Generator]
public class ComparableGenerator : IIncrementalGenerator
{
    #region Private methods

    /// <summary>
    /// Executes the generator
    /// </summary>
    /// <param name="context">Context</param>
    /// <param name="compilation">Compilation</param>
    /// <param name="attributes">Attributes</param>
    private void Execute(SourceProductionContext context, Compilation compilation, ImmutableArray<GeneratorAttributeSyntaxContext> attributes)
    {
        var metaData = new CompilationMetaData(compilation);

        var handledSymbols = new HashSet<string>();

        foreach (var item in attributes)
        {
            var node = item.TargetNode;
            var model = item.SemanticModel;

            if (model.GetDeclaredSymbol(node, context.CancellationToken) is ITypeSymbol symbol)
            {
                var equatableAttributeData = symbol.GetAttributes()
                                                   .FirstOrDefault(x => x.AttributeClass?.Equals(metaData.ComparableAttribute, SymbolEqualityComparer.Default) == true);

                if (equatableAttributeData == null)
                {
                    continue;
                }

                if (handledSymbols.Add(symbol.ToDisplayString()) == false)
                {
                    continue;
                }

                var generator = ComparableGeneratorFactory.Create(node, metaData);

                var source = generator.Generate(symbol);

                if (string.IsNullOrEmpty(source) == false)
                {
                    context.AddSource($"{Escape.SymbolName(symbol)}.ComparableGenerator.g.cs", source);
                }
            }
        }
    }

    #endregion // Private methods

    #region IIncrementalGenerator

    /// <inheritdoc/>
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var provider = context.SyntaxProvider
                              .ForAttributeWithMetadataName(typeof(ComparableAttribute).FullName!,
                                                            (syntaxNode, _) =>
                                                            {
                                                                return syntaxNode switch
                                                                {
                                                                    ClassDeclarationSyntax => true,
                                                                    RecordDeclarationSyntax => true,
                                                                    StructDeclarationSyntax => true,
                                                                    _ => false
                                                                };
                                                            },
                                                            (syntaxContext, ct) => syntaxContext);

        var combined = context.CompilationProvider.Combine(provider.Collect());

        context.RegisterSourceOutput(combined, (spc, pair) => Execute(spc, pair.Left, pair.Right));
    }

    #endregion // IIncrementalGenerator
}