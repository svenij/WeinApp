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
        public ObservableCollection<TWine> Items { get; set; }

        public Command LoadItemsCommand { get; set; }

        public ListViewModelBase()
        {
            Title = "Browse";
            Items = new ObservableCollection<TWine>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<TPage, TWine>(this, "AddWine", async (obj, item) =>
            {
                Items.Add(item);
                await DataStore.AddWineAsync(item);
            });
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetWinesAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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