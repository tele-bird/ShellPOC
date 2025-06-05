using Microsoft.Extensions.Logging;
using ShellPOC.Services;
using ShellPOC.ViewModels;
using ShellPOC.Views;
using CommunityToolkit.Maui;

namespace ShellPOC;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Juniper.ttf", "Juniper");
			});

        // services:
        builder.Services.AddSingleton<IAppStateManager, AppStateManager>();

        // views and view models:
        builder.Services.AddSingleton<AppShell, AppShellViewModel>();
        builder.Services.AddSingleton<LandingPage, LandingPageViewModel>();
        builder.Services.AddSingleton<MarketBrandsPage, MarketBrandsViewModel>();
        builder.Services.AddSingleton<MarketHomePage, MarketHomeViewModel>();
        builder.Services.AddSingleton<MarketMapsPage, MarketMapsViewModel>();
        builder.Services.AddSingleton<MarketPlanPage, MarketPlanViewModel>();
        builder.Services.AddTransient<MarketTestPage, MarketTestViewModel>();
        builder.Services.AddTransient<FullMarketDrawerPage, FullMarketDrawerViewModel>();
        builder.Services.AddTransient<HalfMarketDrawerPage, HalfMarketDrawerViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

