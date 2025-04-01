using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Android.Content;
using ShellItem = Microsoft.Maui.Controls.ShellItem;
using Google.Android.Material.BottomNavigation;

namespace ShellPOC.Renderers;

public partial class CustomShellRenderer : ShellRenderer
{
    public CustomShellRenderer(Context context)
        : base(context)
    {
    }

    protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
    {
        return new CustomShellBottomNavViewAppearanceTracker(this, shellItem);
    }
}

public class CustomShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
{
    public CustomShellBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) 
        : base(shellContext, shellItem)
    {
    }

    public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
    {
        if(bottomView.LayoutParameters != null)
        {
            bottomView.LayoutParameters.Height = 200;
        }
        base.SetAppearance(bottomView, appearance);
    }
}