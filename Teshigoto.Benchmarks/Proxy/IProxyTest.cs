namespace Teshigoto.Benchmarks.Proxy;

/// <summary>
/// Proxy test interface
/// </summary>
public interface IProxyTest
{
    /// <summary>
    /// Test method
    /// </summary>
    /// <param name="a">Value A</param>
    /// <param name="b">Value B</param>
    /// <returns>Sum of a and b</returns>
    int Calculate(int a, int b);
}