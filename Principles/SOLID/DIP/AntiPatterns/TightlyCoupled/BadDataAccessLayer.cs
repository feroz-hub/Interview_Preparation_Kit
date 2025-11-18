namespace DIP.AntiPatterns.TightlyCoupled;


/// <summary>
/// ❌ High-level module depending on low-level detail (violates DIP).
/// Swapping the logger requires modifying this class everywhere.
/// </summary>
public sealed class BadDataAccessLayer(string logPath)
{
    // Direct dependency on a concrete class
    private readonly FileLogger _fileLogger = new(logPath);

    public void AddCustomer(string id, string name, string email)
    {
        // ... imagine DB insert here ...
        _fileLogger.Log($"Added customer {name} <{email}> (#{id})");
    }

    // If you decide to use DatabaseLogger instead,
    // you'd have to edit this class — tight coupling.
}
