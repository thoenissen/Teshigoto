namespace Teshigoto.CompilationTests.Interfaces;

/// <summary>
/// Factory to create test objects
/// </summary>
/// <typeparam name="TObject">Type of the object to be created</typeparam>
/// <typeparam name="TValue1">Type of the first argument</typeparam>
/// <typeparam name="TValue2">Type of the second argument</typeparam>
/// <typeparam name="TValue3">Type of the third argument</typeparam>
public interface IFactory<out TObject, in TValue1, in TValue2, in TValue3>
{
    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value1">Value 1</param>
    /// <param name="value2">Value 2</param>
    /// <param name="value3">Value 3</param>
    /// <returns>Created value</returns>
    static abstract TObject Create(TValue1 value1, TValue2 value2, TValue3 value3);
}