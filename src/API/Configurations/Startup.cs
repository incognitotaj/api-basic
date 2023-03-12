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
						 .AddJsonFile(path: $"{configurationDirectory}/appsettings.json", optional: false, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationDirectory}/appsettings.{env}.json", optional: true, reloadOnChange: true)
						 .AddEnvironmentVariables();
		});

		return hostBuilder;
	}

}
