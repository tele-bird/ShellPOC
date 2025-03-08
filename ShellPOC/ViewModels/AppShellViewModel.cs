using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public partial class AppShellViewModel : BaseMarketViewModel
{
	protected override bool IsQueryParameterRequired => false;

	public AppShellViewModel(IAppStateManager appStateManager)
		: base(appStateManager)
	{
		RouteToPush = "test";
	}
}

