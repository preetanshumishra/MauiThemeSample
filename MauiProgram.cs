using Microsoft.Extensions.Logging;
using MauiThemeSample.Services.Contracts;
using MauiThemeSample.Services.Implementations;
using MauiThemeSample.ViewModels;
using MauiThemeSample.Views;

namespace MauiThemeSample
{
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
			
			// Register services with the builder
			builder.Services.AddSingleton<IThemeService, ThemeService>();
			
			// ViewModels
			builder.Services.AddSingleton<HomePageViewModel>();
			builder.Services.AddSingleton<ProfilePageViewModel>();
			builder.Services.AddSingleton<ThemeSelectionPageViewModel>();
			
			// Views
			builder.Services.AddSingleton<AppShell>();
			builder.Services.AddSingleton<HomePage>();
			builder.Services.AddSingleton<ProfilePage>();
			builder.Services.AddSingleton<ThemeSelectionPage>();
			
#if DEBUG
			builder.Logging.AddDebug();
#endif
			
			var mauiApp = builder.Build();
			
			// Store the service provider for later use
			ServiceProvider = mauiApp.Services;
			
			return mauiApp;
		}
	}
}