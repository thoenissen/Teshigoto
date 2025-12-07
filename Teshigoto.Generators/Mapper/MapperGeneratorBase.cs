using Teshigoto.Generators.Base;
using Teshigoto.Generators.Core;
using Teshigoto.Generators.Core.Extensions;

namespace Teshigoto.Generators.Mapper;

/// <summary>
/// Base class for generation IMapper implementations
/// </summary>
internal class MapperGeneratorBase : GeneratorBase
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="metaData">Compilation meta data</param>
    internal MapperGeneratorBase(CompilationMetaData metaData)
        : base(metaData)
    {
    }

    #endregion // Constructor

    #region Methods

    /// <summary>
    /// Generate
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <returns>Generated source</returns>
    public string Generate(ITypeSymbol symbol)
    {
        Initialize(symbol);

        using (WriteGroup(WriteOpenNamespaceAndParentType, WriteCloseNamespaceAndParentType))
        {
            WriteImplementation();
        }

        return BuildSourceString();
    }

    /// <summary>
    /// Write implementation
    /// </summary>
    private void WriteImplementation()
    {
        WriteDeclaredAccessibility(Symbol.DeclaredAccessibility);
        WriteLine($"partial class {Symbol.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)}");

        using (WriteBracket())
        {
            foreach (var method in GetMemberMethods())
            {
                WriteMapMethod(method);
            }
        }
    }

    /// <summary>
    /// Determines the methods to be implemented
    /// </summary>
    /// <returns>Map method</returns>
    private IEnumerable<IMethodSymbol> GetMemberMethods()
    {
        foreach (var member in Symbol.GetMembers())
        {
            if (member is IMethodSymbol
                       {
                           MethodKind: MethodKind.Ordinary,
                           DeclaredAccessibility: Accessibility.Public,
                           IsStatic: true,
                           IsPartialDefinition: true,
                           ReturnsVoid: true,
                           Name: "Map",
                           Parameters: { Length: 2 } parameters,
                       } method
                && parameters[0] is { RefKind: RefKind.In } && parameters[1] is { RefKind: RefKind.In })
            {
                yield return method;
            }
        }
    }

    /// <summary>
    /// Write map method
    /// </summary>
    /// <param name="method">Method symbol</param>
    private void WriteMapMethod(IMethodSymbol method)
    {
        var sourceArgument = method.Parameters[0];
        var targetArgument = method.Parameters[1];

        Write($"public static partial void ");
        Write(method.Name);
        Write("(in ");
        Write(sourceArgument.Type.ToFullQualifiedDisplayString());
        Write(" ");
        Write(sourceArgument.Name);
        Write(", in ");
        Write(targetArgument.Type.ToFullQualifiedDisplayString());
        Write(" ");
        Write(targetArgument.Name);
        WriteLine(")");

        using (WriteBracket())
        {
            var gettableMembers = targetArgument.Type.GetMembers().Where(IsGettable).ToList();

            foreach (var targetMember in targetArgument.Type.GetMembers().Where(IsAssignable))
            {
                var sourceMember = gettableMembers.FirstOrDefault(x => x.Name == targetMember.Name);

                if (sourceMember == null)
                {
                    WriteLine($"#error No source member for {targetMember.Name} found.");
                    continue;
                }

                Write(targetArgument.Name);
                Write(".");
                Write(targetMember.Name);
                Write(" = ");
                Write(sourceArgument.Name);
                Write(".");
                Write(sourceMember.Name);
                WriteLine(";");
            }
        }
    }

    /// <summary>
    /// Checks whether the source member is gettable
    /// </summary>
    /// <param name="sourceMember">Source member</param>
    /// <returns>Is the member gettable?</returns>
    private bool IsGettable(ISymbol sourceMember)
    {
        return sourceMember is IPropertySymbol { GetMethod: not null } or IFieldSymbol { IsImplicitlyDeclared: false };
    }

    /// <summary>
    /// Checks whether the target member is assignable
    /// </summary>
    /// <param name="targetMember">Target member</param>
    /// <returns>Is the member assignable?</returns>
    private bool IsAssignable(ISymbol targetMember)
    {
        return targetMember is IPropertySymbol { SetMethod: not null } or IFieldSymbol { IsImplicitlyDeclared: false };
    }

    #endregion // Methods
}