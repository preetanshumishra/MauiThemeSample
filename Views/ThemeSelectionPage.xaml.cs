using MauiThemeSample.ViewModels;

namespace MauiThemeSample.Views;

public partial class ThemeSelectionPage : ContentPage
{
    public ThemeSelectionPage(ThemeSelectionPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
