using System.Diagnostics;
using ShellPOC.Extensions;
using ShellPOC.ViewModels;
using ShellPOC.Views;

namespace ShellPOC;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class AppShell : Shell
{
    private Stack<Page> _lastNavigationStack = new Stack<Page>();
    private Stack<Page> _lastModalStack = new Stack<Page>();
    
    public AppShell(AppShellViewModel appShellViewModel)
	{
        BindingContext = appShellViewModel;
        Routing.RegisterRoute("test", typeof(MarketTestPage));
        Routing.RegisterRoute("fulldrawer", typeof(FullMarketDrawerPage));
        Routing.RegisterRoute("halfdrawer", typeof(HalfMarketDrawerPage));
        InitializeComponent();
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigated)} >> Previous: {args.Previous?.Location} Current: {args.Current.Location} Source: {args.Source} NavigationStack: {Navigation.NavigationStack.ToDebugString(page => page.GetType().Name)} ModalStack: {Navigation.ModalStack.ToDebugString(page => page.GetType().Name)}");
        
        // dispose of pages that have been popped from the navigation stack:
        while (Navigation.NavigationStack.Count < _lastNavigationStack.Count)
        {
            var poppedPage = _lastNavigationStack.Pop();
            var disposablePage = poppedPage as IDisposable;
            if (disposablePage != null)
            {
                disposablePage.Dispose();
            }
        }
        
        // dispose of pages that have been popped from the modal stack:
        while (Navigation.ModalStack.Count < _lastModalStack.Count)
        {
            var poppedModalPage = _lastModalStack.Pop();
            var disposableModalPage = poppedModalPage as IDisposable;
            if (disposableModalPage != null)
            {
                disposableModalPage.Dispose();
            }
        }

        // update the _lastNavigationStack with the new pages in the NavigationStack: 
        while (Navigation.NavigationStack.Count > _lastNavigationStack.Count)
        {
            for (int i = _lastNavigationStack.Count; i < Navigation.NavigationStack.Count; i++)
            {
                _lastNavigationStack.Push(Navigation.NavigationStack[i]);
            }
        }

        // update the _lastModalStack with the new pages in the ModalStack: 
        while (Navigation.ModalStack.Count > _lastModalStack.Count)
        {
            for (int i = _lastModalStack.Count; i < Navigation.ModalStack.Count; i++)
            {
                _lastModalStack.Push(Navigation.ModalStack[i]);
            }
        }

        // if (args.Previous?.Location != null && args.Current.Location != args.Previous.Location)
        // {
        //     if (args.Source == ShellNavigationSource.Pop || args.Source == ShellNavigationSource.PopToRoot)
        //     {
        //         Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigated)} >> Popped!");
        //     }
        // }
        // _pages.Clear();
        // foreach (var page in Navigation.NavigationStack)
        // {
        //     _pages.Push(page);
        // }

        base.OnNavigated(args);
        
        Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigated)} << _lastNavigationStack: {_lastNavigationStack.ToDebugString(page => page.GetType().Name)} _lastModalStack: {_lastModalStack.ToDebugString(page => page.GetType().Name)}");
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        //Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigatedFrom)} >>");
        base.OnNavigatedFrom(args);
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        //Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigatingFrom)} >>");
        base.OnNavigatingFrom(args);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        //Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigatedTo)} >>");
        base.OnNavigatedTo(args);
    }

    protected override void OnNavigating(ShellNavigatingEventArgs args)
    {
        //Trace.WriteLine($"{GetType().Name}.{nameof(OnNavigating)} >> Current: {args.Current?.Location} Target: {args.Target?.Location} Source: {args.Source}");
        base.OnNavigating(args);
    }
}

