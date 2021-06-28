using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WeinApp.Models;
using WeinApp.Views;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    public class WinesViewModel : BaseViewModel
    {
        private Wine _selectedWine;

        public ObservableCollection<Wine> Wines { get; }
        public Command LoadWinesCommand { get; }
        public Command AddWinesCommand { get; }
        public Command<Wine> WineTapped { get; }

        public WinesViewModel()
        {
            Title = "Weinkeller";
            Wines = new ObservableCollection<Wine>();
            LoadWinesCommand = new Command(async () => await ExecuteLoadWinesCommand());

            WineTapped = new Command<Wine>(OnWineSelected);

            AddWinesCommand = new Command(OnAddWine);
        }

        async Task ExecuteLoadWinesCommand()
        {
            IsBusy = true;

            try
            {
                Wines.Clear();
                var wines = await DataStore.GetWinesAsync(true);
                foreach (var wine in wines)
                {
                    Wines.Add(wine);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedWine = null;
        }

        public Wine SelectedWine
        {
            get => _selectedWine;
            set
            {
                SetProperty(ref _selectedWine, value);
                OnWineSelected(value);
            }
        }

        private async void OnAddWine(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewWinePage));
        }

        async void OnWineSelected(Wine wine)
        {
            if (wine == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(WineDetailPage)}?{nameof(WineDetailViewModel.WineId)}={wine.Id}");
        }
    }
}