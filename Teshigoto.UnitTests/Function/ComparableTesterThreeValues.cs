using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function;

/// <summary>
/// Comparable tester
/// </summary>
/// <typeparam name="TTestType">Test type</typeparam>
/// <typeparam name="TValueType">Type of the third value</typeparam>
public class ComparableTesterThreeValues<TTestType, TValueType> : ComparableTesterBase<TTestType>
    where TTestType : IComparableOperators<TTestType>,
                      IFactory<TTestType, int, string, TValueType?>,
                      IComparable<TTestType>,
                      IComparable
{
    /// <summary>
    /// Equals tests
    /// </summary>
    public static void AssertEquals()
    {
        var left = TTestType.Create(1, "Test", default);
        var right = TTestType.Create(1, "Test", default);

        AssertEquals(left, right);
    }

    /// <summary>
    /// Greater tests
    /// </summary>
    /// <param name="lowValue">Low value</param>
    /// <param name="highValue">High value</param>
    public static void AssertGreater(TValueType lowValue, TValueType highValue)
    {
        var left = TTestType.Create(1, "Test", lowValue);
        var right = TTestType.Create(2, "Test", lowValue);

        AssertGreater(left, right);

        left = TTestType.Create(1, "A", lowValue);
        right = TTestType.Create(1, "B", lowValue);

        AssertGreater(left, right);

        left = TTestType.Create(1, "Test", lowValue);
        right = TTestType.Create(1, "Test", highValue);

        AssertGreater(left, right);
    }

    /// <summary>
    /// Less tests
    /// </summary>
    /// <param name="lowValue">Low value</param>
    /// <param name="highValue">High value</param>
    public static void AssertLess(TValueType lowValue, TValueType highValue)
    {
        var left = TTestType.Create(2, "Test", lowValue);
        var right = TTestType.Create(1, "Test", lowValue);

        AssertLess(left, right);

        left = TTestType.Create(1, "B", lowValue);
        right = TTestType.Create(1, "A", lowValue);

        AssertLess(left, right);

        left = TTestType.Create(1, "Test", highValue);
        right = TTestType.Create(1, "Test", lowValue);

        AssertLess(left, right);
    }
}