using CommunityToolkit.Maui.Behaviors;
using ShellPOC.ViewModels;

namespace ShellPOC.Views;

public abstract partial class BaseContentPage<TBaseViewModel> : ContentPage
    where TBaseViewModel : BaseViewModel
{
    protected TBaseViewModel ViewModel => (TBaseViewModel)BindingContext;

    protected BaseContentPage(TBaseViewModel baseViewModel)
    {
        BindingContext = baseViewModel;

        // page lifecycle events:
        Behaviors.Add(new EventToCommandBehavior
        {
            EventName = nameof(Appearing),
            Command = ViewModel.AppearingCommand
        });
        Behaviors.Add(new EventToCommandBehavior
        {
            EventName = nameof(Disappearing),
            Command = ViewModel.DisappearingCommand
        });
    }
}
