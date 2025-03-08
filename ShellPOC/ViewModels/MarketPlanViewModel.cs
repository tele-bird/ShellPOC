using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public class MarketPlanViewModel : BaseMarketViewModel
{
	protected override bool IsQueryParameterRequired => true;

    public MarketPlanViewModel(IAppStateManager appStateManager)
        : base(appStateManager)
    {
    }
}