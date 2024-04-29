using Teshigoto.Annotation;

namespace Teshigoto.UnitTests.Function.Proxy;

/// <summary>
/// Test class to be proxied
/// </summary>
[Proxy<IProxyTest>]
internal partial class ProxyTest : IProxyTest
{
    #region Events

    /// <inheritdoc />
    public event EventHandler<EventArgs>? Event;

    #endregion // Events

    #region Properties

    /// <inheritdoc />
    public string? Property0 { get; set; }

    /// <inheritdoc />
    public string? Property1 { get; set; }

    /// <inheritdoc />
    public string? Property2 { get; set; }

    /// <summary>
    /// Is <see cref="MethodVoid(string, ref string, out string)"/> being called?
    /// </summary>
    public bool IsMethodVoidCalled { get; set; }

    /// <summary>
    /// Value of parameter value0 of <see cref="MethodVoid(string, ref string, out string)"/>
    /// </summary>
    public string? MethodVoidValue0 { get; set; }

    /// <summary>
    /// Value of parameter value1 <see cref="MethodVoid(string, ref string, out string)"/>
    /// </summary>
    public string? MethodVoidValue1 { get; set; }

    /// <summary>
    /// Is <see cref="MethodString"/> being called?
    /// </summary>
    public bool IsMethodStringCalled { get; set; }

    #endregion // Properties

    #region Methods

    /// <inheritdoc />
    public void MethodVoid(string value0, ref string value1, out string value2)
    {
        IsMethodVoidCalled = true;
        MethodVoidValue0 = value0;
        MethodVoidValue1 = value1;

        value1 = "RefValue1";
        value2 = "OutValue2";
    }

    /// <inheritdoc />
    public string MethodString()
    {
        IsMethodStringCalled = true;

        return "ReturnValue";
    }

    /// <summary>
    /// Raise <see cref="Event"/>
    /// </summary>
    public void RaiseEvent()
    {
        Event?.Invoke(this, EventArgs.Empty);
    }

    #endregion // Methods
}