
using Microsoft.Extensions.DependencyInjection;
using OCP.Application.Service;
using OCP.Domain.Models;
using OCP.Infrastructure.Registration;
using System.Reflection;

internal static class Program
{
    private static void Main()
    {
        // Composition Root
        var services = new ServiceCollection()
            .AddInterestCalculatorsFromAssembly(Assembly.GetExecutingAssembly())
            .BuildServiceProvider();

        var interestService = services.GetRequiredService<InterestService>();

        var accounts = new[]
        {
                new Account("Anita", "Savings",      10_000m),
                new Account("Rahul", "FixedDeposit", 25_000m),
                new Account("Meera", "Current",      30_000m),
                // To demo extension, add PremiumSavingsInterestCalculator and uncomment:
                new Account("Kamal", "PremiumSavings", 50_000m),
            };

        Console.WriteLine("=== Interest Calculation (OCP Demo) ===");
        foreach (var acc in accounts)
        {
            var interest = interestService.ComputeInterest(acc);
            Console.WriteLine($"{acc.Name,-10} | {acc.AccountType,-14} | Balance: {acc.Balance,10:C} | Interest: {interest,10:C}");
        }

        // Show graceful error on unknown type
        try
        {
            var unknown = new Account("Zara", "Gold", 12_000m);
            var _ = interestService.ComputeInterest(unknown);
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Expected (unknown type): " + ex.Message);
            Console.ResetColor();
        }
    }
}
