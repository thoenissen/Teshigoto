namespace Teshigoto.CompilationTests.Interfaces;

/// <summary>
/// Compare operators
/// </summary>
/// <typeparam name="T">Type</typeparam>
public interface IComparableOperators<in T>
    where T : IComparableOperators<T>
{
    #region Methods

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:T" /> value is less than another <see cref="T:T" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is less than <paramref name="right" />; otherwise, false.</returns>
    static abstract bool operator <(T? left, T? right);

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:T" /> value is less than or equal to another <see cref="T:T" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, false.</returns>
    static abstract bool operator <=(T? left, T? right);

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:T" /> value is greater than another <see cref="T:T" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.</returns>
    static abstract bool operator >(T? left, T? right);

    /// <summary>
    /// Returns a value that indicates whether a <see cref="T:T" /> value is greater than or equal to another <see cref="T:T" /> value.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.</returns>
    static abstract bool operator >=(T? left, T? right);

    #endregion // Methods
}