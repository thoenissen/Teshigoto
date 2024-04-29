namespace Teshigoto.Generators.Proxy;

/// <summary>
/// Creation of the matching <see cref="ProxyGeneratorBase"/> for a given <see cref="SyntaxNode"/>
/// </summary>
internal class ProxyGeneratorFactory
{
    #region Methods

    /// <summary>
    /// Create the matching <see cref="ProxyGeneratorBase"/> for the given <see cref="SyntaxNode"/>
    /// </summary>
    /// <param name="node">Node</param>
    /// <returns>Created generator</returns>
    public static ProxyGeneratorBase Create(SyntaxNode node)
    {
        return node switch
               {
                   ClassDeclarationSyntax _ => new ClassProxyGenerator(),
                   _ => throw new NotSupportedException($"The type '{node.GetType()}' is not supported")
               };
    }

    #endregion // Methods
}