using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function;

/// <summary>
/// Comparable tester
/// </summary>
/// <typeparam name="TTestType">Test type</typeparam>
public class ComparableTesterIgnoreValues<TTestType> : ComparableTesterBase<TTestType>
    where TTestType : IComparableOperators<TTestType>,
                      IFactory<TTestType, int, int, int, int>,
                      IComparable<TTestType>,
                      IComparable
{
    /// <summary>
    /// Equals tests
    /// </summary>
    public static void AssertEquals()
    {
        var left = TTestType.Create(1, int.MinValue, 3, int.MinValue);
        var right = TTestType.Create(1, int.MaxValue, 3, int.MinValue);

        AssertEquals(left, right);

        left = TTestType.Create(1, int.MinValue, 3, int.MinValue);
        right = TTestType.Create(1, int.MinValue, 3, int.MaxValue);

        AssertEquals(left, right);

        left = TTestType.Create(1, int.MaxValue, 3, int.MinValue);
        right = TTestType.Create(1, int.MinValue, 3, int.MinValue);

        AssertEquals(left, right);

        left = TTestType.Create(1, int.MinValue, 3, int.MaxValue);
        right = TTestType.Create(1, int.MinValue, 3, int.MinValue);

        AssertEquals(left, right);
    }

    /// <summary>
    /// Greater tests
    /// </summary>
    public static void AssertGreater()
    {
        var left = TTestType.Create(1, int.MinValue, 3, int.MinValue);
        var right = TTestType.Create(10, int.MaxValue, 3, int.MaxValue);

        AssertGreater(left, right);

        left = TTestType.Create(1, int.MinValue, 3, int.MinValue);
        right = TTestType.Create(1, int.MaxValue, 10, int.MaxValue);

        AssertGreater(left, right);
    }

    /// <summary>
    /// Less tests
    /// </summary>
    public static void AssertLess()
    {
        var left = TTestType.Create(10, int.MinValue, 3, int.MinValue);
        var right = TTestType.Create(1, int.MaxValue, 3, int.MaxValue);

        AssertLess(left, right);

        left = TTestType.Create(1, int.MinValue, 10, int.MinValue);
        right = TTestType.Create(1, int.MaxValue, 3, int.MaxValue);

        AssertLess(left, right);
    }
}