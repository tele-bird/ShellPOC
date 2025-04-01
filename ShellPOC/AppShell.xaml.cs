using System.Diagnostics;
using ShellPOC.ViewModels;
using ShellPOC.Views;

namespace ShellPOC;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel appShellViewModel)
	{
        BindingContext = appShellViewModel;
        Routing.RegisterRoute("test", typeof(MarketTestPage));
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        // Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigatedTo)} >>");
        base.OnNavigatedTo(args);
    }

    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        // Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigating)} >> Current: {args.Current?.Location} Target: {args.Target?.Location} Source: {args.Source}");
        base.OnNavigating(args);
    }
}

