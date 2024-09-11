using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ShellPOC.ViewModels
{
	public abstract partial class BaseViewModel : ObservableObject
	{
        [RelayCommand]
        async Task PushTestPageAsync()
        {
            try
            {
                await Shell.Current.GoToAsync("//market/plan/test");
                //await Shell.Current.GoToAsync("//market/plan");
            }
            catch (Exception exc)
            {
                Trace.WriteLine($"Caught a {exc.GetType().Name}: {exc.Message}");
            }
        }
    }
}

