using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public class MarketTestViewModel : BaseMarketViewModel
{
	protected override bool IsQueryParameterRequired => true;

    public MarketTestViewModel(IAppStateManager appStateManager)
        : base(appStateManager)
    {
    }
}
