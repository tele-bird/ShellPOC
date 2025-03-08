using ShellPOC.ViewModels;

namespace ShellPOC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MarketBrandsPage : BaseMarketPage<MarketBrandsViewModel>
{
	public MarketBrandsPage(MarketBrandsViewModel marketBrandsViewModel)
		: base(marketBrandsViewModel)
	{
		InitializeComponent();
		this.defaultRadioButton.IsChecked = true;
	}
}
