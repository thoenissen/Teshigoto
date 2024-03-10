namespace Teshigoto.CompilationTests.Interfaces;

/// <summary>
/// Factory to create test objects
/// </summary>
/// <typeparam name="TObject">Type of the object to be created</typeparam>
/// <typeparam name="TValue">Type of the argument</typeparam>
public interface IOneValueFactory<out TObject, in TValue>
{
    /// <summary>
    /// Create new instance
    /// </summary>
    /// <param name="value">Value</param>
    /// <returns>Created value</returns>
    static abstract TObject Create(TValue value);
}