using System;
using WeinApp.Services;
using WeinApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeinApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStoreOld>();
            MainPage = new AppShell();
        }

        protected override async void OnStart()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
