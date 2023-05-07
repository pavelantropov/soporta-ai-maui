using SoportaAI.MauiClient.ViewModels;

namespace SoportaAI.MauiClient;

public partial class ChatPage : ContentPage
{
	public ChatPage(ChatViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	// TODO
	private async void SetClipboardButton_Clicked(object sender, EventArgs e)
	{
		await Clipboard.Default.SetTextAsync("This text was highlighted in the UI.");
	}
}
