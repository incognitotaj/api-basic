using AutoWrapper;
using Infrastructure.Cors;
using Infrastructure.OpenApi;
using Infrastructure.SecurityHeaders;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services
            //.AddApiVersioning()
            .AddCorsPolicy(config)
            .AddOpenApi(config)
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddRouting(options => options.LowercaseUrls = true);
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app, IConfiguration config)
    {
        return app
            .UseStaticFiles()
            .UseSecurityHeaders(config)
            .UseApiResponseAndExceptionWrapper(
                new AutoWrapperOptions
                { 
                    IsDebug = true,
                    IsApiOnly = true,
                    ShowApiVersion = true,
                    ShowStatusCode = true,
                    ShowIsErrorFlagForSuccessfulResponse = true,
                }
            )
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
