using System;
using WeinApp.Models;
using WeinApp.ViewModels;
using Xamarin.Forms;

namespace WeinApp.Views
{
    public partial class WinesPage : ContentPage
    {
        public WinesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new WinesViewModel();
        }

        private async void OnWineSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var wine = (Wine)layout.BindingContext;
            await Navigation.PushAsync(new WineDetailPage(new WineDetailViewModel(wine)));
        }

        private async void AddWinesClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewWinePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Wines.Count == 0)
            {
                _viewModel.IsBusy = true;
            }
        }

        private readonly WinesViewModel _viewModel;
    }
}
