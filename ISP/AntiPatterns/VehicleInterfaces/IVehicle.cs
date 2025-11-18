using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.AntiPatterns.VehicleInterfaces
{
 
    /// <summary>
    /// ❌ Fat interface: forces all implementers to provide Fly(), even if they can't.
    /// Violates ISP because clients are forced to depend on unused members.
    /// </summary>
    public interface IVehicle
    {
        string Drive();
        string Fly();
    }
}