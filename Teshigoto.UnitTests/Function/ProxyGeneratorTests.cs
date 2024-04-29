using System.Runtime.CompilerServices;

using Teshigoto.Generators;
using Teshigoto.UnitTests.Function.Proxy;

namespace Teshigoto.UnitTests.Function;

/// <summary>
/// Function tests of generated source by <see cref="ProxyGenerator"/>
/// </summary>
[TestClass]
public class ProxyGeneratorTests
{
    #region Helper method

    /// <summary>
    /// Get the implementation field
    /// </summary>
    /// <param name="proxy">Proxy object</param>
    /// <returns>Value of the field</returns>
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_implementation")]
    private static extern ref IProxyTest GetImplementation(ProxyTest.Proxy proxy);

    #endregion // Helper method

    #region Tests

    /// <summary>
    /// Resolving implementation
    /// </summary>
    [TestMethod]
    public void Resolve()
    {
        var proxyObject = new ProxyTest.Proxy();
        var proxyInterface = (IProxyTest)proxyObject;

        var implementation = GetImplementation(proxyObject);

        Assert.IsNotNull(implementation);
        Assert.IsNotInstanceOfType(implementation, typeof(ProxyTest));

        // Dummy call to create implementation
        proxyInterface.MethodString();

        implementation = GetImplementation(proxyObject);

        Assert.IsNotNull(implementation);
        Assert.IsInstanceOfType(implementation, typeof(ProxyTest));
    }

    /// <summary>
    /// Set only properties
    /// </summary>
    [TestMethod]
    public void SetOnlyProperty()
    {
        var proxyObject = new ProxyTest.Proxy();
        var proxyInterface = (IProxyTest)proxyObject;

        // Dummy call to create implementation
        proxyInterface.MethodString();

        var implementation = (ProxyTest)GetImplementation(proxyObject);

        proxyInterface.Property1 = "TestValue1";

        Assert.AreEqual("TestValue1", implementation.Property1);

        proxyInterface.Property1 = "TestValue2";

        Assert.AreEqual("TestValue2", implementation.Property1);
    }

    /// <summary>
    /// Get only properties
    /// </summary>
    [TestMethod]
    public void GetOnlyProperty()
    {
        var proxyObject = new ProxyTest.Proxy();
        var proxyInterface = (IProxyTest)proxyObject;

        // Dummy call to create implementation
        proxyInterface.MethodString();

        var implementation = (ProxyTest)GetImplementation(proxyObject);

        implementation.Property0 = "TestValue1";

        Assert.AreEqual("TestValue1", proxyInterface.Property0);

        implementation.Property0 = "TestValue2";

        Assert.AreEqual("TestValue2", proxyInterface.Property0);
    }

    /// <summary>
    /// Set and get properties
    /// </summary>
    [TestMethod]
    public void GetAndSetProperty()
    {
        var proxyObject = new ProxyTest.Proxy();
        var proxyInterface = (IProxyTest)proxyObject;

        proxyInterface.Property2 = "TestValue1";

        Assert.AreEqual("TestValue1", proxyInterface.Property2);

        proxyInterface.Property2 = "TestValue2";

        Assert.AreEqual("TestValue2", proxyInterface.Property2);
    }

    /// <summary>
    /// Method call
    /// </summary>
    [TestMethod]
    public void Method()
    {
        var proxyObject = new ProxyTest.Proxy();
        var proxyInterface = (IProxyTest)proxyObject;

        // Dummy call to create implementation
        proxyInterface.MethodString();

        var implementation = (ProxyTest)GetImplementation(proxyObject);
        var value1 = "Value1";

        proxyInterface.MethodVoid("Value0", ref value1, out var value2);

        Assert.IsTrue(implementation.IsMethodVoidCalled);
        Assert.AreEqual("Value0", implementation.MethodVoidValue0);
        Assert.AreEqual("Value1", implementation.MethodVoidValue1);
        Assert.AreEqual("RefValue1", value1);
        Assert.AreEqual("OutValue2", value2);

        Assert.AreEqual("ReturnValue", proxyInterface.MethodString());
    }

    /// <summary>
    /// Event
    /// </summary>
    [TestMethod]
    public void Event()
    {
        var proxyObject = new ProxyTest.Proxy();
        var proxyInterface = (IProxyTest)proxyObject;

        // Dummy call to create implementation
        proxyInterface.MethodString();

        var implementation = (ProxyTest)GetImplementation(proxyObject);

        var isCalled = false;

        // Register
        proxyInterface.Event += OnProxyInterfaceEvent;

        implementation.RaiseEvent();

        Assert.IsTrue(isCalled);

        // Unregister
        proxyInterface.Event -= OnProxyInterfaceEvent;

        isCalled = false;

        Assert.IsFalse(isCalled);

        // Register
        proxyInterface.Event += OnProxyInterfaceEvent;

        implementation.RaiseEvent();

        Assert.IsTrue(isCalled);

        return;

        void OnProxyInterfaceEvent(object? sender, EventArgs e) => isCalled = true;
    }

    #endregion // Tests
}