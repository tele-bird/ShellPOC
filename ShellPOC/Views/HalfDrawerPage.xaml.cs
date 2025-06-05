using ShellPOC.ViewModels;

namespace ShellPOC.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class HalfDrawerPage : Drawer<HalfDrawerViewModel>
{
    public HalfDrawerPage(HalfDrawerViewModel halfDrawerViewModel)
        : base(halfDrawerViewModel)
    {
        InitializeComponent();
    }
}