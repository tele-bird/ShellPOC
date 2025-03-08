using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public class MarketHomeViewModel : BaseMarketViewModel
{
	protected override bool IsQueryParameterRequired => true;

    public MarketHomeViewModel(IAppStateManager appStateManager)
        : base(appStateManager)
    {
    }
}
