using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function.Equable;

/// <summary>
/// Equality tester
/// </summary>
/// <typeparam name="T">Test type</typeparam>
public class EquableTesterTwoValues<T> : EquableTesterBase<T>
    where T : IEqualityOperators<T>,
              IFactory<T, int, string>,
              IEquatable<T>
{
    /// <summary>
    /// Equals tests
    /// </summary>
    public static void AssertEquals()
    {
        var left = T.Create(1, "Test");
        var right = T.Create(1, "Test");

        AssertEquals(left, right);
    }

    /// <summary>
    /// Not equals tests
    /// </summary>
    public static void AssertNotEquals()
    {
        var left = T.Create(1, "Test");
        var right = T.Create(2, "Test");

        AssertNotEquals(left, right);

        left = T.Create(1, "A");
        right = T.Create(1, "B");

        AssertNotEquals(left, right);
    }
}