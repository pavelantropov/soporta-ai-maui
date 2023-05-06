using SoportaAI.Domain.Entities;

namespace SoportaAI.Infrastructure.Services;

public interface IMessageService
{
	Task<Message> GenerateMessageAsync(string text, User sender, CancellationToken cancellationToken = default);
}