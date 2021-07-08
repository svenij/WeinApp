using WeinApp.Models;
using WeinApp.ViewModels;
using Xamarin.Forms;

namespace WeinApp.Views
{
    public partial class WineDetailPage : ContentPage
    {
        private readonly WineDetailViewModel _viewModel;

        public WineDetailPage(WineDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        public WineDetailPage()
        {
            InitializeComponent();

            var wine = new Wine
            {
                Weinname = "Album 1",
                Jahrgang = "This is an Album description."
            };

            _viewModel = new WineDetailViewModel(wine);
            BindingContext = _viewModel;
        }
    }
}
