using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function.Comparable;

/// <summary>
/// Comparable tester
/// </summary>
/// <typeparam name="T">Test type</typeparam>
public class ComparableTesterOneValue<T> : ComparableTesterBase<T>
    where T : IComparableOperators<T>,
              IFactory<T, int>,
              IComparable<T>,
              IComparable
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
    public static void AssertGreater()
    {
        var left = T.Create(1);
        var right = T.Create(2);

        AssertGreater(left, right);
    }

    /// <summary>
    /// Less tests
    /// </summary>
    public static void AssertLess()
    {
        var left = T.Create(2);
        var right = T.Create(1);

        AssertLess(left, right);
    }
}