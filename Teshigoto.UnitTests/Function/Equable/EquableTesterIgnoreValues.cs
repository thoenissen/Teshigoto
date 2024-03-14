using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function.Equable;

/// <summary>
/// Equality tester
/// </summary>
/// <typeparam name="TTestType">Test type</typeparam>
public class EquableTesterIgnoreValues<TTestType> : EquableTesterBase<TTestType>
    where TTestType : IEqualityOperators<TTestType>,
                      IFactory<TTestType, int, int, int, int>,
                      IEquatable<TTestType>
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
    /// Not equals tests
    /// </summary>
    public static void AssertNotEquals()
    {
        var left = TTestType.Create(1, default, 3, default);
        var right = TTestType.Create(2, default, 3, default);

        AssertNotEquals(left, right);

        left = TTestType.Create(1, default, 2, default);
        right = TTestType.Create(1, default, 3, default);

        AssertNotEquals(left, right);

        left = TTestType.Create(1, default, 3, default);
        right = TTestType.Create(2, default, 3, default);

        AssertNotEquals(left, right);

        left = TTestType.Create(1, default, 3, default);
        right = TTestType.Create(1, default, 2, default);

        AssertNotEquals(left, right);
    }
}