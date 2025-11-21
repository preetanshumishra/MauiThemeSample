using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiThemeSample.Enums;
using MauiThemeSample.Models;
using MauiThemeSample.Services.Contracts;
using System.Collections.ObjectModel;

namespace MauiThemeSample.ViewModels;

public partial class ThemeSelectionPageViewModel : BaseViewModel
{
    private readonly IThemeService _themeService;

    [ObservableProperty]
    private ObservableCollection<ThemeModel> themes = [];

    public ThemeSelectionPageViewModel(IThemeService themeService)
    {
        _themeService = themeService;
        Title = "Theme Selection";

        InitializeThemes();
    }

    private void InitializeThemes()
    {
        Themes.Add(new ThemeModel(Theme.Light, "Light", "Light theme with neutral colors", _themeService.CurrentTheme == Theme.Light));
        Themes.Add(new ThemeModel(Theme.Dark, "Dark", "Dark theme with eye-friendly colors", _themeService.CurrentTheme == Theme.Dark));
        Themes.Add(new ThemeModel(Theme.Blue, "Blue", "Blue theme with cool tones", _themeService.CurrentTheme == Theme.Blue));
        Themes.Add(new ThemeModel(Theme.Orange, "Orange", "Orange theme with warm tones", _themeService.CurrentTheme == Theme.Orange));
        Themes.Add(new ThemeModel(Theme.White, "White", "White theme with minimal contrast", _themeService.CurrentTheme == Theme.White));
    }

    [RelayCommand]
    private async Task SelectTheme(ThemeModel theme)
    {
        if (theme == null)
            return;

        // Deselect all themes
        foreach (var t in Themes)
            t.IsSelected = false;

        // Select the chosen theme
        theme.IsSelected = true;

        // Apply the theme
        await _themeService.ChangeThemeAsync(theme.Theme);
    }
}
