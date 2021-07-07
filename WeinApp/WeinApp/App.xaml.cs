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
        public static bool IsUserLoggedIn { get; set; }

        public App()
        {
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new AppShell();
            }

            //InitializeComponent();

            var mainPage = new AboutPage();

            Services = ContainerExtensions.CreateContainer();
            Services.RegisterInstance<Page>(mainPage);

            //DependencyService.Register<WineMockDataStore>();
            var dataStore = Services.GetInstance<IDataStore<Wine>>();
            dataStore.Initialize();

            MainPage = mainPage;
        }

        public static Container Services { get; private set; }

        protected override void OnStart()
        {
            //await Shell.Current.GoToAsync("//LoginPage");
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
