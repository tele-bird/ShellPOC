using ShellPOC.ViewModels;

namespace ShellPOC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MarketHomePage : BaseMarketPage<MarketHomeViewModel>
{
	public MarketHomePage(MarketHomeViewModel marketHomeViewModel)
		: base(marketHomeViewModel)
	{
		InitializeComponent();
	}
}
