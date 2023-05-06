using SoportaAI.Domain.Entities;

namespace SoportaAI.Domain.Factories;

public interface IMessageFactory
{
	Task<Message> CreateAsync(string text, User sender, CancellationToken cancellationToken = default);
}