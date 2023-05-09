using System.Collections.ObjectModel;
using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SoportaAI.Domain.Entities;
using SoportaAI.Domain.Factories;
using SoportaAI.Infrastructure.Services;
using SoportaAI.Model.Models;
using SoportaAI.Utils.Extensions;

namespace SoportaAI.MauiClient.ViewModels;

public partial class ChatViewModel : ObservableObject
{
	private readonly IApiService _apiService;
	private readonly IMessageFactory _messageFactory;
	private readonly IMapper _mapper;

	[ObservableProperty]
	private string _input;

	// TODO remove and use models in this project
	[ObservableProperty]
	private User _currentUser;

	[ObservableProperty]
	private ObservableCollection<MessageModel> _messages = new();

	public ChatViewModel(IApiService apiService, IMessageFactory messageFactory, IMapper mapper)
	{
		_apiService = apiService;
		_messageFactory = messageFactory;
		_mapper = mapper;

		_currentUser = new User();
	}

	[RelayCommand]
	public async Task SendMessageAsync(CancellationToken cancellationToken = default)
	{
		if (Input.IsNullOrWhiteSpace())
		{
			return; // !!!
		}

		var message = await _messageFactory.CreateAsync(Input, CurrentUser, cancellationToken);
		Messages.Add(_mapper.Map<MessageModel>(message));
		Input = string.Empty;

		var response = await _apiService.GenerateResponseAsync(message.Text, cancellationToken);
		Messages.Add(_mapper.Map<MessageModel>(response));

		SemanticScreenReader.Announce(response.Text);
	}

	[RelayCommand]
	public async Task RemoveMessageAsync(Guid guid, CancellationToken cancellationToken = default)
	{
		var message = Messages.First(x => x.Guid == guid);
		Messages.Remove(message);
	}

	[RelayCommand]
	public void GoHome()
	{
		//NavigationService.Instance.NavigateBackAsync();
	}

	[RelayCommand]
	public async Task CopyToClipboardAsync(string text)
	{
		await Clipboard.Default.SetTextAsync(text);
	}
}