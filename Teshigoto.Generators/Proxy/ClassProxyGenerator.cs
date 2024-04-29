using Teshigoto.Generators.Core;

namespace Teshigoto.Generators.Proxy;

/// <summary>
/// Generate to generate proxy implementations of classes
/// </summary>
public class ClassProxyGenerator : ProxyGeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Meta information</param>
    internal ClassProxyGenerator(CompilationMetaData metaData)
        : base(metaData)
    {
    }

    #endregion // Constructor

}