using System.Diagnostics;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

/********************************
 *
 * * Summary *
 *
 * BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
 * Unknown processor
 * .NET SDK 8.0.204
 *   [Host]     : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
 *   Job-ENKXRC : .NET 8.0.4 (8.0.424.16909), X64 RyuJIT AVX2
 *
 * InvocationCount=1073741824  IterationCount=512  LaunchCount=4
 * WarmupCount=32
 *
 * | Method | Mean      | Error     | StdDev    | Median    | Ratio | RatioSD |
 * |------- |----------:|----------:|----------:|----------:|------:|--------:|
 * | Direct | 0.0199 ns | 0.0025 ns | 0.0340 ns | 0.0000 ns |     ? |       ? |
 * | Proxy  | 0.0209 ns | 0.0027 ns | 0.0352 ns | 0.0000 ns |     ? |       ? |
 * | Lazy   | 0.0453 ns | 0.0022 ns | 0.0290 ns | 0.0538 ns |     ? |       ? |
 *
 * * Warnings *
 * BaselineCustomAnalyzer
 *   Summary -> A question mark '?' symbol indicates that it was not possible to compute the (Ratio, RatioSD) column(s) because the baseline value is too close to zero.
 * MultimodalDistribution
 *   ProxyBenchmark.Lazy: InvocationCount=1073741824, IterationCount=512, LaunchCount=4, WarmupCount=32 -> It seems that the distribution is multimodal (mValue = 4.55)
 * ZeroMeasurement
 *   ProxyBenchmark.Direct: InvocationCount=1073741824, IterationCount=512, LaunchCount=4, WarmupCount=32 -> The method duration is indistinguishable from the empty method duration
 *   ProxyBenchmark.Proxy: InvocationCount=1073741824, IterationCount=512, LaunchCount=4, WarmupCount=32  -> The method duration is indistinguishable from the empty method duration
 *
 * * Hints *
 * Outliers
 *   ProxyBenchmark.Lazy: InvocationCount=1073741824, IterationCount=512, LaunchCount=4, WarmupCount=32 -> 53 outliers were removed, 565 outliers were detected (0.97 ns..1.01 ns, 1.10 ns..1.12 ns)
 *
 ********************************/
namespace Teshigoto.Benchmarks.Proxy;

/// <summary>
/// Benchmarking proxy performance
/// </summary>
[SimpleJob(4, 32, 512, 1_073_741_824)]
public class ProxyBenchmark
{
    #region Fields

    /// <summary>
    /// Direct call
    /// </summary>
    private IProxyTest _direct = new ProxyTest();

    /// <summary>
    /// Proxy
    /// </summary>
    private IProxyTest _proxy = new ProxyTest.Proxy();

    /// <summary>
    /// Lazy
    /// </summary>
    private Lazy<IProxyTest> _lazy = new(() => new ProxyTest(), true);

    #endregion // Fields

    #region Properties

    /// <summary>
    /// Value A
    /// </summary>
    public int A { get; set; } = 1;

    /// <summary>
    /// Value B
    /// </summary>
    public int B { get; set; } = 2;

    #endregion // Properties

    #region Test & Run

    /// <summary>
    /// Test the Benchmark
    /// </summary>
    public static void Test()
    {
        var benchmark = new ProxyBenchmark();
        Trace.Assert(benchmark.Direct() == 3);
        Trace.Assert(benchmark.Proxy() == 3);
        Trace.Assert(benchmark.Lazy() == 3);
    }

    /// <summary>
    /// Run the benchmark
    /// </summary>
    public static void Run()
    {
        BenchmarkRunner.Run<ProxyBenchmark>();
    }

    #endregion // Test & Run

    #region Benchmark

    /// <summary>
    /// Direct call as reference
    /// </summary>
    /// <returns>Sum of a and b</returns>
    [Benchmark(Baseline = true)]
    public int Direct()
    {
        return _direct.Calculate(A, B);
    }

    /// <summary>
    /// Using a generated proxy
    /// </summary>
    /// <returns>Sum of a and b</returns>
    [Benchmark]
    public int Proxy()
    {
        return _proxy.Calculate(A, B);
    }

    /// <summary>
    /// Using a <see cref="Lazy{T}"/> instance
    /// </summary>
    /// <returns>Sum of a and b</returns>
    [Benchmark]
    public int Lazy()
    {
        return _lazy.Value.Calculate(A, B);
    }

    #endregion // Benchmark
}