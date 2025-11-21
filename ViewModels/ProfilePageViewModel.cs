using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiThemeSample.ViewModels;

public partial class ProfilePageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string userName = "John Doe";

    [ObservableProperty]
    private string userEmail = "john.doe@example.com";

    [ObservableProperty]
    private string userBio = "Passionate about cross-platform mobile development with .NET MAUI";

    public ProfilePageViewModel()
    {
        Title = "Profile";
    }
}
