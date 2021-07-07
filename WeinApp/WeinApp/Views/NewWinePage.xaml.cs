using System;
using System.Collections.Generic;
using System.ComponentModel;
using WeinApp.Models;
using WeinApp.Services;
using WeinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeinApp.Views
{
    public partial class NewWinePage : ContentPage
    {
        public Wine Wine { get; set; }

        public NewWinePage()
        {
            InitializeComponent();

            //_wineSaver = App.Services.GetInstance<IWineSaver>();
           Wine = new Wine();

            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {

        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        //private readonly IWineSaver _wineSaver;
    }
}