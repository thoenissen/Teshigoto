using Teshigoto.Generators.Core;

namespace Teshigoto.Generators.Mapper;

/// <summary>
/// Generation of IEquatable implementation for a class
/// </summary>
internal class ClassMapperGenerator : MapperGeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Compilation meta data</param>
    public ClassMapperGenerator(CompilationMetaData metaData)
        : base(metaData)
    {
    }

    #endregion // Constructor
}