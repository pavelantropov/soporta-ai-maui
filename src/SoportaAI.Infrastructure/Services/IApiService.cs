namespace SoportaAI.Infrastructure.Services;

public interface IApiService
{
	Task<string> GenerateResponseAsync(string input);
}