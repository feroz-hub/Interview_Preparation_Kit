using ISP.AntiPatterns.VehicleInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.AntiPatterns.VehicleInterfaces
{
  
    /// <summary>
    /// ❌ Bad design: Car can't fly but is forced to implement Fly(), leading to
    /// useless implementations or exceptions (violates ISP, and often LSP).
    /// </summary>
    public sealed class BadCar : IVehicle
    {
        public string Model { get; }

        public BadCar(string model) => Model = model ?? throw new ArgumentNullException(nameof(model));

        public string Drive() => $"{Model} is driving (bad interface).";

        // Forced method—either throw or return nonsense.
        public string Fly() => throw new NotSupportedException($"{Model} cannot fly (forced by fat interface).");
    }
}