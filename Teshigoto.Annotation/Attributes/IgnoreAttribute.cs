using System;

namespace Teshigoto.Annotation;

/// <summary>
/// Mark a property or field to be ignored
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class IgnoreAttribute : Attribute
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <remarks>If you use this constructor the member is ignored for all generators.</remarks>
    public IgnoreAttribute()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <remarks>If you use this constructor the member is ignored for all mentioned generators.</remarks>
    /// <param name="generators">Generator which should ignore this member</param>
    public IgnoreAttribute(GeneratorType[] generators)
    {
        Generators = generators;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Generators which should ignore this member
    /// </summary>
    public GeneratorType[]? Generators { get; }

    #endregion // Properties
}