using Teshigoto.CompilationTests.Interfaces;

namespace Teshigoto.UnitTests.Function.Equable;

/// <summary>
/// Equality tester
/// </summary>
/// <typeparam name="T">Test type</typeparam>
public class EquableTesterBase<T>
    where T : IEqualityOperators<T>,
              IEquatable<T>
{
    #region Methods

    /// <summary>
    /// Equals tests
    /// </summary>
    /// <param name="left">Left object </param>
    /// <param name="right">Right object</param>
    protected static void AssertEquals(T left, T right)
    {
        Assert.IsTrue(left == right);
        Assert.IsTrue(left.Equals(right));
        Assert.IsTrue(left.Equals((object)right));

        Assert.IsFalse(left != right);
    }

    /// <summary>
    /// Not equals tests
    /// </summary>
    /// <param name="left">Left object </param>
    /// <param name="right">Right object</param>
    protected static void AssertNotEquals(T left, T right)
    {
        Assert.IsFalse(left == right);
        Assert.IsFalse(left.Equals(right));
        Assert.IsFalse(left.Equals((object)right));

        Assert.IsTrue(left != right);
    }

    #endregion // Methods
}