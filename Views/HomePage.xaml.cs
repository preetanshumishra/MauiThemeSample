using MauiThemeSample.ViewModels;

namespace MauiThemeSample.Views
{
    public partial class HomePage
    {
        public HomePage(HomePageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}