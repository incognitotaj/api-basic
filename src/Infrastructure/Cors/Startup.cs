using Infrastructure.Common.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Cors;

internal static class Startup
{
	private static string CorsPolicy = nameof(CorsPolicy);
	internal static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration config)
	{
		var corsSettings = config.GetSection(nameof(CorsSettings)).Get<CorsSettings>();
		var origins = new List<string>();

		if (corsSettings.Angular is not null)
		{
			origins.AddRange(corsSettings.Angular.Split(';', StringSplitOptions.RemoveEmptyEntries));
		}

		if (corsSettings.React is not null)
		{
			origins.AddRange(corsSettings.React.Split(';', StringSplitOptions.RemoveEmptyEntries));
		}

		if (corsSettings.Blazor is not null)
		{
			origins.AddRange(corsSettings.Blazor.Split(';', StringSplitOptions.RemoveEmptyEntries));
		}

		services.AddCors(opt =>
		{
			opt.AddPolicy(name: CorsPolicy, policyConfig =>
			{
				policyConfig.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowAnyMethod()
				.WithOrigins(origins.ToArray());
			});
		});

		return services;
	}

	internal static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
	{
		app.UseCors(CorsPolicy);
		return app;
	}
}
