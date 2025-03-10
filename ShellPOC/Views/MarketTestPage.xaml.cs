using ShellPOC.ViewModels;

namespace ShellPOC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MarketTestPage : BaseMarketPage<MarketTestViewModel>
{
	public MarketTestPage(MarketTestViewModel marketTestViewModel)
		: base(marketTestViewModel)
	{
		InitializeComponent();
	}
}
