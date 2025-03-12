using CoreGraphics;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using ShellPOC.Controls;
using UIKit;
using Application = Microsoft.Maui.Controls.Application;
using ShellItem = Microsoft.Maui.Controls.ShellItem;

namespace ShellPOC.Renderers;

public partial class CustomShellRenderer : ShellRenderer
{
    protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
    {
        return new CustomShellItemRenderer(this)
        {
            ShellItem = item
        };
    }
}

public class CustomShellItemRenderer : ShellItemRenderer
{
    UIButton? middleView;
    public CustomShellItemRenderer(IShellContext context) 
        : base(context)
    {
    }

    public override async void ViewWillLayoutSubviews()
    {
        base.ViewWillLayoutSubviews();
        if (View is not null && ShellItem is CustomTabBar { CenterViewVisible: true } tabbar)
        {
            if (middleView is not null)
            {
                middleView.RemoveFromSuperview();
            }
            if (middleView is null)
            {
                var image = await tabbar.CenterViewImageSource.GetPlatformImageAsync(Application.Current!.MainPage!.Handler!.MauiContext!);
                middleView = new UIButton(UIButtonType.Custom);
                middleView.BackgroundColor = tabbar.CenterViewBackgroundColor?.ToPlatform();
                middleView.SetTitle(tabbar.CenterViewText, UIControlState.Normal);
                middleView.Frame = new CGRect(CGPoint.Empty, new CGSize(70, 70));
                if (image is not null)
                {
                    middleView.SetImage(image.Value, UIControlState.Normal);
                    middleView.Frame = new CGRect(CGPoint.Empty, image.Value.Size);
                }
                middleView.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin |
                                              UIViewAutoresizing.FlexibleLeftMargin |
                                              UIViewAutoresizing.FlexibleBottomMargin;
                middleView.Layer.CornerRadius = middleView.Frame.Width / 2;
                middleView.Layer.MasksToBounds = false;
                middleView.TouchUpInside += (sender, e) =>
                {
                    tabbar.CenterViewCommand?.Execute(null);
                };
            }
            middleView.Center = new CGPoint(View.Bounds.GetMidX(), TabBar.Frame.Top - middleView.Frame.Height / 2);
            View.AddSubview(middleView);
        }
    }
}