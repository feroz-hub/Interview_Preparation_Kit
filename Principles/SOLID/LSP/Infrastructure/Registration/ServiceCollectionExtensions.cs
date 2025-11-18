using LSP.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LSP.Infrastructure.Registration
{
 
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPayrollServices(this IServiceCollection services)
        {
            services.AddSingleton<PayrollService>();
            services.AddSingleton<BonusService>();
            return services;
        }
    }
}
