using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function.Equable;

/// <summary>
/// Equality tester
/// </summary>
/// <typeparam name="TTestType">Test type</typeparam>
/// <typeparam name="TValueType">Type of the third value</typeparam>
public class EquableTesterThreeValues<TTestType, TValueType> : EquableTesterBase<TTestType>
    where TTestType : IEqualityOperators<TTestType>,
                      IFactory<TTestType, int, string, TValueType?>,
                      IEquatable<TTestType>
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
    /// Not equals tests
    /// </summary>
    /// <param name="lowValue">Low value</param>
    /// <param name="highValue">High value</param>
    public static void AssertNotEquals(TValueType lowValue, TValueType highValue)
    {
        var left = TTestType.Create(1, "Test", lowValue);
        var right = TTestType.Create(2, "Test", lowValue);

        AssertNotEquals(left, right);

        left = TTestType.Create(1, "A", lowValue);
        right = TTestType.Create(1, "B", lowValue);

        AssertNotEquals(left, right);

        left = TTestType.Create(1, "Test", lowValue);
        right = TTestType.Create(1, "Test", highValue);

        AssertNotEquals(left, right);
    }
}