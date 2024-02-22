using Teshigoto.Annotation;

namespace Teshigoto.Generators.Enumerations;

/// <summary>
/// Typ of sorting key
/// </summary>
internal enum MemberSortingType
{
    /// <summary>
    /// Defined by <see cref="OrderAttribute"/>
    /// </summary>
    Attribute,

    /// <summary>
    /// Defined by location in the source code
    /// </summary>
    Location
}