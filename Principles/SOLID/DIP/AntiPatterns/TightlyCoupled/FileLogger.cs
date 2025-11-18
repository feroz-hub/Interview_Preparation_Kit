namespace DIP.AntiPatterns.TightlyCoupled;


// Concrete logger used directly by DAL (tight coupling).
public sealed class FileLogger(string path)
{
    public void Log(string message)
    {
        var line = $"[BAD FILE] {message}";
        File.AppendAllText(path, line + Environment.NewLine);
        Console.WriteLine(line);
    }
}
