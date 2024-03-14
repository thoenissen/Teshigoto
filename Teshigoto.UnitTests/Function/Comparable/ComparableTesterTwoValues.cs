using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function.Comparable;

/// <summary>
/// Comparable tester
/// </summary>
/// <typeparam name="T">Test type</typeparam>
public class ComparableTesterTwoValues<T> : ComparableTesterBase<T>
    where T : IComparableOperators<T>,
              IFactory<T, int, string>,
              IComparable<T>,
              IComparable
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
    /// Greater tests
    /// </summary>
    public static void AssertGreater()
    {
        var left = T.Create(1, "Test");
        var right = T.Create(2, "Test");

        AssertGreater(left, right);

        left = T.Create(1, "A");
        right = T.Create(1, "B");

        AssertGreater(left, right);
    }

    /// <summary>
    /// Less tests
    /// </summary>
    public static void AssertLess()
    {
        var left = T.Create(2, "Test");
        var right = T.Create(1, "Test");

        AssertLess(left, right);

        left = T.Create(1, "B");
        right = T.Create(1, "A");

        AssertLess(left, right);
    }
}