using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public class MarketMapsViewModel : BaseMarketViewModel
{
	protected override bool IsQueryParameterRequired => true;

    public MarketMapsViewModel(IAppStateManager appStateManager)
        : base(appStateManager)
    {
    }
}