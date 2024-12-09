namespace MauiApp1;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        button.BackgroundColor = button.BackgroundColor == Colors.Green ? Colors.LightGreen : Colors.Green;

        if (passwordEntry.Text.Equals(password2Entry.Text))
        {
            await Navigation.PushAsync(new HomePage());

        }
        else 
        {
            errorLabel.Text = "Passwords do not match. Please try again.";
            errorLabel.IsVisible = true;
        }
    }

    private async void OnGoToLoginClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}