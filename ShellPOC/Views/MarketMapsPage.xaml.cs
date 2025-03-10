using ShellPOC.ViewModels;

namespace ShellPOC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MarketMapsPage : BaseMarketPage<MarketMapsViewModel>
{
	public MarketMapsPage(MarketMapsViewModel marketMapsViewModel)
		: base(marketMapsViewModel)
	{
		InitializeComponent();
	}
}
