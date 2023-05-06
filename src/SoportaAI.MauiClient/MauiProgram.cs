using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenAI_API;
using SoportaAI.Domain.Options;
using SoportaAI.Infrastructure.Services;
using SoportaAI.MauiClient.ViewModels;

namespace SoportaAI.MauiClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				;

#if DEBUG
		builder.Logging.AddDebug();

		using var stream = Assembly.GetExecutingAssembly()
			.GetManifestResourceStream("SoportaAI.MauiClient.appsettings.Dev.json");
#else
		using var stream = Assembly.GetExecutingAssembly()
			.GetManifestResourceStream("SoportaAI.MauiClient.appsettings.Prod.json");
#endif

		var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
		builder.Configuration.AddConfiguration(config);

		builder
			.RegisterAppServices()
			.RegisterViewModels()
			.RegisterViews();

		return builder.Build();
	}
}

public static class MauiAppBuilderExtensions
{
	public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
	{
		var openAiOptions = new OpenAiOptions();
		builder.Configuration.GetSection(OpenAiOptions.OpenAi).Bind(openAiOptions);

		builder.Services.AddSingleton<IOpenAIAPI, OpenAIAPI>(_ => 
			new OpenAIAPI(new APIAuthentication(openAiOptions.ApiKey, openAiOptions.Organization)));
		builder.Services.AddSingleton<IApiService, OpenAiApiService>();


		return builder;
	}
	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<MainViewModel>();

		return builder;
	}
	public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<MainPage>();

		return builder;
	}
}
