namespace Teshigoto.UnitTests.Function.Proxy;

/// <summary>
/// Test interface to be proxied
/// </summary>
internal interface IProxyTest
{
    /// <summary>
    /// Event
    /// </summary>
    event EventHandler<EventArgs> Event;

    /// <summary>
    /// Property with only a getter
    /// </summary>
    string? Property0 { get; }

    /// <summary>
    /// Property with only a setter
    /// </summary>
    string? Property1 { set; }

    /// <summary>
    /// Property with setter and getter
    /// </summary>
    string? Property2 { get; set; }

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