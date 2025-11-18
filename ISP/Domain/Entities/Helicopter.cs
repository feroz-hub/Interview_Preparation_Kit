using ISP.Domain.Interfaces.IspTransportDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Domain.Entities
{
  
    /// <summary>
    /// Helicopter only flies; it doesn't implement driving capabilities.
    /// </summary>
    public sealed class Helicopter : IFlyable
    {
        public string Model { get; }

        public Helicopter(string model) => Model = model ?? throw new ArgumentNullException(nameof(model));

        public string Fly() => $"{Model} is hovering and flying.";
    }
}