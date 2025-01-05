using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controls.Reflection;

public static class ServiceExtensions
{
    public static void RegisterComplianceControls(this IServiceCollection services)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(t => typeof(ComplianceControl).IsAssignableFrom(t) && !t.IsAbstract);

        foreach (var type in types)
        {
            services.AddKeyedTransient(typeof(ComplianceControl), type.Name, type);
        }
    }
}
