using MauiThemeSample.Services.Contracts;

namespace MauiThemeSample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override async void OnStart()
	{
		base.OnStart();

		// Load the saved theme
		var themeService = MauiProgram.ServiceProvider.GetRequiredService<IThemeService>();
		await themeService.LoadThemeAsync();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}