using System.ComponentModel;
using WeinApp.ViewModels;
using Xamarin.Forms;
using System;
using WeinApp.Models;

namespace WeinApp.Views
{
    public partial class AlbumDetailPage : ContentPage
    {
        private readonly WineDetailViewModel _viewModel;

        public AlbumDetailPage(WineDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = _viewModel = viewModel;
        }

        public AlbumDetailPage()
        {
            InitializeComponent();

            var wine = new Wine
            {
                Title = "Album 1",
                Description = "This is an Album description."
            };

            _viewModel = new WineDetailViewModel(wine);
            BindingContext = _viewModel;
        }
    }
}
