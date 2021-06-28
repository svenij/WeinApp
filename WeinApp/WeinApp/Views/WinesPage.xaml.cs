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
        WinesViewModel _viewModel;

        public WinesPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new WinesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}