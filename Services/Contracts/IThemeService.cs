using MauiThemeSample.Enums;

namespace MauiThemeSample.Services.Contracts;

public interface IThemeService
{
    Theme CurrentTheme { get; }
    Task ChangeThemeAsync(Theme theme);
    Task LoadThemeAsync();
}
