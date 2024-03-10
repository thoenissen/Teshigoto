using Teshigoto.Generators.Core;

namespace Teshigoto.Generators.Comparable;

/// <summary>
/// Creation of the matching <see cref="ComparableGeneratorBase"/> for a given <see cref="SyntaxNode"/>
/// </summary>
internal static class ComparableGeneratorFactory
{
    /// <summary>
    /// Create the matching <see cref="ComparableGeneratorBase"/> for the given <see cref="SyntaxNode"/>
    /// </summary>
    /// <param name="node">Node</param>
    /// <param name="metaData">Meta data</param>
    /// <returns>Created generator</returns>
    public static ComparableGeneratorBase Create(SyntaxNode node, CompilationMetaData metaData)
    {
        return node switch
               {
                   ClassDeclarationSyntax _ => new ClassComparableGenerator(metaData),
                   StructDeclarationSyntax _ => new StructComparableGenerator(metaData),
                   RecordDeclarationSyntax _ when node.IsKind(SyntaxKind.RecordStructDeclaration) => new StructComparableGenerator(metaData),
                   RecordDeclarationSyntax _ => new ClassComparableGenerator(metaData),
                   _ => throw new NotSupportedException($"The type '{node.GetType()}' is not supported")
               };
    }
}