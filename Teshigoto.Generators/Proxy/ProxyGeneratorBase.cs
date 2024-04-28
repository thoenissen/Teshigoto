namespace Teshigoto.Generators.Proxy;

/// <summary>
/// Base class for generating proxy implementation
/// </summary>
public abstract class ProxyGeneratorBase
{
    /// <summary>
    /// Generate implementation
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="proxyAttributeData">Attribute data</param>
    /// <returns>Generated source code</returns>
    public abstract string Generate(ITypeSymbol symbol, AttributeData proxyAttributeData);
}