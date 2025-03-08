using CommunityToolkit.Mvvm.Input;
using ShellPOC.Services;

namespace ShellPOC.ViewModels;

public partial class LandingPageViewModel : BaseMarketViewModel
{
	protected override bool IsQueryParameterRequired => false;

    public LandingPageViewModel(IAppStateManager appStateManager)
        : base(appStateManager)
    {
    }

	protected override Task OnAppearing()
	{
		appStateManager.SelectedMarketId = null;
		return base.OnAppearing();
	}
}
