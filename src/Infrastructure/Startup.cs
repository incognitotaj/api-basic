using Infrastructure.Cors;
using Infrastructure.OpenApi;
using Infrastructure.SecurityHeaders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
	{
		services
			.AddCorsPolicy(config)
			.AddOpenApi(config)
			.AddRouting(options => options.LowercaseUrls = true);
		return services;
	}

	public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, IConfiguration config)
	{
		return app
			.UseStaticFiles()
			.UseSecurityHeaders(config)
			.UseRouting()
			.UseCorsPolicy()
			.UseAuthentication()
			.UseOpenApi(config);
	}

	public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder builder)
	{
		builder.MapControllers();
		return builder;
	}
}
