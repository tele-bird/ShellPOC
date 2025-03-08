using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ShellPOC.ViewModels;

public abstract partial class BaseViewModel : ObservableObject, IDisposable
{
    protected Guid guid;
    private bool firstAppeared = false;

    protected BaseViewModel()
    {
        this.guid = Guid.NewGuid();
    }

[RelayCommand]
protected virtual async Task OnAppearing()
{
    Trace.WriteLine($"{guid} {GetType().Name}.{nameof(OnAppearing)} >>");
    if (!firstAppeared)
    {
        await OnFirstAppearing();
        firstAppeared = true;
    }
}

protected virtual Task OnFirstAppearing()
{
    Trace.WriteLine($"{guid} {GetType().Name}.{nameof(OnFirstAppearing)} >>");
    return Task.CompletedTask;
}

[RelayCommand]
protected virtual Task OnDisappearing()
{
    Trace.WriteLine($"{guid} {GetType().Name}.{nameof(OnDisappearing)} >>");
    return Task.CompletedTask;
}

    public virtual void Dispose()
    {
        Trace.WriteLine($"{guid} {GetType().Name}.{nameof(Dispose)} >>");
    }
}
