using System;
using System.Diagnostics;

namespace Teshigoto.Annotation;

/// <summary>
/// Automatic implementation of a proxy
/// </summary>
/// <typeparam name="TInterface">Type of the interface to be proxied</typeparam>
[Conditional("Teshigoto")]
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class ProxyAttribute<TInterface> : Attribute;