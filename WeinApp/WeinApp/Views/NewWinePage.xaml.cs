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

            _wineSaver = DependencyService.Get<IWineSaver>();
            Wine = new Wine();

            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            //if (await _wineSaver.TrySaveAsync(Wine))
            //{
            //    MessagingCenter.Send(this, "AddItem", Wine);
            //    await Navigation.PopModalAsync();
            //}
                       
                var wine = (Wine)BindingContext;
                WineDatabase database = await WineDatabase.Instance;
                await database.SaveItemAsync(wine);

                // Navigate backwards
                await Navigation.PopAsync();
            
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private readonly IWineSaver _wineSaver;
    }
}