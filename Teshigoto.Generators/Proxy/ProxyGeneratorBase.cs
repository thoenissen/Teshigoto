using Teshigoto.Generators.Base;
using Teshigoto.Generators.Core.Extensions;

namespace Teshigoto.Generators.Proxy;

/// <summary>
/// Base class for generating proxy implementations
/// </summary>
public abstract class ProxyGeneratorBase : GeneratorBase
{
    #region Properties

    /// <summary>
    /// Interface symbol to be proxied
    /// </summary>
    protected ITypeSymbol InterfaceSymbol { get; private set; }

    /// <summary>
    /// Fully qualified name of the interface symbol
    /// </summary>
    protected string InterfaceSymbolName { get; private set; }

    #endregion // Properties

    #region Methods

    /// <summary>
    /// Generate implementation
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="proxyAttributeData">Attribute data</param>
    /// <returns>Generated source code</returns>
    public string Generate(ITypeSymbol symbol, AttributeData proxyAttributeData)
    {
        Initialize(symbol, proxyAttributeData);

        using (WriteGroup(WriteOpenNamespace, WriteCloseNamespaceAndParentType))
        {
            // _IProxy
            WriteProxyInterface();

            // _Resolver
            WriteResolver();

            // partial class
            WriteOpenParentTypes();

            // Proxy
            WriteProxy();
        }

        return BuildSourceString();
    }

    #region Methods

    /// <summary>
    /// Write _IProxy
    /// </summary>
    private void WriteProxyInterface()
    {
        using (WriteRegion("_IProxy"))
        {
            WriteXmlDocSummary("Internal proxy interface");
            WriteGeneratedCodeAttribute();
            WriteLine("file interface _IProxy");

            using (WriteBracket())
            {
                WriteXmlDocSummary("Implementation");
                Write("public ");
                Write(InterfaceSymbolName);
                WriteLine(" Implementation { get; set; }");
            }
        }

        WriteLine();
    }

    /// <summary>
    /// Write _Resolver
    /// </summary>
    private void WriteResolver()
    {
        // Class definition
        using (WriteRegion("_Resolver"))
        {
            WriteXmlDocSummary("Temporary implementation to intercept the calls to resolve the implementation object");
            WriteGeneratedCodeAttribute();
            Write("file class _Resolver : ");
            WriteLine(InterfaceSymbolName);

            using (WriteBracket())
            {
                // Fields
                using (WriteRegion("Fields"))
                {
                    WriteXmlDocSummary("Proxy assigned to the resolver");
                    WriteLine("private _IProxy _proxy;");
                }

                WriteLine();

                // Constructor
                using (WriteRegion("Constructor"))
                {
                    WriteXmlDocSummary("Constructor");
                    WriteXmlDocParameter("proxy", "Proxy object");
                    WriteLine("public _Resolver(_IProxy proxy)");

                    using (WriteBracket())
                    {
                        WriteLine("_proxy = proxy;");
                    }
                }

                WriteLine();

                // Methods
                using (WriteRegion("Methods"))
                {
                    WriteXmlDocSummary("Resolving the implementation object");
                    WriteLine("private void Resolve()");

                    using (WriteBracket())
                    {
                        WriteLine("lock (this)");

                        using (WriteBracket())
                        {
                            WriteLine("if (_proxy.Implementation == this)");

                            using (WriteBracket())
                            {
                                Write("_proxy.Implementation = new ");
                                Write(SymbolName);
                                WriteLine("();");
                            }
                        }
                    }
                }

                // Interface implementation
                WriteMembers(true);
            }
        }

        WriteLine();
    }

    /// <summary>
    /// Write Proxy
    /// </summary>
    private void WriteProxy()
    {
        // Class definition
        WriteXmlDocSummary($"Proxy of <see cref=\"{SymbolName}\"/> which implements <see cref=\"{InterfaceSymbolName}\"/>");
        WriteGeneratedCodeAttribute();
        WriteDeclaredAccessibility(Symbol.DeclaredAccessibility);
        Write("class Proxy : ");
        Write(InterfaceSymbolName);
        WriteLine(",");
        WriteLine("                       _IProxy");

        using (WriteBracket())
        {
            // Fields
            using (WriteRegion("Fields"))
            {
                WriteXmlDocSummary($"Implementation of <see cref=\"{InterfaceSymbolName}\"/>");
                WriteLine($"private {InterfaceSymbolName} _implementation;");
            }

            WriteLine();

            // Constructor
            using (WriteRegion("Constructor"))
            {
                WriteXmlDocSummary("Constructor");
                WriteLine("public Proxy()");

                using (WriteBracket())
                {
                    WriteLine("_implementation = new _Resolver(this);");
                }
            }

            WriteLine();

            // _IProxy
            using (WriteRegion("_IProxy"))
            {
                WriteLine("/// <inheritdoc />");
                Write(InterfaceSymbolName);
                WriteLine(" _IProxy.Implementation");
                WriteLine("{");
                WriteLine("    get => _implementation;");
                WriteLine("    set => _implementation = value;");
                WriteLine("}");
            }

            // Interface implementation
            WriteMembers(false);
        }
    }

    /// <summary>
    /// Writer member implementation
    /// </summary>
    /// <param name="isResolver">Are the member of the resolver be generated?</param>
    private void WriteMembers(bool isResolver)
    {
        foreach (var interfaceSymbol in GetInterfaces(InterfaceSymbol))
        {
            var interfaceSymbolName = interfaceSymbol.ToFullQualifiedDisplayString();

            WriteLine();

            using (WriteRegion(interfaceSymbolName))
            {
                foreach (var member in interfaceSymbol.GetMembers())
                {
                    switch (member)
                    {
                        case IPropertySymbol propertySymbol:
                            WriteProperty(isResolver, propertySymbol, interfaceSymbolName);
                            break;

                        case IMethodSymbol methodSymbol:
                            WriteMethod(isResolver, methodSymbol, interfaceSymbolName);
                            break;

                        case IEventSymbol eventSymbol:
                            WriteEvent(isResolver, eventSymbol, interfaceSymbolName);
                            break;

                        default:
                            WriteLine($"#error Member {member.Name} is not supported");
                            break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Write property implementation
    /// </summary>
    /// <param name="isResolver">Is this the implementation of the _Resolver class?</param>
    /// <param name="propertySymbol">Property symbol</param>
    /// <param name="interfaceSymbolName">Interface symbol name</param>
    private void WriteProperty(bool isResolver, IPropertySymbol propertySymbol, string interfaceSymbolName)
    {
        WriteLine("/// <inheritdoc />");
        Write(propertySymbol.Type.ToFullQualifiedDisplayString());
        Write(" ");
        Write(interfaceSymbolName);
        Write(".");
        WriteLine(propertySymbol.Name);

        using (WriteBracket())
        {
            if (propertySymbol.GetMethod != null)
            {
                if (isResolver)
                {
                    WriteLine("get");

                    using (WriteBracket())
                    {
                        WriteLine("Resolve();");
                        WriteLine();
                        Write("return _proxy.Implementation.");
                        Write(propertySymbol.Name);
                        WriteLine(";");
                    }
                }
                else
                {
                    Write("get => _implementation.");
                    Write(propertySymbol.Name);
                    WriteLine(";");
                }
            }

            if (propertySymbol.SetMethod != null)
            {
                if (isResolver)
                {
                    WriteLine("set");

                    using (WriteBracket())
                    {
                        WriteLine("Resolve();");
                        WriteLine();
                        Write("_proxy.Implementation.");
                        Write(propertySymbol.Name);
                        WriteLine(" = value;");
                    }
                }
                else
                {
                    Write("set => _implementation.");
                    Write(propertySymbol.Name);
                    WriteLine(" = value;");
                }
            }
        }

        WriteLine();
    }

    /// <summary>
    /// Write the method implementation
    /// </summary>
    /// <param name="isResolver">Is this the implementation of the _Resolver class?</param>
    /// <param name="methodSymbol">Method symbol</param>
    /// <param name="interfaceSymbolName">Interface symbol name</param>
    private void WriteMethod(bool isResolver, IMethodSymbol methodSymbol, string interfaceSymbolName)
    {
        if (methodSymbol.MethodKind != MethodKind.Ordinary)
        {
            return;
        }

        WriteLine("/// <inheritdoc />");
        Write(methodSymbol.ReturnType.ToFullQualifiedDisplayString());
        Write(" ");
        Write(interfaceSymbolName);
        Write(".");
        Write(methodSymbol.Name);
        Write("(");

        if (methodSymbol.Parameters.Length > 0)
        {
            WriteParameter(methodSymbol.Parameters[0], true);

            foreach (var parameter in methodSymbol.Parameters.Skip(1))
            {
                Write(", ");
                WriteParameter(parameter, true);
            }
        }

        WriteLine(")");

        using (WriteBracket())
        {
            if (isResolver)
            {
                WriteLine("Resolve();");
                WriteLine();
            }

            if (methodSymbol.ReturnsVoid == false)
            {
                Write("return ");
            }

            Write(isResolver ? "_proxy.Implementation." : "_implementation.");

            Write(methodSymbol.Name);
            Write("(");

            if (methodSymbol.Parameters.Length > 0)
            {
                WriteParameter(methodSymbol.Parameters[0], false);

                foreach (var parameter in methodSymbol.Parameters.Skip(1))
                {
                    Write(", ");
                    WriteParameter(parameter, false);
                }
            }

            WriteLine(");");
        }

        WriteLine();
    }

    /// <summary>
    /// Write event implementation
    /// </summary>
    /// <param name="isResolver">Is this the implementation of the _Resolver class?</param>
    /// <param name="eventSymbol">Event symbol</param>
    /// <param name="interfaceSymbolName">Interface symbol name</param>
    private void WriteEvent(bool isResolver, IEventSymbol eventSymbol, string interfaceSymbolName)
    {
        WriteLine("/// <inheritdoc />");
        Write("event ");
        Write(eventSymbol.Type.ToFullQualifiedDisplayString());
        Write(" ");
        Write(interfaceSymbolName);
        Write(".");
        WriteLine(eventSymbol.Name);

        using (WriteBracket())
        {
            if (isResolver)
            {
                WriteLine("add");

                using (WriteBracket())
                {
                    WriteLine("Resolve();");
                    WriteLine();
                    Write("_proxy.Implementation.");
                    Write(eventSymbol.Name);
                    WriteLine(" += value;");
                }
            }
            else
            {
                Write("add => _implementation.");
                Write(eventSymbol.Name);
                WriteLine(" += value;");
            }

            if (isResolver)
            {
                WriteLine("remove");

                using (WriteBracket())
                {
                    WriteLine("Resolve();");
                    WriteLine();
                    Write("_proxy.Implementation.");
                    Write(eventSymbol.Name);
                    WriteLine(" += value;");
                }
            }
            else
            {
                Write("remove => _implementation.");
                Write(eventSymbol.Name);
                WriteLine(" += value;");
            }
        }

        WriteLine();
    }

    /// <summary>
    /// Write a parameter
    /// </summary>
    /// <param name="parameter">Parameter</param>
    /// <param name="withType">Including the type?</param>
    private void WriteParameter(IParameterSymbol parameter, bool withType)
    {
        var refKind = parameter.RefKind switch
                      {
                          RefKind.None => string.Empty,
                          RefKind.Ref => "ref ",
                          RefKind.Out => "out ",
                          RefKind.In => "in ",
                          RefKind.RefReadOnlyParameter => "ref readonly ",
                          _ => $"#error The given ref type '{parameter.RefKind}' is not supported\r\n"
                      };

        Write(refKind);

        if (withType)
        {
            Write(parameter.Type.ToFullQualifiedDisplayString());
            Write(" ");
        }

        Write(parameter.Name);
    }

    #endregion // Methods

    #endregion // Methods

    #region GeneratorBase

    /// <summary>
    /// Initialize the generator
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="proxyAttributeData">Proxy attribute data</param>
    protected void Initialize(ITypeSymbol symbol, AttributeData proxyAttributeData)
    {
        Initialize(symbol);

        InterfaceSymbol = proxyAttributeData.AttributeClass!.TypeArguments[0];
        InterfaceSymbolName = InterfaceSymbol.ToFullQualifiedDisplayString();
    }

    #endregion // GeneratorBase
}