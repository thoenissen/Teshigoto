namespace Teshigoto.Generators.Enumerations;

/// <summary>
/// Typ of sorting key
/// </summary>
internal enum MemberSortingType
{
    /// <summary>
    /// Defined by OrderAttribute
    /// </summary>
    Attribute,

    /// <summary>
    /// Defined by location in the source code
    /// </summary>
    Location
}