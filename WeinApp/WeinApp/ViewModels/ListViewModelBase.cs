using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    public class ListViewModelBase<TWine, TPage> : WineViewModelBase<TWine>
    where TPage : class
    {
        public ObservableCollection<TWine> Wines { get; set; }

        public Command LoadWinesCommand { get; set; }

        public ListViewModelBase()
        {
            Weinname = "Browse";
            Wines = new ObservableCollection<TWine>();
            LoadWinesCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<TPage, TWine>(this, "AddWine", async (obj, wine) =>
            {
                Wines.Add(wine);
                await DataStore.AddWineAsync(wine);
            });
        }

        private async Task ExecuteLoadItemsCommand()
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
    }
}