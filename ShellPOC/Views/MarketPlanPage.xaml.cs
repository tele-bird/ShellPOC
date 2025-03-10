using ShellPOC.ViewModels;

namespace ShellPOC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MarketPlanPage : BaseMarketPage<MarketPlanViewModel>
{
	public MarketPlanPage(MarketPlanViewModel marketPlanViewModel)
		: base(marketPlanViewModel)
	{
		InitializeComponent();
	}
}
