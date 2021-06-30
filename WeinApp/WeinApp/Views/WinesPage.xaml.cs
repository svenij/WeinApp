using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeinApp.Models;
using WeinApp.ViewModels;
using WeinApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeinApp.Views
{
    public partial class WinesPage : ContentPage
    {
        public WinesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new WinesViewModel();
        }

        private async void OnAlbumSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var album = (Wine)layout.BindingContext;
            //await Navigation.PushAsync(new WineDetailPage(new WineDetailViewModel(wine)));
        }

        private async void AddAlbumClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewWinePage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Items.Count == 0)
            {
                _viewModel.IsBusy = true;
            }
        }

        private readonly WinesViewModel _viewModel;
    }
}
