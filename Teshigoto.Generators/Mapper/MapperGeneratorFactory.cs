using Teshigoto.Generators.Core;

namespace Teshigoto.Generators.Mapper;

/// <summary>
/// Creation of the matching <see cref="MapperGeneratorBase"/> for a given <see cref="SyntaxNode"/>
/// </summary>
internal static class MapperGeneratorFactory
{
    /// <summary>
    /// Create the matching <see cref="MapperGeneratorBase"/> for the given <see cref="SyntaxNode"/>
    /// </summary>
    /// <param name="node">Node</param>
    /// <param name="metaData">Meta data</param>
    /// <returns>Created generator</returns>
    public static MapperGeneratorBase Create(INamedTypeSymbol node, CompilationMetaData metaData)
    {
        if (node.IsValueType == false
            && node.IsRecord == false)
        {
            return new ClassMapperGenerator(metaData);
        }

        throw new NotSupportedException($"The type '{node.GetType()}' is not supported");
    }
}