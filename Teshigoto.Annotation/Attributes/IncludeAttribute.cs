using System;

namespace Teshigoto.Annotation;

/// <summary>
/// Mark a member to be included
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class IncludeAttribute : Attribute
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <remarks>If you use this constructor the member is included for all generators.</remarks>
    public IncludeAttribute()
    {
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <remarks>If you use this constructor the member is included for all mentioned generators.</remarks>
    /// <param name="generators">Generator which should ignore this member</param>
    public IncludeAttribute(GeneratorType[] generators)
    {
        Generators = generators;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Generators which should included this member
    /// </summary>
    public GeneratorType[]? Generators { get; }

    #endregion // Properties
}