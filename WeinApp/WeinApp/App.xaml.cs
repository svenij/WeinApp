using SimpleInjector;
using WeinApp.Core;
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
            DependencyService.Register<SQLiteDataStore<Wine>>();

            MainPage = new AppShell();
            Services = ContainerExtensions.CreateContainer();

        }

        public static Container Services { get; private set; }

        protected override async void OnStart()
        {
            await Shell.Current.GoToAsync("//LoginPage");
            await DependencyService.Get<SQLiteDataStore<Wine>>().Initialize();
        }

        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
