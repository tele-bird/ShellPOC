using ShellPOC.Models;
using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public partial class LandingPageViewModel : BaseMarketViewModel
{
	protected override bool IsQueryParameterRequired => false;

    public LandingPageViewModel(IAppStateManager appStateManager)
        : base(
			appStateManager, 
			new ShellPage("//market/home?marketId=123", "Home tab with marketId 123"),
			new ShellPage("fulldrawer", "Full drawer pushed atop this page with the same market selected"),
			new ShellPage("halfdrawer", "Half drawer pushed atop this page with the same market selected"),
			new ShellPage("//market/home/test?marketId=4", "Test page pushed atop Home tab with marketId 4"),
			new ShellPage("//market/brands?marketId=123", "Brands tab with marketId 123"),
			new ShellPage("//market/brands/test?marketId=4", "Test page pushed atop Brands tab with marketId 4"),
			new ShellPage("//market/plan?marketId=123", "Plan tab with marketId 123"),
			new ShellPage("//market/plan/test?marketId=4", "Test page pushed atop Plan tab with marketId 4"),
			new ShellPage("//market/maps?marketId=123", "Maps tab with marketId 123"),
			new ShellPage("//market/maps/test?marketId=4", "Test page pushed atop Maps tab with marketId 4"))
    {
    }

	protected override Task OnAppearing()
	{
		appStateManager.SelectedMarketId = null;
		return base.OnAppearing();
	}
}
