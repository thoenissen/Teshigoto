using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function.Comparable;

/// <summary>
/// Comparable tester
/// </summary>
/// <typeparam name="T">Test type</typeparam>
public class ComparableTesterBase<T>
    where T : IComparableOperators<T>,
              IComparable<T>,
              IComparable
{
    #region Methods

    /// <summary>
    /// Equals tests
    /// </summary>
    /// <param name="left">Left object </param>
    /// <param name="right">Right object</param>
    protected static void AssertEquals(T left, T right)
    {
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
    /// <param name="left">Left object </param>
    /// <param name="right">Right object</param>
    protected static void AssertGreater(T left, T right)
    {
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
    /// <param name="left">Left object </param>
    /// <param name="right">Right object</param>
    protected static void AssertLess(T left, T right)
    {
        Assert.IsTrue(left > right);
        Assert.IsTrue(left >= right);

        Assert.IsFalse(left < right);
        Assert.IsFalse(left <= right);

        Assert.AreEqual(1, left.CompareTo(right));
        Assert.AreEqual(-1, right.CompareTo(left));
    }

    #endregion // Methods
}