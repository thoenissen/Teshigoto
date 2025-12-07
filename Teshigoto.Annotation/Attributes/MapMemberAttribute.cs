using System;

namespace Teshigoto.Annotation;

/// <summary>
/// Member mapping configuration
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class MapMemberAttribute : Attribute
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="source">Source member</param>
    /// <param name="target">Target member</param>
    public MapMemberAttribute(string source, string target)
    {
        Source = source;
        Target = target;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Source member
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Target member
    /// </summary>
    public string Target { get; set; }

    /// <summary>
    /// Converter to be used to convert the source value to the target value
    /// </summary>
    public Type? Converter { get; init; }

    /// <summary>
    /// Indicates if the source value should be casted to the target type
    /// </summary>
    public bool Cast { get; init; }

    #endregion // Properties
}