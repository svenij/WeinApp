using System;
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
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
