using System;

namespace Teshigoto.Annotation;

/// <summary>
/// Set the order number of a member
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class OrderAttribute : Attribute
{
    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="order">Order number</param>
    /// <remarks>If you use this constructor the order number is valid for all generators.</remarks>
    public OrderAttribute(long order)
    {
        Order = order;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="order">Order number</param>
    /// <remarks>If you use this constructor the order number is valid for all mentioned generators.</remarks>
    /// <param name="generators">Generator which should ignore this member</param>
    public OrderAttribute(GeneratorType[] generators, long order)
    {
        Order = order;
        Generators = generators;
    }

    #endregion // Constructor

    #region Properties

    /// <summary>
    /// Generators which should ignore this member
    /// </summary>
    public GeneratorType[]? Generators { get; }

    /// <summary>
    /// Order
    /// </summary>
    public long Order { get; set; }

    #endregion // Properties
}