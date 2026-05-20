using Microsoft.Maui.Controls;

namespace Edutastic;

public partial class HoofdPagina : ContentPage
{
    public HoofdPagina()
    {
        InitializeComponent();
    }
    private async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();

    }

}