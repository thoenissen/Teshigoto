using Teshigoto.Generators.Core;
using Teshigoto.Generators.Mapper;

namespace Teshigoto.Generators;

/// <summary>
/// Automatically implements IMapper-interface for the class
/// </summary>
[Generator]
public class MapperGenerator : IIncrementalGenerator
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
                var attributeData = symbol.GetAttributes()
                                                   .FirstOrDefault(x => x.AttributeClass?.Equals(metaData.GenerateMapperAttribute, SymbolEqualityComparer.Default) == true);

                if (attributeData == null)
                {
                    continue;
                }

                if (handledSymbols.Add(symbol.ToDisplayString()) == false)
                {
                    continue;
                }

                var generator = MapperGeneratorFactory.Create(node, metaData);

                var source = generator.Generate(symbol);

                if (string.IsNullOrEmpty(source) == false)
                {
                    context.AddSource($"{Escape.SymbolName(symbol)}.Mapper.Generator.g.cs", source);
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
                              .ForAttributeWithMetadataName("Teshigoto.Annotation.GenerateMapperAttribute",
                                                            (syntaxNode, _) =>
                                                            {
                                                                return syntaxNode switch
                                                                       {
                                                                           ClassDeclarationSyntax => true,
                                                                           _ => false
                                                                       };
                                                            },
                                                            (syntaxContext, ct) => syntaxContext);

        var combined = context.CompilationProvider.Combine(provider.Collect());

        context.RegisterSourceOutput(combined, (spc, pair) => Execute(spc, pair.Left, pair.Right));
    }

    #endregion // IIncrementalGenerator
}