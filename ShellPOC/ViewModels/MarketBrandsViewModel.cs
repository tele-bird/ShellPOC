using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public class MarketBrandsViewModel : BaseMarketViewModel
{
	protected override bool IsQueryParameterRequired => true;

    public MarketBrandsViewModel(IAppStateManager appStateManager)
        : base(appStateManager)
    {
    }
}
