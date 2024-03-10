using System;
using System.Diagnostics;

namespace Teshigoto.Annotation;

/// <summary>
/// Automatically implements the <see cref="IComparable{T}"/>-interface for the class
/// </summary>
/// <remarks>
/// You can use the <see cref="IgnoreAttribute"/> to ignore members from the implementation.
/// </remarks>
[Conditional("Teshigoto")]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
public class ComparableAttribute : Attribute
{
}