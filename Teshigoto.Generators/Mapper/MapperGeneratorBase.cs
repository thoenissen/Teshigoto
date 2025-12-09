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
                && parameters[0] is { RefKind: RefKind.None } && parameters[1] is { RefKind: RefKind.None })
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

        Write("public static partial void ");
        Write(method.Name);
        Write("(");
        Write(sourceArgument.Type.ToFullQualifiedDisplayString());
        Write(" ");
        Write(sourceArgument.Name);
        Write(", ");
        Write(targetArgument.Type.ToFullQualifiedDisplayString());
        Write(" ");
        Write(targetArgument.Name);
        WriteLine(")");

        using (WriteBracket())
        {
            var gettableMembers = sourceArgument.Type.GetMembers().Where(IsGettable).ToList();

            foreach (var targetMember in targetArgument.Type.GetMembers().Where(IsAssignable))
            {
                var mappingInformation = GetMappingInformation(method, targetMember);
                var sourceMember = gettableMembers.Find(x => x.Name == mappingInformation.SourceName);

                if (sourceMember == null)
                {
                    WriteLine($"#error No source member for {targetMember.Name} found.");
                    continue;
                }

                if (mappingInformation.Converter != null)
                {
                    Write(targetArgument.Name);
                    Write(".");
                    Write(targetMember.Name);
                    Write(" = ");
                    Write(mappingInformation.Converter.ToFullQualifiedDisplayString());
                    Write(".Convert(");
                    Write(sourceArgument.Name);
                    Write(".");
                    Write(sourceMember.Name);
                    WriteLine(");");
                }
                else if (mappingInformation.Cast)
                {
                    Write(targetArgument.Name);
                    Write(".");
                    Write(targetMember.Name);
                    Write(" = (");
                    Write(targetMember.GetFieldOrPropertyType().ToFullQualifiedDisplayString());
                    Write(")");
                    Write(sourceArgument.Name);
                    Write(".");
                    Write(sourceMember.Name);
                    WriteLine(";");
                }
                else
                {
                    var conversion = MetaData.Compilation.ClassifyConversion(sourceMember.GetFieldOrPropertyType(), targetMember.GetFieldOrPropertyType());

                    if (conversion.Exists
                        || conversion.IsImplicit)
                    {
                        Write(targetArgument.Name);
                        Write(".");
                        Write(targetMember.Name);
                        Write(" = ");
                        Write(sourceArgument.Name);
                        Write(".");
                        Write(sourceMember.Name);
                        WriteLine(";");
                    }
                    else
                    {
                        WriteLine($"#error The member {sourceArgument.Name}.{targetMember.Name} can't be implicit converter to the type of {targetArgument.Name}{sourceMember.Name}.");
                    }
                }
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

    /// <summary>
    /// Get mapping information
    /// </summary>
    /// <param name="method">Mapping method</param>
    /// <param name="targetMember">Target member</param>
    /// <returns>Mapping information</returns>
    private MappingInformation GetMappingInformation(IMethodSymbol method, ISymbol targetMember)
    {
        var mappingInformation = default(MappingInformation);

        var attribute = method.GetAttributes().FirstOrDefault(attribute => SymbolEqualityComparer.Default.Equals(attribute.AttributeClass, MetaData.MapMemberAttribute)
                                                                           && attribute.ConstructorArguments.Length >= 2
                                                                           && attribute.ConstructorArguments[1].Value?.Equals(targetMember.Name) == true);

        if (attribute != null)
        {
            mappingInformation.SourceName = attribute.ConstructorArguments[0].Value?.ToString();

            var converterArgument = attribute.NamedArguments.FirstOrDefault(kv => kv.Key == "Converter");

            if (converterArgument.Value.Equals(default) == false
                && converterArgument.Value.Value is INamedTypeSymbol converterType)
            {
                mappingInformation.Converter = converterType;
            }

            var castArgument = attribute.NamedArguments.FirstOrDefault(kv => kv.Key == "Cast");

            if (castArgument.Value.Equals(default) == false
                && castArgument.Value.Value is bool cast)
            {
                mappingInformation.Cast = cast;
            }
        }
        else
        {
            mappingInformation.SourceName = targetMember.Name;
        }

        return mappingInformation;
    }

    #endregion // Methods
}