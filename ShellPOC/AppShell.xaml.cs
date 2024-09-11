using ShellPOC.ViewModels;
using ShellPOC.Views;

namespace ShellPOC;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel appShellViewModel)
	{
        BindingContext = appShellViewModel;
        //Routing.RegisterRoute("test", typeof(TestPage));
        Routing.RegisterRoute("plan/test", typeof(TestPage));
        //Routing.RegisterRoute("market/plan/test", typeof(TestPage));
        //Routing.RegisterRoute("//market/plan/test", typeof(TestPage));
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);
    }
}

