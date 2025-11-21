using MauiThemeSample.Enums;
using MauiThemeSample.Services.Contracts;
using MauiThemeSample.Themes;

namespace MauiThemeSample.Services.Implementations
{
    public class ThemeService : IThemeService
    {
        private const string ThemeKey = "AppTheme";
        public Theme CurrentTheme { get; set; }
        
        public Task ChangeThemeAsync(Theme theme)
        {
            CurrentTheme = theme;
            
            if (Application.Current == null)
            {
                return Task.CompletedTask;
            }
            
            try
            {
                var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
                mergedDictionaries.Clear();
                
                switch (theme)
                {
                    case Theme.Light:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                    case Theme.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;
                    case Theme.Blue:
                        mergedDictionaries.Add(new BlueTheme());
                        break;
                    case Theme.Orange:
                        mergedDictionaries.Add(new OrangeTheme());
                        break;
                    case Theme.White:
                        mergedDictionaries.Add(new WhiteTheme());
                        break;
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }
                
                Preferences.Default.Set(ThemeKey, (int)theme);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error changing theme: {ex.Message}");
            }
            
            return Task.CompletedTask;
        }
        
        public async Task LoadThemeAsync()
        {
            var savedTheme = Preferences.Default.Get(ThemeKey, (int)Theme.Light);
            await ChangeThemeAsync((Theme)savedTheme);
        }
    }
}