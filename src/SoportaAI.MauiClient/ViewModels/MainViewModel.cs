using System.Collections.ObjectModel;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SoportaAI.Domain.Factories;
using SoportaAI.Infrastructure.Services;
using SoportaAI.Model.Models;
using SoportaAI.Utils.Extensions;

namespace SoportaAI.MauiClient.ViewModels;

public partial class MainViewModel : ObservableObject
{
	private readonly IApiService _apiService;
	private readonly IMessageFactory _messageFactory;
	private readonly IMapper _mapper;

	[ObservableProperty]
	private string _input;

	[ObservableProperty]
	private ObservableCollection<MessageModel> _messages = new();

	public MainViewModel(IApiService apiService, IMessageFactory messageFactory, IMapper mapper)
	{
		_apiService = apiService;
		_messageFactory = messageFactory;
		_mapper = mapper;
	}

	[RelayCommand]
	public async Task GenerateResponse(CancellationToken cancellationToken = default)
	{
		if (Input.IsNullOrWhiteSpace())
		{
			return; // !!!
		}

		var message = await _messageFactory.CreateAsync(Input, null, cancellationToken);
		Messages.Add(_mapper.Map<MessageModel>(message));

		var response = await _apiService.GenerateResponseAsync(message.Text, cancellationToken);
		Messages.Add(_mapper.Map<MessageModel>(response));

		SemanticScreenReader.Announce(response.Text);
	}
}