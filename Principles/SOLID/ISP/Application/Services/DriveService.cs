using ISP.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Application.Services
{
  
    /// <summary>
    /// Operates only on road-capable vehicles. Depends on the smallest interface needed (ISP).
    /// </summary>
    public sealed class DriveService
    {
        public string Operate(IDriveable vehicle) => vehicle.Drive();
    }
}