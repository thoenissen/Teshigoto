namespace Teshigoto.Generators.Base;

/// <summary>
/// Writing a group
/// </summary>
internal sealed class GroupWrite : IDisposable
{
    #region Fields

    /// <summary>
    /// End
    /// </summary>
    private readonly Action _end;

    #endregion // Fields

    #region Constructor

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="start">Start</param>
    /// <param name="end">End</param>
    public GroupWrite(Action start, Action end)
    {
        _end = end;
        start();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="start">Start</param>
    /// <param name="end">End</param>
    /// <param name="value">Value</param>
    public GroupWrite(Action<string> start, Action<string> end, string value)
    {
        _end = () => end(value);
        start(value);
    }

    #endregion // Constructor

    #region IDisposable

    /// <inheritdoc />
    public void Dispose()
    {
        _end();
    }

    #endregion // IDisposable
}