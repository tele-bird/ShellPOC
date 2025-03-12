using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using ShellPOC.Controls;
using View = Android.Views.View;
using Button = Android.Widget.Button;

namespace ShellPOC.Renderers;

public partial class CustomShellRenderer : ShellRenderer
{
    protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
    {
        return new CustomShellItemRenderer(this);
    }
}

internal class CustomShellItemRenderer : ShellItemRenderer
{
    public CustomShellItemRenderer(IShellContext context) : base(context)
    {
    }
    
    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        var view = base.OnCreateView(inflater, container, savedInstanceState);
        if (Context is not null && ShellItem is CustomTabBar { CenterViewVisible: true } tabbar)
        {
            var rootLayout = new FrameLayout(Context)
            {
                LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            };
            rootLayout.AddView(view);
            const int middleViewSize = 150;
            var middleViewLayoutParams = new FrameLayout.LayoutParams(
                ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent,
                GravityFlags.CenterHorizontal | GravityFlags.Bottom)
            {
                BottomMargin = 100,
                Width = middleViewSize,
                Height = middleViewSize
            };
            var middleView = new Button(Context)
            {
                LayoutParameters = middleViewLayoutParams
            };
            middleView.Click += delegate
            {
                tabbar.CenterViewCommand?.Execute(null);
            };
            middleView.SetText(tabbar.CenterViewText, TextView.BufferType.Normal);
            middleView.SetPadding(0, 0, 0, 0);
            if (tabbar.CenterViewBackgroundColor is not null)
            {
                var backgroundDrawable = new GradientDrawable();
                backgroundDrawable.SetShape(ShapeType.Rectangle);
                backgroundDrawable.SetCornerRadius(middleViewSize / 2f);
                backgroundDrawable.SetColor(tabbar.CenterViewBackgroundColor.ToPlatform(Colors.Transparent));
                middleView.Background = backgroundDrawable;
            }
            tabbar.CenterViewImageSource?.LoadImage(Application.Current!.MainPage!.Handler!.MauiContext!, result =>
            {
                middleView.Background = result?.Value;
                middleView.SetMinimumHeight(0);
                middleView.SetMinimumWidth(0);
            });
            rootLayout.AddView(middleView);
            return rootLayout;
        }
        return view;
    }
}