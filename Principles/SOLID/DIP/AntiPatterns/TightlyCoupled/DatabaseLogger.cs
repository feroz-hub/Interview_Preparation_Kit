namespace DIP.AntiPatterns.TightlyCoupled;


// Another concrete logger (swapping requires editing DAL).
public sealed class DatabaseLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[BAD DB] {message}");
    }
}
