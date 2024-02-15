using System;
using System.Diagnostics;

namespace Teshigoto.Annotation;

/// <summary>
/// Automatically implements the <see cref="IEquatable{T}"/>-interface for the class
/// </summary>
[Conditional("Teshigoto")]
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class EquableAttribute : Attribute
{
}