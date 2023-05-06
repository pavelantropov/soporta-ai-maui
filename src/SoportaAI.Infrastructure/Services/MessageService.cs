using SoportaAI.Domain.Entities;
using SoportaAI.Domain.Factories;

namespace SoportaAI.Infrastructure.Services;

public class MessageService : IMessageService
{
	private readonly IMessageFactory _messageFactory;

	public MessageService(IMessageFactory messageFactory)
	{
		_messageFactory = messageFactory;
	}

	public async Task<Message> GenerateMessageAsync(string text, User sender, CancellationToken cancellationToken = default)
	{
		return await _messageFactory.CreateAsync(text, sender, cancellationToken);
	}
}