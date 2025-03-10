using System.Diagnostics;
using ShellPOC.Models;
using ShellPOC.ViewModels;

namespace ShellPOC.Views;

public partial class LandingPage : BaseMarketPage<LandingPageViewModel>
{
	public LandingPage(LandingPageViewModel landingPageViewModel)
		: base(landingPageViewModel)
	{
		InitializeComponent();
	}
}