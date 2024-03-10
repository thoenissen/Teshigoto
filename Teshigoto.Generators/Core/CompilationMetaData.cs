using Teshigoto.Annotation;

namespace Teshigoto.Generators.Core;

/// <summary>
/// Meta information about the current compilation
/// </summary>
internal class CompilationMetaData
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="compilation">Compilation</param>
    public CompilationMetaData(Compilation compilation)
    {
        EquatableAttribute = compilation.GetTypeByMetadataName(typeof(EquableAttribute).FullName!);
        ComparableAttribute = compilation.GetTypeByMetadataName(typeof(ComparableAttribute).FullName!);
        IgnoreAttribute = compilation.GetTypeByMetadataName(typeof(IgnoreAttribute).FullName!);
        IncludeAttribute = compilation.GetTypeByMetadataName(typeof(IncludeAttribute).FullName!);
        OrderAttribute = compilation.GetTypeByMetadataName(typeof(OrderAttribute).FullName!);
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Symbol information of <see cref="EquableAttribute"/>
    /// </summary>
    public INamedTypeSymbol EquatableAttribute { get; }

    /// <summary>
    /// Symbol information of <see cref="ComparableAttribute"/>
    /// </summary>
    public INamedTypeSymbol ComparableAttribute { get; set; }

    /// <summary>
    /// Symbol information of <see cref="IgnoreAttribute"/>
    /// </summary>
    public INamedTypeSymbol IgnoreAttribute { get; }

    /// <summary>
    /// Symbol information of <see cref="IncludeAttribute"/>
    /// </summary>
    public INamedTypeSymbol IncludeAttribute { get; }

    /// <summary>
    /// Symbol information of <see cref="OrderAttribute"/>
    /// </summary>
    public INamedTypeSymbol OrderAttribute { get; set; }

    #endregion // Properties
}