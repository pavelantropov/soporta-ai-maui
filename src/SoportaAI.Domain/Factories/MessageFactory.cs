using SoportaAI.Domain.Entities;

namespace SoportaAI.Domain.Factories;

public class MessageFactory : IMessageFactory
{
	public async Task<Message> CreateAsync(string text, User sender, CancellationToken cancellationToken = default)
	{
		var message = new Message
		{
			Guid = Guid.NewGuid(),
			Text = text,
			Time = DateTime.Now,
			Sender = sender,
		};

		return message;
	}
}