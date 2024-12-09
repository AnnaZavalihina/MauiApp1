namespace MauiApp1;

public partial class LoginPage : ContentPage
{
    private bool _isPassword = true;
    public bool IsPassword
    {
        get => _isPassword;
        set
        {
            if (_isPassword != value)
            {
                _isPassword = value;
                OnPropertyChanged(nameof(IsPassword));
            }
        }
    }

    public LoginPage()
	{
        InitializeComponent();
        BindingContext = this;
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        button.BackgroundColor = button.BackgroundColor == Colors.Green ? Colors.LightGreen : Colors.Green;

        await Navigation.PushAsync(new HomePage());
    }

    private async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private void OnTogglePasswordVisibilityClicked(object sender, EventArgs e)
    {
        IsPassword = !IsPassword;
    }
}