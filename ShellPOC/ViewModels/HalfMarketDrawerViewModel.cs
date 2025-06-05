using ShellPOC.Models;
using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public class HalfMarketDrawerViewModel : BaseMarketViewModel
{
    protected override bool IsQueryParameterRequired => true;

    public HalfMarketDrawerViewModel(IAppStateManager appStateManager)
        : base(
            appStateManager, 
            new ShellPage("..", "Back one page with the same market selected"),
            new ShellPage("//landing", "Back to Landing page with no market selected"),
            new ShellPage("fulldrawer", "Full drawer pushed atop this page with the same market selected"),
            new ShellPage("halfdrawer", "Half drawer pushed atop this page with the same market selected"),
            new ShellPage("test", "Test page pushed atop this page with the same market selected"),
            new ShellPage("test?marketId=4", "Test page pushed atop this page with market 4 selected"),
            new ShellPage("//market/home", "Home tab with the same market selected"),
            new ShellPage("//market/home?marketId=4", "Home tab with market 4 selected"),
            new ShellPage("//market/plan", "Plan tab with the same market selected"),
            new ShellPage("//market/plan?marketId=4", "Plan tab with market 4 selected"),
            new ShellPage("//market/maps", "Maps tab with the same market selected"),
            new ShellPage("//market/maps?marketId=4", "Maps tab with market 4 selected"))
    {
    }
}