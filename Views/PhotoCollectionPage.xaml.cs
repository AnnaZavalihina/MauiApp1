using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class PhotoCollectionPage : ContentPage
{
	public PhotoCollectionPage(PhotoCollectionViewModel viewModel)
	{
		BindingContext = viewModel;

		InitializeComponent();
	}
}