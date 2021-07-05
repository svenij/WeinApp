using GenFu.ValueGenerators.Music;
using WeinApp.Models;
using WeinApp.Services;
using Xamarin.Forms;

namespace WeinApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<WineMockDataStore>();
            var dataStore = Services.GetInstance<IDataStore<Wine>>();
            dataStore.Initialize();

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
