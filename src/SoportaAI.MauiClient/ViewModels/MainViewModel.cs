using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SoportaAI.Infrastructure.Services;

namespace SoportaAI.MauiClient.ViewModels;

public partial class MainViewModel : ObservableObject
{
	private readonly IApiService _apiService;

	[ObservableProperty]
	private string _input;

	[ObservableProperty]
	private ObservableCollection<string> _responses = new();

	public MainViewModel(IApiService apiService)
	{
		_apiService = apiService;
	}

	[RelayCommand]
	public async Task GenerateResponse()
	{
		if (string.IsNullOrWhiteSpace(Input))
		{
			return; // !!!
		}

		var response = await _apiService.GenerateResponseAsync(Input);

		Responses.Add(response);

		SemanticScreenReader.Announce(response);
	}
}