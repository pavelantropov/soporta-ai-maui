using SoportaAI.Domain.Entities;

namespace SoportaAI.Infrastructure.Services;

public interface IApiService
{
	Task<Message> GenerateResponseAsync(string input, CancellationToken cancellationToken = default);
}