namespace API.Configurations;

internal static class Startup
{
	internal static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder hostBuilder)
	{
		hostBuilder.ConfigureAppConfiguration((context, configBuilder) =>
		{
			const string configurationDirectory = "Configurations";
			var env = context.HostingEnvironment;

			configBuilder.AddJsonFile(path: $"appsettings.json", optional: false, reloadOnChange: true)
						 .AddJsonFile(path: $"appsettings.{env}.json", optional: true, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationDirectory}/cors.json", optional: false, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationDirectory}/cors.{env}.json", optional: true, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationDirectory}/openapi.json", optional: false, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationDirectory}/openapi.{env}.json", optional: true, reloadOnChange: true)
						 .AddEnvironmentVariables();
		});

		return hostBuilder;
	}

}
