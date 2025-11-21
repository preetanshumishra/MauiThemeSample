using MauiThemeSample.ViewModels;

namespace MauiThemeSample.Views
{
    public partial class ProfilePage
    {
        public ProfilePage(ProfilePageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}