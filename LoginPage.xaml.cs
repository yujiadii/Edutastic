using Microsoft.Maui.Controls;

namespace Edutastic;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(RegistratiePage));
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Vul alle velden in", "OK");
            return;
        }

        try
        {
            var user = await App.Database.GetUser(username, password);

            if (user != null)
            {
                App.CurrentUser = user;

                await DisplayAlert("Success", $"Welkom {user.Username}", "OK");

                await Shell.Current.GoToAsync("//Dashboard");
            }
            else
            {
                await DisplayAlert("Error", "Ongeldige login", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Database fout: {ex.Message}", "OK");
        }
    }
}