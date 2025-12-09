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
        Compilation = compilation;
        EquatableAttribute = compilation.GetTypeByMetadataName("Teshigoto.Annotation.EquableAttribute");
        ComparableAttribute = compilation.GetTypeByMetadataName("Teshigoto.Annotation.ComparableAttribute");
        IgnoreAttribute = compilation.GetTypeByMetadataName("Teshigoto.Annotation.IgnoreAttribute");
        IncludeAttribute = compilation.GetTypeByMetadataName("Teshigoto.Annotation.IncludeAttribute");
        OrderAttribute = compilation.GetTypeByMetadataName("Teshigoto.Annotation.OrderAttribute");
        ProxyAttribute = compilation.GetTypeByMetadataName("Teshigoto.Annotation.ProxyAttribute`1")!.ConstructUnboundGenericType();
        GenerateMapperAttribute = compilation.GetTypeByMetadataName("Teshigoto.Annotation.GenerateMapperAttribute");
        MapMemberAttribute = compilation.GetTypeByMetadataName("Teshigoto.Annotation.MapMemberAttribute");
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Current compilation
    /// </summary>
    public Compilation Compilation { get; set; }

    /// <summary>
    /// Symbol information of EquableAttribute
    /// </summary>
    public INamedTypeSymbol EquatableAttribute { get; }

    /// <summary>
    /// Symbol information of ComparableAttribute
    /// </summary>
    public INamedTypeSymbol ComparableAttribute { get; set; }

    /// <summary>
    /// Symbol information of IgnoreAttribute
    /// </summary>
    public INamedTypeSymbol IgnoreAttribute { get; }

    /// <summary>
    /// Symbol information of IncludeAttribute
    /// </summary>
    public INamedTypeSymbol IncludeAttribute { get; }

    /// <summary>
    /// Symbol information of OrderAttribute
    /// </summary>
    public INamedTypeSymbol OrderAttribute { get; set; }

    /// <summary>
    /// Symbol information of ProxyAttribute{T}
    /// </summary>
    public INamedTypeSymbol ProxyAttribute { get; set; }

    /// <summary>
    /// Symbol information of GenerateMapperAttribute
    /// </summary>
    public INamedTypeSymbol GenerateMapperAttribute { get; set; }

    /// <summary>
    /// Symbol information of MapMemberAttribute
    /// </summary>
    public INamedTypeSymbol MapMemberAttribute { get; set; }

    #endregion // Properties
}