using OpenAI_API;

namespace SoportaAI.Infrastructure.Services;

public class OpenAiApiService : IApiService
{
	private readonly IOpenAIAPI _api;

	public OpenAiApiService(IOpenAIAPI api)
	{
		_api = api;
	}

	public async Task<string> GenerateResponseAsync(string input)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return default; // !!!
		}

		var chat = _api.Chat.CreateConversation();

		chat.AppendUserInput(input);

		var response = await chat.GetResponseFromChatbotAsync();

		return response;
	}
}