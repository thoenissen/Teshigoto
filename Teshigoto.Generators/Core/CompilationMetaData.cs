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
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Symbol information of <see cref="EquableAttribute"/>
    /// </summary>
    public INamedTypeSymbol EquatableAttribute { get; }

    #endregion // Properties
}