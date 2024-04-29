using Teshigoto.Generators.Enumerations;

namespace Teshigoto.Generators.Data;

/// <summary>
/// Member sorting key
/// </summary>
internal sealed class MemberSortingKey : IComparable<MemberSortingKey>,
                                         IComparable,
                                         IEquatable<MemberSortingKey>
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="type">Type</param>
    /// <param name="order">Order number</param>
    public MemberSortingKey(MemberSortingType type, long order)
    {
        Type = type;
        Order = order;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Type
    /// </summary>
    public MemberSortingType Type { get; }

    /// <summary>
    /// Order number
    /// </summary>
    public long Order { get; }

    #endregion // Properties

    #region Operators

    /// <summary>
    /// Returns a value that indicates whether the values of two T objects are equal.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if the <paramref name="left"/> and <paramref name="right"/> parameters have the same value; otherwise, false.</returns>
    public static bool operator ==(MemberSortingKey left, MemberSortingKey right)
    {
        return left?.Equals(right) == true;
    }

    /// <summary>
    /// Returns a value that indicates whether the values of two T objects have different values.
    /// </summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.</returns>
    public static bool operator !=(MemberSortingKey left, MemberSortingKey right)
    {
        return left?.Equals(right) != true;
    }

    /// <summary>Returns a value that indicates whether a <see cref="T:Teshigoto.Generators.Data.MemberSortingKey" /> value is less than another <see cref="T:Teshigoto.Generators.Data.MemberSortingKey" /> value.</summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is less than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator <(MemberSortingKey left, MemberSortingKey right)
    {
        return Comparer<MemberSortingKey>.Default.Compare(left, right) < 0;
    }

    /// <summary>Returns a value that indicates whether a <see cref="T:Teshigoto.Generators.Data.MemberSortingKey" /> value is greater than another <see cref="T:Teshigoto.Generators.Data.MemberSortingKey" /> value.</summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator >(MemberSortingKey left, MemberSortingKey right)
    {
        return Comparer<MemberSortingKey>.Default.Compare(left, right) > 0;
    }

    /// <summary>Returns a value that indicates whether a <see cref="T:Teshigoto.Generators.Data.MemberSortingKey" /> value is less than or equal to another <see cref="T:Teshigoto.Generators.Data.MemberSortingKey" /> value.</summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, false.</returns>
    public static bool operator <=(MemberSortingKey left, MemberSortingKey right)
    {
        return Comparer<MemberSortingKey>.Default.Compare(left, right) <= 0;
    }

    /// <summary>Returns a value that indicates whether a <see cref="T:Teshigoto.Generators.Data.MemberSortingKey" /> value is greater than or equal to another <see cref="T:Teshigoto.Generators.Data.MemberSortingKey" /> value.</summary>
    /// <param name="left">The first value to compare.</param>
    /// <param name="right">The second value to compare.</param>
    /// <returns>true if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.</returns>
    public static bool operator >=(MemberSortingKey left, MemberSortingKey right)
    {
        return Comparer<MemberSortingKey>.Default.Compare(left, right) >= 0;
    }

    #endregion // Operators

    #region IComparable

    /// <inheritdoc/>
    public int CompareTo(object obj)
    {
        if (obj is null)
        {
            return 1;
        }

        if (ReferenceEquals(this, obj))
        {
            return 0;
        }

        return obj is MemberSortingKey other
                   ? CompareTo(other)
                   : throw new ArgumentException($"Object must be of type {nameof(MemberSortingKey)}");
    }

    /// <inheritdoc/>
    public int CompareTo(MemberSortingKey other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (other is null)
        {
            return 1;
        }

        var comparisonValue = Type.CompareTo(other.Type);

        if (comparisonValue == 0)
        {
            comparisonValue = Order.CompareTo(other.Order);
        }

        return comparisonValue;
    }

    #endregion // IComparable

    #region IEquatable

    /// <inheritdoc />
    public bool Equals(MemberSortingKey other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return Type == other.Type && Order == other.Order;
    }

    #endregion // IEquatable

    #region Object

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        return ReferenceEquals(this, obj)
               || (obj is MemberSortingKey other
                   && Equals(other));
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            return ((int)Type * 397) ^ Order.GetHashCode();
        }
    }

    #endregion // Object
}