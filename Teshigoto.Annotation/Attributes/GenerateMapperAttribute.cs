using System;

namespace Teshigoto.Annotation;

/// <summary>
/// Triggers the method generation for all mapping methods with the following signature:
/// <code>
/// public static partial void Map(SourceType source, DestinationType destination);
/// </code>
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor)]
public class GenerateMapperAttribute : Attribute;