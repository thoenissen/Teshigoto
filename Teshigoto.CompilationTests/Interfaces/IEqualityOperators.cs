namespace Teshigoto.CompilationTests.Interfaces;

/// <summary>
/// Equality operators
/// </summary>
/// <typeparam name="T">Type</typeparam>
public interface IEqualityOperators<in T>
    where T : IEqualityOperators<T>
{
    /// <summary>
    /// Returns a value that indicates whether the values of two T objects are equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, false.</returns>
    static abstract bool operator ==(T? left, T? right);

    /// <summary>
    /// Returns a value that indicates whether the values of two T objects have different values.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.</returns>
    static abstract bool operator !=(T? left, T? right);
}