using SoportaAI.MauiClient.ViewModels;

namespace SoportaAI.MauiClient;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
