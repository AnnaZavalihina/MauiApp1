using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel viewModel)
	{
		BindingContext = viewModel;

		InitializeComponent();
	}
}