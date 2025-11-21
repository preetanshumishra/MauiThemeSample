using MauiThemeSample.Services.Contracts;

namespace MauiThemeSample
{
	public partial class App
	{
		public App()
		{
			InitializeComponent();
		}
		
		protected override Window CreateWindow(IActivationState? activationState)
		{
			var window = new Window(new AppShell());
			
			// Load the saved theme after the window is created
			MainThread.BeginInvokeOnMainThread(async void () =>
			{
				try
				{
					var themeService = MauiProgram.ServiceProvider.GetRequiredService<IThemeService>();
					await themeService.LoadThemeAsync();
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine($"Error loading theme: {ex.Message}");
				}
			});
			
			return window;
		}
	}
}