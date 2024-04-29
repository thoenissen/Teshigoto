#pragma warning disable CS0067
#pragma warning disable SA1402

using System;

using Teshigoto.Annotation;

namespace Teshigoto.CompilationTests.Proxy;

/// <summary>
/// Test base interface to be proxied
/// </summary>
internal interface IInterfaceBase
{
    /// <summary>
    /// Event
    /// </summary>
    event EventHandler<EventArgs> BaseEvent;

    /// <summary>
    /// Property with only a getter
    /// </summary>
    string? BaseProperty0 { get; }

    /// <summary>
    /// Property with only a setter
    /// </summary>
    string? BaseProperty1 { set; }

    /// <summary>
    /// Property with setter and getter
    /// </summary>
    string? BaseProperty2 { get; set; }

    /// <summary>
    /// Method without return value
    /// </summary>
    /// <param name="value0">Value 0</param>
    /// <param name="value1">Value 1</param>
    /// <param name="value2">Value 2</param>
    void BaseMethodVoid(string? value0, ref string? value1, out string? value2);

    /// <summary>
    /// Method with string return value
    /// </summary>
    /// <returns>String</returns>
    string? BaseMethodString();
}

/// <summary>
/// Test interface to be proxied
/// </summary>
internal interface IInterface : IInterfaceBase
{
    /// <summary>
    /// Event
    /// </summary>
    event EventHandler<EventArgs> Event;

    /// <summary>
    /// Property with only a getter
    /// </summary>
    string Property0 { get; }

    /// <summary>
    /// Property with only a setter
    /// </summary>
    string Property1 { set; }

    /// <summary>
    /// Property with setter and getter
    /// </summary>
    string Property2 { get; set; }

    /// <summary>
    /// Method without return value
    /// </summary>
    /// <param name="value0">Value 0</param>
    /// <param name="value1">Value 1</param>
    /// <param name="value2">Value 2</param>
    void MethodVoid(string value0, ref string value1, out string value2);

    /// <summary>
    /// Method with string return value
    /// </summary>
    /// <returns>String</returns>
    string MethodString();
}

/// <summary>
/// Test implementation
/// </summary>
[Proxy<IInterface>]
internal partial class Class : IInterface
{
    /// <inheritdoc />
    public event EventHandler<EventArgs>? BaseEvent;

    /// <inheritdoc />
    public event EventHandler<EventArgs>? Event;

    /// <inheritdoc />
    public string? BaseProperty0 { get; set; }

    /// <inheritdoc />
    public string? BaseProperty1 { get; set; }

    /// <inheritdoc />
    public string? BaseProperty2 { get; set; }

    /// <inheritdoc />
    public string Property0 { get; set; } = string.Empty;

    /// <inheritdoc />
    public string Property1 { get; set; } = string.Empty;

    /// <inheritdoc />
    public string Property2 { get; set; } = string.Empty;

    /// <inheritdoc />
    public void BaseMethodVoid(string? value0, ref string? value1, out string? value2)
    {
        value2 = null;
    }

    /// <inheritdoc />
    public string? BaseMethodString()
    {
        return null;
    }

    /// <inheritdoc />
    public void MethodVoid(string value0, ref string value1, out string value2)
    {
        value2 = string.Empty;
    }

    /// <inheritdoc />
    public string MethodString()
    {
        return string.Empty;
    }
}