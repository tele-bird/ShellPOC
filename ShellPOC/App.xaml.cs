using Microsoft.Extensions.DependencyInjection;

namespace ShellPOC;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class App : Application
{
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		MainPage = serviceProvider.GetRequiredService<AppShell>();
	}
}

