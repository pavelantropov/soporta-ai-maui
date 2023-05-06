using OpenAI_API;
using SoportaAI.Domain.Entities;

namespace SoportaAI.Infrastructure.Services;

public class OpenAiApiService : IApiService
{
	private readonly IOpenAIAPI _api;
	private readonly IMessageService _messageService;

	public OpenAiApiService(IOpenAIAPI api, IMessageService messageService)
	{
		_api = api;
		_messageService = messageService;
	}

	public async Task<Message> GenerateResponseAsync(string input, CancellationToken cancellationToken = default)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return default; // !!!
		}

		var chat = _api.Chat.CreateConversation();

		chat.AppendUserInput(input);

		var response = await chat.GetResponseFromChatbotAsync();

		var message = await _messageService.GenerateMessageAsync(response, null, cancellationToken);

		return message;
	}
}