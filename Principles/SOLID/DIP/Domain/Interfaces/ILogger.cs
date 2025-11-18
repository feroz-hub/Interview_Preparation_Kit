namespace DIP.Domain.Interfaces;

/// <summary>
/// Abstraction for logging; high-level modules depend on this, not concrete loggers.
/// </summary>
public interface ILogger
{
    void Log(string message);
}
