using Teshigoto.Annotation;

namespace Teshigoto.Benchmarks.Proxy;

/// <summary>
/// Proxy test implementation
/// </summary>
[Proxy<IProxyTest>]
public partial class ProxyTest : IProxyTest
{
    #region IProxyTest

    /// <inheritdoc />
    public int Calculate(int a, int b)
    {
        return a + b;
    }

    #endregion // IProxyTest
}