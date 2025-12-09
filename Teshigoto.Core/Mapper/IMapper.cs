namespace Teshigoto.Core.Mapper;

/// <summary>
/// Mapping values from one object to another object
/// </summary>
/// <typeparam name="TFrom">Source object type</typeparam>
/// <typeparam name="TTo">Target object type</typeparam>
internal interface IMapper<in TFrom, in TTo>
{
    /// <summary>
    /// Mapping values from <paramref name="from"/> to <paramref name="to"/>
    /// </summary>
    /// <param name="from">Source object</param>
    /// <param name="to">Target object</param>
    public static abstract void Map(TFrom from, TTo to);
}