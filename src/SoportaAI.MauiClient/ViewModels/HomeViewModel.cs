using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SoportaAI.MauiClient.ViewModels;

public partial class HomeViewModel : ObservableObject
{
	[RelayCommand]
	public async Task OpenChatAsync()
	{
		await Shell.Current.GoToAsync(nameof(ChatPage));
	}
}