using MauiThemeSample.ViewModels;

namespace MauiThemeSample.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfilePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
