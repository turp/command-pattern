using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Services.Reflection;

public static class ServiceExtensions
{
	public static void RegisterServices(this IServiceCollection services)
	{
		var scopedService = typeof(ScopedServiceAttribute);
		var singletonService = typeof(SingletonServiceAttribute);
		var transientService = typeof(TransientServiceAttribute);

		var types = AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(s => s.GetTypes())
			.Where(p => p.IsDefined(scopedService, true)
						|| p.IsDefined(transientService, true)
						|| p.IsDefined(singletonService, true)
						&& !p.IsInterface
			).Select(implementationType => new
			{
				ServiceType = implementationType.GetInterface($"I{implementationType.Name}") ?? implementationType,
				ImplementationType = implementationType
			});

		foreach (var type in types)
		{
			if (type.ImplementationType.IsDefined(scopedService, false))
				services.AddScoped(type.ServiceType, type.ImplementationType);

			if (type.ImplementationType.IsDefined(transientService, false))
				services.AddTransient(type.ServiceType, type.ImplementationType);

			if (type.ImplementationType.IsDefined(singletonService, false))
				services.AddSingleton(type.ServiceType, type.ImplementationType);
		}
	}
}
