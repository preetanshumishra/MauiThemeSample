using CommunityToolkit.Mvvm.ComponentModel;
using MauiThemeSample.Enums;

namespace MauiThemeSample.Models;

public partial class ThemeModel : ObservableObject
{
    [ObservableProperty]
    private Theme theme;

    [ObservableProperty]
    private string themeTitle = string.Empty;

    [ObservableProperty]
    private string description = string.Empty;

    [ObservableProperty]
    private bool isSelected;

    public ThemeModel(Theme theme, string themeTitle, string description, bool isSelected = false)
    {
        Theme = theme;
        ThemeTitle = themeTitle;
        Description = description;
        IsSelected = isSelected;
    }
}
