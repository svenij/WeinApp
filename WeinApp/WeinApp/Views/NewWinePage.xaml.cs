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
        private readonly IWineSaver _wineSaver;

        public NewWinePage()
        {
            InitializeComponent();

            _wineSaver = DependencyService.Get<IWineSaver>();
            Wine = new Wine();

            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (await _wineSaver.TrySaveAsync(Wine))
            {
                MessagingCenter.Send(this, "AddItem", Wine);
                await Navigation.PopModalAsync();
            }
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        
    }
}