using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function;

/// <summary>
/// Equals tester
/// </summary>
/// <typeparam name="T">Test type</typeparam>
public static class ComparableTester<T>
    where T : IComparableOperators<T>,
              IOneValueFactory<T, int>,
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

        Assert.IsFalse(left > right);
        Assert.IsFalse(left < right);

        Assert.IsTrue(left >= right);
        Assert.IsTrue(left <= right);

        Assert.AreEqual(0, left.CompareTo(right));
        Assert.AreEqual(0, right.CompareTo(left));
    }

    /// <summary>
    /// Greater tests
    /// </summary>
    public static void AssertGreater()
    {
        var left = T.Create(1);
        var right = T.Create(2);

        Assert.IsTrue(left < right);
        Assert.IsTrue(left <= right);

        Assert.IsFalse(left > right);
        Assert.IsFalse(left >= right);

        Assert.AreEqual(-1, left.CompareTo(right));
        Assert.AreEqual(1, right.CompareTo(left));
    }

    /// <summary>
    /// Less tests
    /// </summary>
    public static void AssertLess()
    {
        var left = T.Create(2);
        var right = T.Create(1);

        Assert.IsTrue(left > right);
        Assert.IsTrue(left >= right);

        Assert.IsFalse(left < right);
        Assert.IsFalse(left <= right);

        Assert.AreEqual(1, left.CompareTo(right));
        Assert.AreEqual(-1, right.CompareTo(left));
    }
}