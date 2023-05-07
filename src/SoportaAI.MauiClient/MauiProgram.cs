using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenAI_API;
using SoportaAI.Domain.Factories;
using SoportaAI.Domain.Options;
using SoportaAI.Infrastructure.Mappings;
using SoportaAI.Infrastructure.Services;
using SoportaAI.MauiClient.ViewModels;
using SoportaAI.MauiClient.Views;

namespace SoportaAI.MauiClient;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("HammersmithOne-Regular.ttf", "HammersmithOneRegular");
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

		//builder.Services.AddDbContext<ChatContext>(options => options.UseInMemoryDatabase("chat"));
		builder.Services.AddAutoMapper(typeof(MessageMapProfile));
		builder.Services.AddAutoMapper(typeof(UserMapProfile));

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

		builder.Services.AddSingleton<IMessageFactory, MessageFactory>();
		builder.Services.AddSingleton<IMessageService, MessageService>();

		return builder;
	}
	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<ChatViewModel>();
		builder.Services.AddSingleton<HomeViewModel>();

		return builder;
	}
	public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<ChatPage>();
		builder.Services.AddSingleton<HomePage>();

		return builder;
	}
}
