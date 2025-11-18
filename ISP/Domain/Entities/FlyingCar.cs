using ISP.Domain.Interfaces;
using ISP.Domain.Interfaces.IspTransportDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Domain.Entities
{
    /// <summary>
    /// Flying car supports both driving and flying via multiple small interfaces (ISP).
    /// </summary>
    public sealed class FlyingCar : IDriveable, IFlyable
    {
        public string Model { get; }

        public FlyingCar(string model) => Model = model ?? throw new ArgumentNullException(nameof(model));

        public string Drive() => $"{Model} is driving on the highway.";

        public string Fly() => $"{Model} is flying above city traffic.";
    }
}