using DIP.Domain.Interfaces;

namespace DIP.Infrastructure.Logging;


/// <summary>
/// Low-level detail: simulate logging to a database.
/// In real scenarios, this would insert into a table.
/// </summary>
public sealed class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] DB: {message}";
        // Simulate DB write:
        Console.WriteLine(line + " (persisted to Logs table)");
    }
}

