using SoportaAI.MauiClient.ViewModels;

namespace SoportaAI.MauiClient;

public partial class ChatPage : ContentPage
{
	public ChatPage(ChatViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
