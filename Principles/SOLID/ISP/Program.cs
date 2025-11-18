using ISP.AntiPatterns.VehicleInterfaces;
using ISP.Application.Services;
using ISP.Domain.Entities;
using ISP.Domain.Interfaces;
using ISP.Domain.Interfaces.IspTransportDemo.Domain.Interfaces;
using ISP.Infrastructure.Registration;
using Microsoft.Extensions.DependencyInjection;


namespace ISP
{
    internal static class Program
    {
        private static void Main()
        {
            // Composition root
            var services = new ServiceCollection()
                .AddTransportServices()
                .BuildServiceProvider();

            var driveService = services.GetRequiredService<DriveService>();
            var flightService = services.GetRequiredService<FlightService>();

            // ✅ ISP-compliant usage
            var roadFleet = new List<IDriveable>
            {
                new Car("Swift"),
                new FlyingCar("SkyRider")
            };

            var airFleet = new List<IFlyable>
            {
                new Helicopter("Apache"),
                new FlyingCar("SkyRider")
            };

            Console.WriteLine("=== ISP-Compliant Demo ===");
            foreach (var v in roadFleet)
                Console.WriteLine("Drive: " + driveService.Operate(v));

            foreach (var v in airFleet)
                Console.WriteLine("Fly:   " + flightService.Operate(v));

            Console.WriteLine();

            // ❌ Anti-pattern demo: fat interface forces unused member
            Console.WriteLine("=== Anti-Pattern (Violates ISP) ===");
            IVehicle badCar = new BadCar("Sedan-Classic");
            Console.WriteLine("Drive: " + badCar.Drive());
            try
            {
                // Compiles because IVehicle demands Fly() — but breaks at runtime.
                Console.WriteLine("Fly:   " + badCar.Fly());
            }
            catch (NotSupportedException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Expected failure: " + ex.Message);
                Console.ResetColor();
            }

            // ✅ With segregated interfaces, such misuse is prevented at compile time:
            // flightService.Operate(new Car("Swift")); // ❌ won't compile (Car doesn't implement IFlyable)
        }
    }
}