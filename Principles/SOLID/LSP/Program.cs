using LSP.Application.Services;
using LSP.Domain.Entities;
using LSP.Domain.Interfaces;
using LSP.Infrastructure.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace LSP
{

    internal static class Program
    {
        private static void Main()
        {
            // Composition root (DI)
            var services = new ServiceCollection()
                .AddPayrollServices()
                .BuildServiceProvider();

            var payroll = services.GetRequiredService<PayrollService>();
            var bonus = services.GetRequiredService<BonusService>();

            // Employees (both can be used wherever IEmployee is expected)
            var employees = new List<IEmployee>
            {
                new PermanentEmployee(
                    id: "E1001",
                    name: "Anita",
                    basicPay: 40000m,
                    hra: 12000m,
                    specialAllowance: 8000m,
                    bonusRate: 0.10m), // 10%

                new ContractEmployee(
                    id: "C2001",
                    name: "Rahul",
                    hourlyRate: 800m,
                    billableHours: 160)
            };

            Console.WriteLine("=== LSP-Compliant Payroll Demo ===");
            foreach (var emp in employees)
            {
                // LSP in action: same code path for both employees
                Console.WriteLine(payroll.GetPayLine(emp));

                // Bonus only for those who are bonus-eligible (no type coercion)
                if (emp is IBonusEligible eligible)
                {
                    Console.WriteLine("  -> " + bonus.GetBonusLine(eligible));
                }
            }

            Console.WriteLine();

            // 🔎 What would violate LSP (anti-pattern)?
            // If ContractEmployee implemented IBonusEligible and threw NotSupportedException
            // in CalculateBonus(), then this line would compile but break at runtime:
            // bonus.GetMonthlyBonus((IBonusEligible)employees[1]); // ❌ would throw
            //
            // Our design prevents this by using ISP: only classes that genuinely support
            // bonus implement IBonusEligible. No exceptions, no surprises — LSP respected.
        }
    }
}