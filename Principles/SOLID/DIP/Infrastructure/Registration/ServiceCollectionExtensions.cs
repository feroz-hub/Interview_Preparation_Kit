
using DIP.Application.Services;
using DIP.Domain.Interfaces;
using DIP.Infrastructure.Logging;
using DIP.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace DIP.Infrastructure.Registration;


/// <summary>
/// Composition helpers: register abstractions mapped to implementations.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers infrastructure services. Choose logger by key: "file" or "db".
    /// </summary>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string loggerType)
    {
        // Repository
        services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();

        // Logger selection
        if (string.Equals(loggerType, "file", System.StringComparison.OrdinalIgnoreCase))
        {
            // Using a fixed demo path; you can move to config
            services.AddSingleton<ILogger>(sp => new FileLogger(path: "app.log"));
        }
        else
        {
            services.AddSingleton<ILogger, DatabaseLogger>();
        }

        // High-level services
        services.AddSingleton<CustomerService>();
        return services;
    }
}
