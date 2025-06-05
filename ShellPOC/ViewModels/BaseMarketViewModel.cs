using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Web;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShellPOC.Events;
using ShellPOC.Extensions;
using ShellPOC.Helpers;
using ShellPOC.Models;
using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public abstract partial class BaseMarketViewModel : BaseViewModel, IQueryAttributable
{
    protected string marketIdQueryParameterKey = "marketId";
    protected abstract bool IsQueryParameterRequired { get; }
	protected readonly IAppStateManager appStateManager;

	[ObservableProperty]
	private int? marketId;

	[ObservableProperty]
	private ObservableCollection<ShellPage> shellPages;

	[ObservableProperty]
	private ShellPage? selectedShellPage;

    [ObservableProperty]
    private string? routeToPush;

	protected BaseMarketViewModel(IAppStateManager appStateManager, params ShellPage[] shellPages)
	{
		if(shellPages.Length == 0)
		{
			throw new ArgumentOutOfRangeException(nameof(shellPages), "must have at least one element");
		}
		this.appStateManager = appStateManager;
		this.appStateManager.SelectedMarketChanged += OnSelectedMarketChanged;
		this.shellPages = new ObservableCollection<ShellPage>(shellPages);
	}

	protected override Task OnAppearing()
	{
		//Trace.WriteLine($"{guid} {GetType().Name}.{nameof(OnAppearing)} >> MarketId: {MarketId}");
		return base.OnAppearing();
	}

    protected override Task OnFirstAppearing()
    {
		this.SelectedShellPage = ShellPages[0];
        return base.OnFirstAppearing();
    }

    private void OnSelectedMarketChanged(SelectedMarketChangedEventArgs args)
	{
		// Trace.WriteLine($"{GetType().Name}.{nameof(OnSelectedMarketChanged)} from {MarketId} to {args.MarketId}");
		MarketId = args.MarketId;
	}

	protected override void OnPropertyChanged(PropertyChangedEventArgs args)
	{
		if(args.PropertyName == nameof(MarketId))
		{
			// Trace.WriteLine($"{GetType().Name}.{nameof(OnPropertyChanged)}({nameof(MarketId)}) from {appStateManager.SelectedMarketId}  to {MarketId}");
			appStateManager.SelectedMarketId = MarketId;
		}
		else if(args.PropertyName == nameof(SelectedShellPage))
		{
			// Trace.WriteLine($"{GetType().Name}.{nameof(OnPropertyChanged)}({nameof(SelectedShellPage)}) to {SelectedShellPage}");
			if(SelectedShellPage != null)
			{
				RouteToPush = SelectedShellPage.Path;
			}
		}
		base.OnPropertyChanged(args);
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
		//Trace.WriteLine($"{GetType().Name}.{nameof(ApplyQueryAttributes)} >> query: {query.ToQueryString()}"); 
		int? marketId = null;
		if(query.TryGetValue(marketIdQueryParameterKey, out var marketIdObject))
		{
			marketId = int.Parse(marketIdObject as string);
		}
		else if(appStateManager.SelectedMarketId.HasValue)
		{
			marketId = appStateManager.SelectedMarketId.Value;
		}

		if(marketId == null && IsQueryParameterRequired)
		{
			throw new ArgumentException($"No market is currently selected, so query parameter {marketIdQueryParameterKey} is required for {nameof(BaseMarketViewModel)} subclass: {GetType().Name}");
		}

		//Trace.WriteLine($"{GetType().Name}.{nameof(ApplyQueryAttributes)} >> query: {query.ToQueryString()} setting MarketId from {MarketId} to {marketId}");
		MarketId = marketId;
    }

    [RelayCommand]
    async Task PushPageAsync()
    {
        // Trace.WriteLine($"{guid} {GetType().Name}.{nameof(PushPageAsync)} >> with RouteToPush: {RouteToPush}");
        try
        {
            ArgumentNullException.ThrowIfNullOrEmpty(RouteToPush);
            var url = new Uri(RouteToPush, UriKind.Relative);
            //Trace.WriteLine($"{guid} {GetType().Name}.{nameof(PushPageAsync)} - url: {url}");
            IDictionary<string, object>? parametetersDictionary = new Dictionary<string, object>();
            var pathAndQuery = RouteToPush.Split('?');
            if(pathAndQuery.Length > 1)
            {
                var paramsCollection = HttpUtility.ParseQueryString(pathAndQuery[1]);
                parametetersDictionary = paramsCollection.ToDictionary();
            }

			// if the current page is a known tab path AND the path-part of the URL (i.e. pathAndQuery[0] ) starts with a known tab path AND more path node(s) exist,
			// then we must navigate to the known tab path first, and then navigate to the remaining path in a separate navigation step:
			var parameters = new ShellNavigationQueryParameters(parametetersDictionary);
			if(NavigationHelper.TryGetKnownTabSubpath(pathAndQuery[0], out var tabPath, out var remainingRelativePath))
			{
				//Trace.WriteLine($"{guid} {GetType().Name}.{nameof(PushPageAsync)} - step1: navigating to path: {tabPath} parameters: {parametetersDictionary.ToDebugString()}");
				await Shell.Current.GoToAsync(tabPath, true, parameters);
				//Trace.WriteLine($"{guid} {GetType().Name}.{nameof(PushPageAsync)} - step2: navigating to path: {remainingRelativePath} parameters: {parametetersDictionary.ToDebugString()}");
				await Shell.Current.GoToAsync(remainingRelativePath, true, parameters);
			}
			// otherwise, we navigate normally:
			else
			{
				//Trace.WriteLine($"{guid} {GetType().Name}.{nameof(PushPageAsync)} - navigating to path: {pathAndQuery[0]} parameters: {parametetersDictionary.ToDebugString()}");
				await Shell.Current.GoToAsync(pathAndQuery[0], true, parameters);
			}

        }
        catch (Exception exc)
        {
            Trace.WriteLine($"{guid} {GetType().Name}.{nameof(PushPageAsync)} caught a {exc.GetType().Name}: {exc.Message}");
            await Shell.Current.DisplayAlert(exc.GetType().Name, exc.Message, "OK");
        }
    }
}
