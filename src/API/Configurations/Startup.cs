namespace API.Configurations;

internal static class Startup
{
	internal static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder hostBuilder)
	{
		hostBuilder.ConfigureAppConfiguration((context, configBuilder) =>
		{
			const string configurationsDirectory = "Configurations";
			var env = context.HostingEnvironment;

			configBuilder.AddJsonFile(path: $"appsettings.json", optional: false, reloadOnChange: true)
						 .AddJsonFile(path: $"appsettings.{env}.json", optional: true, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationsDirectory}/cors.json", optional: false, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationsDirectory}/cors.{env}.json", optional: true, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationsDirectory}/openapi.json", optional: false, reloadOnChange: true)
						 .AddJsonFile(path: $"{configurationsDirectory}/openapi.{env}.json", optional: true, reloadOnChange: true)
						 .AddJsonFile($"{configurationsDirectory}/security.json", optional: false, reloadOnChange: true)
						.AddJsonFile($"{configurationsDirectory}/security.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
						 .AddEnvironmentVariables();
		});

		return hostBuilder;
	}

}
