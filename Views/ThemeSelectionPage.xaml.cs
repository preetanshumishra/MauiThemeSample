using MauiThemeSample.ViewModels;

namespace MauiThemeSample.Views
{
    public partial class ThemeSelectionPage
    {
        public ThemeSelectionPage(ThemeSelectionPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}