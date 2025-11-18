using DIP.Domain.Interfaces;

namespace DIP.Infrastructure.Logging;


/// <summary>
/// Low-level detail: log to a text file.
/// </summary>
public sealed class FileLogger(string path) : ILogger
{
    private readonly string _path = path ?? throw new ArgumentNullException(nameof(path));

    public void Log(string message)
    {
        var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] FILE: {message}";
        File.AppendAllText(_path, line + Environment.NewLine);
        Console.WriteLine(line);
    }
}
