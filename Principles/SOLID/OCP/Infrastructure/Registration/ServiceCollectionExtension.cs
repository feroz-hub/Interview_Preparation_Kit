using Microsoft.Extensions.DependencyInjection;
using OCP.Application.Resolver;
using OCP.Application.Service;
using OCP.Domain.Interfaces;
using OCP.Infrastructure.Resolver;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OCP.Infrastructure.Registration
{

    /// <summary>
    /// DI registration with assembly scanning: new calculators auto-register (OCP-friendly).
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInterestCalculatorsFromAssembly(
            this IServiceCollection services,
            Assembly assembly)
        {
            var calculatorTypes = assembly.GetTypes()
                .Where(t => typeof(IInterestCalculator).IsAssignableFrom(t) &&
                            !t.IsInterface && !t.IsAbstract);

            foreach (var t in calculatorTypes)
                services.AddSingleton(typeof(IInterestCalculator), t);

            services.AddSingleton<IInterestCalculatorResolver, InterestCalculatorResolver>();
            services.AddSingleton<InterestService>();
            return services;
        }
    }

}
