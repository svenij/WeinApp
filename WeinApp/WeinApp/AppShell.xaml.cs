using System;
using System.Collections.Generic;
using WeinApp.ViewModels;
using WeinApp.Views;
using Xamarin.Forms;

namespace WeinApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(WineDetailPage), typeof(WineDetailPage));
            Routing.RegisterRoute(nameof(NewWinePage), typeof(NewWinePage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
