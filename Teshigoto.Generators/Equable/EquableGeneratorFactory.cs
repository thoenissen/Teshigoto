using Teshigoto.Generators.Core;

namespace Teshigoto.Generators.Equable;

/// <summary>
/// Creation of the matching <see cref="EquableGeneratorBase"/> for a given <see cref="SyntaxNode"/>
/// </summary>
internal static class MapperGeneratorFactory
{
    /// <summary>
    /// Create the matching <see cref="EquableGeneratorBase"/> for the given <see cref="SyntaxNode"/>
    /// </summary>
    /// <param name="node">Node</param>
    /// <param name="metaData">Meta data</param>
    /// <returns>Created generator</returns>
    public static EquableGeneratorBase Create(SyntaxNode node, CompilationMetaData metaData)
    {
        return node switch
               {
                   ClassDeclarationSyntax _ => new ClassEquableGenerator(metaData),
                   StructDeclarationSyntax _ => new StructEquableGenerator(metaData),
                   RecordDeclarationSyntax _ when node.IsKind(SyntaxKind.RecordStructDeclaration) => new RecordStructEquableGenerator(metaData),
                   RecordDeclarationSyntax _ => new RecordClassEquableGenerator(metaData),
                   _ => throw new NotSupportedException($"The type '{node.GetType()}' is not supported")
               };
    }
}