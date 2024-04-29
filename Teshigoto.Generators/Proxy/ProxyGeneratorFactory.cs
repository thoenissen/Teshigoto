using Teshigoto.Generators.Core;

namespace Teshigoto.Generators.Proxy;

/// <summary>
/// Creation of the matching <see cref="ProxyGeneratorBase"/> for a given <see cref="SyntaxNode"/>
/// </summary>
internal static class ProxyGeneratorFactory
{
    #region Methods

    /// <summary>
    /// Create the matching <see cref="ProxyGeneratorBase"/> for the given <see cref="SyntaxNode"/>
    /// </summary>
    /// <param name="node">Node</param>
    /// <param name="metaData">Meta data</param>
    /// <returns>Created generator</returns>
    public static ProxyGeneratorBase Create(SyntaxNode node, CompilationMetaData metaData)
    {
        return node switch
               {
                   ClassDeclarationSyntax _ => new ClassProxyGenerator(metaData),
                   _ => throw new NotSupportedException($"The type '{node.GetType()}' is not supported")
               };
    }

    #endregion // Methods
}