using Microsoft.Extensions.Logging;
using OpenAI_API;
using SoportaAI.Infrastructure.Services;
using SoportaAI.MauiClient.ViewModels;

namespace SoportaAI.MauiClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterAppServices()
			.RegisterViewModels()
			.RegisterViews()
			;

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

public static class MauiAppBuilderExtensions
{
	public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<IOpenAIAPI, OpenAIAPI>();
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
