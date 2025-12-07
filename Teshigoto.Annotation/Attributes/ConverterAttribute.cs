using System;

using Teshigoto.Core.Mapper;

namespace Teshigoto.Annotation;

/// <summary>
/// Registration of converters
/// </summary>
/// <typeparam name="TConverter">Type of the converter</typeparam>
/// <typeparam name="TFrom">Type source of the source value</typeparam>
/// <typeparam name="TTo">Type of the target value</typeparam>
public class ConverterAttribute<TConverter, TFrom, TTo> : Attribute
    where TConverter : IConverter<TFrom, TTo>;