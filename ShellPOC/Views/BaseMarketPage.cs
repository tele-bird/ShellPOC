using System.Diagnostics;
using ShellPOC.Extensions;
using ShellPOC.ViewModels;

namespace ShellPOC.Views;

public abstract partial class BaseMarketPage<TBaseMarketViewModel> : BaseContentPage<TBaseMarketViewModel>
  where TBaseMarketViewModel : BaseMarketViewModel
{
    protected BaseMarketPage(TBaseMarketViewModel baseMarketViewModel)
      : base(baseMarketViewModel)
    {
    }

	void OnSelectedRouteToPushChanged(object sender, CheckedChangedEventArgs args)
	{
		if(args.Value)
		{
			ViewModel.RouteToPush = ((RadioButton)sender).Value.ToString();
		}
	}
}
