using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

namespace Infrastructure.OpenApi
{
	internal static class Startup
	{
		internal static IServiceCollection AddOpenApi(this IServiceCollection services, IConfiguration config)
		{
			var settings = config.GetSection(nameof(SwaggerSettings)).Get<SwaggerSettings>();
			if (settings.Enable)
			{
				services.AddEndpointsApiExplorer();
				services.AddSwaggerGen(options =>
				{
					options.SwaggerDoc(settings.Version, new OpenApiInfo
					{
						Version = settings.Version,
						Title = settings.Title,
						Description = settings.Description,
						TermsOfService = new Uri(uriString: settings.TermsOfUseUrl),
						Contact = new OpenApiContact
						{
							Name = settings.ContactName,
							Url = new Uri(uriString: settings.ContactUrl)
						},
						License = new OpenApiLicense
						{
							Name = settings.LicenseName,
							Url = new Uri(uriString: settings.LicenseUrl)
						}
					});

					// using System.Reflection;
					//var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
					//options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

				});
			}
			return services;
		}


		internal static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, IConfiguration config)
		{
			if (config.GetValue<bool>("SwaggerSettings:Enable"))
			{
				app.UseSwagger();
				app.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("/swagger/v1/swagger.json", config.GetValue<string>("SwaggerSettings:Title"));
					options.RoutePrefix = string.Empty;
					options.DocExpansion(DocExpansion.None);
				});
			}

			return app;
		}
	}
}
