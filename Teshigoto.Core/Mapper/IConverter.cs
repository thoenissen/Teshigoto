namespace Teshigoto.Core.Mapper;

/// <summary>
/// Converter from one type to another type
/// </summary>
/// <typeparam name="TFrom">Source type</typeparam>
/// <typeparam name="TTo">Target type</typeparam>
public interface IConverter<in TFrom, out TTo>
{
    /// <summary>
    /// Converts a value of type TFrom to a value of type TTo
    /// </summary>
    /// <param name="from">The value to convert</param>
    /// <returns>A value of type TTo that represents the converted form of the input</returns>
    public static abstract TTo Convert(TFrom from);
}