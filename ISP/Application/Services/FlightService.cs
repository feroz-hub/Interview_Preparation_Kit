using ISP.Domain.Interfaces.IspTransportDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Application.Services
{
   
    /// <summary>
    /// Operates only on air-capable vehicles. No forced methods for non-flyers.
    /// </summary>
    public sealed class FlightService
    {
        public string Operate(IFlyable vehicle) => vehicle.Fly();
    }
}
