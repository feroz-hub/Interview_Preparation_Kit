using DIP.AntiPatterns.TightlyCoupled;
using DIP.Application.Services;
using DIP.Domain.Models;
using DIP.Infrastructure.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace DIP;

internal static class Program
{
    private static void Main(string[] args)
    {
        // Choose logger type from CLI or environment: "file" or "db"
        var loggerType = args.Length > 0 ? args[0] :
            Environment.GetEnvironmentVariable("LOGGER_TYPE") ?? "db";

        Console.WriteLine($"[Composition] Using logger: {loggerType}");

        // Composition root (DI wiring)
        var services = new ServiceCollection()
            .AddInfrastructure(loggerType)
            .BuildServiceProvider();

        var customerService = services.GetRequiredService<CustomerService>();

        var customers = new List<Customer>
        {
            new("C1001", "Anita", "anita@example.com"),
            new("C1002", "Rahul", "rahul@example.com"),
        };

        Console.WriteLine("=== DIP-Compliant Demo ===");
        foreach (var c in customers)
            customerService.Register(c);

        Console.WriteLine();

        // ❌ Anti-pattern: shows tight coupling
        Console.WriteLine("=== Anti-Pattern (Violates DIP) ===");
        var badDal = new BadDataAccessLayer(logPath: "bad.log"); // tightly coupled to FileLogger
        badDal.AddCustomer("C9999", "Sedan", "sedan@example.com");

        Console.WriteLine("\nNote: To switch to DatabaseLogger in the anti-pattern, you'd edit BadDataAccessLayer (violates DIP).");
        Console.WriteLine("      In the DI setup, you switch logger by args: `dotnet run db` or `dotnet run file` — no class edits.");
    }
}