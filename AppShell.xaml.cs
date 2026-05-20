namespace Edutastic;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		
		Routing.RegisterRoute("LoginPage", typeof(LoginPage));
		Routing.RegisterRoute("RegistratiePage", typeof(RegistratiePage));
		Routing.RegisterRoute("Dashboard", typeof(Dashboard));
		Routing.RegisterRoute("Hoofdpagina", typeof(Dashboard));
		
	}
}
