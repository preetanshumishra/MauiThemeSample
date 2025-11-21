using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MauiThemeSample.Services.Contracts;
using MauiThemeSample.Services.Implementations;
using MauiThemeSample.ViewModels;
using MauiThemeSample.Views;

namespace MauiThemeSample;

public static class MauiProgram
{
	public static IServiceProvider ServiceProvider { get; private set; } = null!;

	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Register services
		var services = new ServiceCollection();

		// Services
		services.AddSingleton<IThemeService, ThemeService>();

		// ViewModels
		services.AddSingleton<HomePageViewModel>();
		services.AddSingleton<ProfilePageViewModel>();
		services.AddSingleton<ThemeSelectionPageViewModel>();

		// Views
		services.AddSingleton<AppShell>();
		services.AddSingleton<HomePage>();
		services.AddSingleton<ProfilePage>();
		services.AddSingleton<ThemeSelectionPage>();

		var serviceProvider = services.BuildServiceProvider();
		ServiceProvider = serviceProvider;

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
