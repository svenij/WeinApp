using SimpleInjector;
using WeinApp.Core;
using WeinApp.Models;
using WeinApp.Services;
using WeinApp.Views;
using Xamarin.Forms;

namespace WeinApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            var mainPage = new AboutPage();
            var navigationPage = new NavigationPage(mainPage);

            Services = ContainerExtensions.CreateContainer();
            Services.RegisterInstance<Page>(navigationPage);

            //DependencyService.Register<WineMockDataStore>();
            var dataStore = Services.GetInstance<IDataStore<Wine>>();
            dataStore.Initialize();

            MainPage = navigationPage;
        }

        public static Container Services { get; private set; }

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
