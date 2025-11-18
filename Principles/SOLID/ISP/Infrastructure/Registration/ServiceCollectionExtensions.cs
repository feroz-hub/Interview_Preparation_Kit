using ISP.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISP.Infrastructure.Registration
{
    /// <summary>
    /// DI wiring kept minimal—services only.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTransportServices(this IServiceCollection services)
        {
            services.AddSingleton<DriveService>();
            services.AddSingleton<FlightService>();
            return services;
        }
    }
}