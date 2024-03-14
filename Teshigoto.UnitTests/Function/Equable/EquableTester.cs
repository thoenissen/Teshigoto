using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function.Equable;

/// <summary>
/// Equals tester
/// </summary>
/// <typeparam name="T">Test type</typeparam>
public class EquableTesterOneValue<T> : EquableTesterBase<T>
    where T : IEqualityOperators<T>,
              IFactory<T, int>,
              IEquatable<T>
{
    /// <summary>
    /// Equals tests
    /// </summary>
    public static void AssertEquals()
    {
        var left = T.Create(1);
        var right = T.Create(1);

        AssertEquals(left, right);
    }

    /// <summary>
    /// Greater tests
    /// </summary>
    public static void AssertNotEquals()
    {
        var left = T.Create(1);
        var right = T.Create(2);

        AssertNotEquals(left, right);

        left = T.Create(2);
        right = T.Create(1);

        AssertNotEquals(left, right);
    }
}