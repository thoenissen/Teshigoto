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
    /// <returns>Created generator</returns>
    public static ProxyGeneratorBase Create()
    {
        return new ClassProxyGenerator();
    }

    #endregion // Methods
}