namespace Edutastic;
using Edutastic.Models;

public partial class App : Application
{
    public static DatabaseService Database { get; private set; }
    public static User? CurrentUser { get; set; }

    public App()
    {
        InitializeComponent();

        Database = new DatabaseService();
        
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new HoofdPagina());
    }
}