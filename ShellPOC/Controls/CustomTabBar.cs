using System.Windows.Input;

namespace ShellPOC.Controls;

public class CustomTabBar : TabBar
{
    public static BindableProperty CenterViewCommandProperty = 
        BindableProperty.Create(nameof(CenterViewCommand), typeof(ICommand), typeof(CustomTabBar));
    public ICommand? CenterViewCommand
    {
        get => (ICommand)GetValue(CenterViewCommandProperty);
        set => SetValue(CenterViewCommandProperty, value);
    }

    public static BindableProperty CenterViewImageSourceProperty =
        BindableProperty.Create(nameof(CenterViewImageSource), typeof(ImageSource), typeof(CustomTabBar));
    public ImageSource? CenterViewImageSource
    {
        get => (ImageSource)GetValue(CenterViewImageSourceProperty);
        set => SetValue(CenterViewImageSourceProperty, value);
    }

    public static BindableProperty CenterViewTextProperty =
        BindableProperty.Create(nameof(CenterViewText), typeof(string), typeof(CustomTabBar));
    public string? CenterViewText
    {
        get => (string)GetValue(CenterViewTextProperty);
        set => SetValue(CenterViewTextProperty, value);
    }

    public static BindableProperty CenterViewVisibleProperty =
        BindableProperty.Create(nameof(CenterViewVisible), typeof(bool), typeof(CustomTabBar));
    public bool CenterViewVisible
    {
        get => (bool)GetValue(CenterViewVisibleProperty);
        set => SetValue(CenterViewVisibleProperty, value);
    }

    public static BindableProperty CenterViewBackgroundColorProperty =
        BindableProperty.Create(nameof(CenterViewBackgroundColor), typeof(Color), typeof(CustomTabBar));
    public Color? CenterViewBackgroundColor
    {
        get => (Color)GetValue(CenterViewBackgroundColorProperty);
        set => SetValue(CenterViewBackgroundColorProperty, value);
    }
}
