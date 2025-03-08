using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;

namespace ShellPOC.Controls;

public class MyTab : Tab
{
    protected override void OnInsertPageBefore(Page page, Page before)
    {
        Trace.WriteLine($"{GetType().Name}.{nameof(OnInsertPageBefore)} >> page: {page} before: {before}");
        base.OnInsertPageBefore(page, before);
    }
    protected override Task<Page> OnPopAsync(bool animated)
    {
        Trace.WriteLine($"{GetType().Name}.{nameof(OnPopAsync)} >> animated: {animated}");
        return base.OnPopAsync(animated);
    }
    protected override Task OnPopToRootAsync(bool animated)
    {
        Trace.WriteLine($"{GetType().Name}.{nameof(OnPopToRootAsync)} >> animated: {animated}");
        return base.OnPopToRootAsync(animated);
    }
    protected override Task OnPushAsync(Page page, bool animated)
    {
        Trace.WriteLine($"{GetType().Name}.{nameof(OnPushAsync)} >> page: {page} animated: {animated}");
        return base.OnPushAsync(page, animated);
    }
    protected override void OnRemovePage(Page page)
    {
        Trace.WriteLine($"{GetType().Name}.{nameof(OnRemovePage)} >> page: {page}");
        base.OnRemovePage(page);
    }
}
