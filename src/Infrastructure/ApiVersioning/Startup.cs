using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ApiVersioning
{
    public static class Startup
    {
        public static IServiceCollection AddApiVersioning(this IServiceCollection services)
        {
            return services.AddApiVersioning(config =>
            {
                config.ReportApiVersions = true;
                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });
        }
    }
}
