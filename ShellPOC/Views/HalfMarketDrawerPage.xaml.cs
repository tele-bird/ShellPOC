using ShellPOC.ViewModels;

namespace ShellPOC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HalfMarketDrawerPage : MarketDrawer<HalfMarketDrawerViewModel>
{
    public HalfMarketDrawerPage(HalfMarketDrawerViewModel halfMarketDrawerViewModel)
        : base(halfMarketDrawerViewModel)
    {
        InitializeComponent();
    }
}