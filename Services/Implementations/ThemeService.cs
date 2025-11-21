using MauiThemeSample.Enums;
using MauiThemeSample.Services.Contracts;

namespace MauiThemeSample.Services.Implementations;

public class ThemeService : IThemeService
{
    private const string ThemeKey = "AppTheme";
    private Theme _currentTheme;

    public Theme CurrentTheme
    {
        get => _currentTheme;
        private set => _currentTheme = value;
    }

    public async Task ChangeThemeAsync(Theme theme)
    {
        CurrentTheme = theme;

        // Merge the appropriate resource dictionary
        var themeName = theme.ToString().ToLower();
        var resourceDictionary = new ResourceDictionary { Source = new Uri($"Themes/{themeName}.xaml", UriKind.Relative) };

        Application.Current!.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);

        // Persist the theme preference
        Preferences.Default.Set(ThemeKey, (int)theme);
        await Task.CompletedTask;
    }

    public async Task LoadThemeAsync()
    {
        // Load the previously saved theme or default to Light
        var savedTheme = Preferences.Default.Get(ThemeKey, (int)Theme.Light);
        var theme = (Theme)savedTheme;

        await ChangeThemeAsync(theme);
    }
}
