using Teshigoto.Benchmarks.Proxy;

namespace Teshigoto.Benchmarks;

/// <summary>
/// Main class
/// </summary>
internal static class Program
{
    /// <summary>
    /// Main entry
    /// </summary>
    public static void Main()
    {
        ProxyBenchmark.Test();
        ProxyBenchmark.Run();
    }
}