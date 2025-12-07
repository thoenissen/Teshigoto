using Teshigoto.Generators.Core;
using Teshigoto.Generators.Proxy;

namespace Teshigoto.Generators;

/// <summary>
/// Automatically implementation of a proxy
/// </summary>
[Generator]
public class ProxyGenerator : IIncrementalGenerator
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
                var proxyAttributeData = symbol.GetAttributes()
                                               .FirstOrDefault(x => x.AttributeClass is { IsGenericType: true, IsUnboundGenericType: false }
                                                                    && x.AttributeClass.ConstructUnboundGenericType().Equals(metaData.ProxyAttribute, SymbolEqualityComparer.Default));

                if (proxyAttributeData == null)
                {
                    continue;
                }

                if (handledSymbols.Add(symbol.ToDisplayString()) == false)
                {
                    continue;
                }

                var generator = ProxyGeneratorFactory.Create(node, metaData);

                var source = generator.Generate(symbol, proxyAttributeData);

                if (string.IsNullOrEmpty(source) == false)
                {
                    context.AddSource($"{Escape.SymbolName(symbol)}.ProxyGenerator.g.cs", source);
                }
            }
        }
    }

    #endregion // Private methods

    #region IIncrementalGenerator

    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var provider = context.SyntaxProvider
                              .ForAttributeWithMetadataName("Teshigoto.Annotation.ProxyAttribute`1",
                                                            (syntaxNode, _) =>
                                                            {
                                                                return syntaxNode switch
                                                                {
                                                                    ClassDeclarationSyntax => true,
                                                                    _ => false
                                                                };
                                                            },
                                                            (syntaxContext, _) => syntaxContext);

        var combined = context.CompilationProvider.Combine(provider.Collect());

        context.RegisterSourceOutput(combined, (spc, pair) => Execute(spc, pair.Left, pair.Right));
    }

    #endregion // IIncrementalGenerator
}