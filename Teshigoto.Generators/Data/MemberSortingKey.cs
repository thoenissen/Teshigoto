using Teshigoto.Generators.Enumerations;

namespace Teshigoto.Generators.Data;

/// <summary>
/// Member sorting key
/// </summary>
internal class MemberSortingKey : IComparable<MemberSortingKey>,
                                  IComparable
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

    #region IComparable

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
}