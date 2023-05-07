using SoportaAI.MauiClient.ViewModels;

namespace SoportaAI.MauiClient;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		NavigationPage.SetHasNavigationBar(this, false);
	}
}