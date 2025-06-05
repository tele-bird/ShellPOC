using Microsoft.Maui.Controls.Shapes;
using ShellPOC.Helpers;
using ShellPOC.ViewModels;

namespace ShellPOC.Views;

public abstract class MarketDrawer<TMarketViewModel> : BaseMarketPage<TMarketViewModel>
    where TMarketViewModel : BaseMarketViewModel
{

#if IOS
    private const uint InitialPosition = 50;
#endif
#if ANDROID
    private const uint InitialPosition = 0;
#endif

    private double positionY;
    private VerticalStackLayout backdropStack;
    private Border drawerContent;
    private Grid topBar;


    public static readonly BindableProperty ContentHeightProperty =
        BindableProperty.Create(nameof(ContentHeightProperty), typeof(double?), typeof(MarketDrawer<TMarketViewModel>));

    public double? ContentHeight
    {
        get => (double?)GetValue(ContentHeightProperty);
        set => SetValue(ContentHeightProperty, value);
    }

    public static readonly BindableProperty CloseOnSwipeProperty =
      BindableProperty.Create(nameof(CloseOnSwipeProperty), typeof(bool), typeof(MarketDrawer<TMarketViewModel>), true);

    public bool CloseOnSwipe
    {
        get => (bool)GetValue(CloseOnSwipeProperty);
        set => SetValue(CloseOnSwipeProperty, value);
    }

    public static readonly BindableProperty CloseButtonProperty =
    BindableProperty.Create(nameof(CloseButtonProperty), typeof(bool), typeof(MarketDrawer<TMarketViewModel>), false);

    public bool CloseButton
    {
        get => (bool)GetValue(CloseButtonProperty);
        set => SetValue(CloseButtonProperty, value);
    }

    public static readonly BindableProperty DrawerColorProperty =
     BindableProperty.Create(nameof(DrawerColorProperty), typeof(Color), typeof(MarketDrawer<TMarketViewModel>));

    public Color? DrawerColor
    {
        get => (Color?)GetValue(DrawerColorProperty);
        set => SetValue(DrawerColorProperty, value);
    }

    protected MarketDrawer(TMarketViewModel baseViewModel) : base(baseViewModel)
    {
        ControlTemplate = CreateDrawerControlTemplate();

        BackgroundColor = Colors.Transparent;
        Shell.SetPresentationMode(this, PresentationMode.ModalNotAnimated);
    }

    public async Task Open()
    {
        await drawerContent.TranslateTo(0, InitialPosition, 250, Easing.CubicIn);
        await backdropStack.FadeTo(0.5, 100, Easing.CubicIn);
        
    }

    public async Task Close()
    {
        _ = backdropStack.FadeTo(0, 250, Easing.CubicOut);
        await drawerContent.TranslateTo(0, ContentHeight!.Value + InitialPosition, 250, Easing.CubicOut);
        await Shell.Current.GoToAsync("..");
    }

    private ControlTemplate CreateDrawerControlTemplate()
    {
        return new ControlTemplate(() =>
        {
            var rootGrid = new Grid
            {
                BackgroundColor = Colors.Transparent
            };

            backdropStack = new VerticalStackLayout
            {
                BackgroundColor = Colors.Black,
                Opacity = 0,
                Margin = new Thickness(0, -5, 0, 0),
            };
            var backdropTap = new TapGestureRecognizer();
            backdropTap.Tapped += Backdrop_Tapped;
            backdropStack.GestureRecognizers.Add(backdropTap);

            drawerContent = new Border
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.End,
                Stroke = Colors.Transparent,
                StrokeThickness = 0,
                HeightRequest = 0
            };

            drawerContent.Loaded += Drawer_Loaded;

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += Drawer_Panning;
            drawerContent.GestureRecognizers.Add(panGesture);

            drawerContent.StrokeShape = new RoundRectangle
            {
                CornerRadius = new CornerRadius(5, 5, 0, 0)
            };

            var contentGrid = new VerticalStackLayout();

            topBar = new Grid()
            {
                HeightRequest = 30,
                ColumnDefinitions = [
                    new ColumnDefinition(GridLength.Star),
                    new ColumnDefinition(GridLength.Star),
                    new ColumnDefinition(GridLength.Star)],
            };

            var dragHandle = new RoundRectangle
            {
                BackgroundColor = Colors.Gray,
                WidthRequest = 50,
                HeightRequest = 9,
                CornerRadius = new CornerRadius(5),
            };

            dragHandle.SetBinding(IsVisibleProperty, new Binding("CloseOnSwipe")
            {
                Source = RelativeBindingSource.TemplatedParent
            });

            topBar.Children.Add(dragHandle);
            topBar.SetColumn(dragHandle, 1);

            var closeButton = new ImageButton
            {
                HorizontalOptions = LayoutOptions.End,
                HeightRequest = 15,
                WidthRequest = 15,
                Margin = new Thickness(0, 15, 15, 0)
            };
            closeButton.Clicked += CloseButton_Clicked;
            var fontImageSource = new FontImageSource
            {
                Color = Colors.Black,
                FontFamily = "Juniper",
                Glyph = FontHelper.JuniperClose,
                Size = 16
            };
            closeButton.Source = fontImageSource;

            closeButton.SetBinding(IsVisibleProperty, new Binding("CloseButton")
            {
                Source = RelativeBindingSource.TemplatedParent
            });

            topBar.Children.Add(closeButton);
            topBar.SetColumn(closeButton, 2);

            contentGrid.Children.Add(topBar);

            contentGrid.Children.Add(new ContentPresenter());

            drawerContent.Content = contentGrid;

            rootGrid.Children.Add(backdropStack);
            rootGrid.Children.Add(drawerContent);

            return rootGrid;
        });
    }

    //This function is called only when Height is not defined.
    private double GetMaxHeight()
    {
        int statusBarHeight = 0;
        int navBarHeight = 0;

#if ANDROID

        int statusBarId = Platform.CurrentActivity.ApplicationContext.Resources.GetIdentifier("status_bar_height", "dimen", "android");
        statusBarHeight = Platform.CurrentActivity.ApplicationContext.Resources.GetDimensionPixelSize(statusBarId);

        var navBarId = Platform.CurrentActivity.ApplicationContext.Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
        navBarHeight = Platform.CurrentActivity.ApplicationContext.Resources.GetDimensionPixelSize(navBarId);
#endif

        return (DeviceDisplay.Current.MainDisplayInfo.Height - statusBarHeight - navBarHeight) / DeviceDisplay.Current.MainDisplayInfo.Density;
    }

    private async void Drawer_Loaded(object? sender, EventArgs e)
    {
        //If there is no Height defined at this point then set the Maximum Value.
        ContentHeight = ContentHeight ?? GetMaxHeight();

        drawerContent.HeightRequest = ContentHeight.Value;
        drawerContent.TranslationY = ContentHeight.Value;


        //If there is no DrawerColor defined at this point then set the Default Value.
        DrawerColor = DrawerColor ?? Colors.Aqua;


        drawerContent.BackgroundColor = DrawerColor;
        topBar.BackgroundColor = drawerContent.BackgroundColor;

        await Open();
    }

    private async void Backdrop_Tapped(object? sender, TappedEventArgs e)
    {
        await Close();
    }

    private async void Drawer_Panning(object? sender, PanUpdatedEventArgs e)
    {
        if (!CloseOnSwipe) { return; }

        switch (e.StatusType)
        {
            case GestureStatus.Running:
#if IOS
                positionY = e.TotalY + InitialPosition;
#elif ANDROID
                positionY += e.TotalY;
#endif

                if (positionY >= InitialPosition)
                    drawerContent.TranslationY = positionY;
                else
                    positionY = InitialPosition;
                break;

            case GestureStatus.Completed:
                positionY = InitialPosition;

                if (drawerContent.TranslationY >= (ContentHeight!.Value / 3)) //Close popup when Y position is more than one third of height.
                    await Close();
                else
                    await Open();
                break;
        }
    }

    private async void CloseButton_Clicked(object? sender, EventArgs e)
    {
        await Close();
    }
}