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

        public Command LoadItemsCommand { get; set; }

        public ListViewModelBase()
        {
            Title = "Browse";
            Wines = new ObservableCollection<TWine>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<TPage, TWine>(this, "AddWine", async (obj, item) =>
            {
                Wines.Add(item);
                await DataStore.AddWineAsync(item);
            });
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Wines.Clear();
                var items = await DataStore.GetWinesAsync(true);
                foreach (var item in items)
                {
                    Wines.Add(item);
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