using Teshigoto.Annotation;
using Teshigoto.Generators.Core;
using Teshigoto.Generators.Equable;

namespace Teshigoto.Generators;

/// <summary>
/// Automatically implements the <see cref="IEquatable{T}"/>-interface for the class
/// </summary>
[Generator]
public class EquableGenerator : IIncrementalGenerator
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
                                                   .FirstOrDefault(x => x.AttributeClass?.Equals(metaData.EquatableAttribute, SymbolEqualityComparer.Default) == true);

                if (equatableAttributeData == null)
                {
                    continue;
                }

                if (handledSymbols.Add(symbol.ToDisplayString()) == false)
                {
                    continue;
                }

                var generator = EquableGeneratorFactory.Create(node, metaData);

                var source = generator.Generate(symbol);

                if (string.IsNullOrEmpty(source) == false)
                {
                    context.AddSource($"{Escape.SymbolName(symbol)}.EquableGenerator.g.cs", source);
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
                              .ForAttributeWithMetadataName(typeof(EquableAttribute).FullName!,
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