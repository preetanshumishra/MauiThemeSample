using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiThemeSample.ViewModels
{
    public partial class HomePageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string welcomeMessage = "Welcome to MAUI Theme Sample!";
        
        [ObservableProperty]
        private string description = "This application demonstrates a dynamic theming system with 5 different color themes. Navigate to the Theme Selection page to change themes.";
        
        public HomePageViewModel()
        {
            Title = "Home";
        }
        
        [RelayCommand]
        private async Task GoToThemeSelection()
        {
            await Shell.Current.GoToAsync("///ThemeSelectionPage");
        }
    }
}