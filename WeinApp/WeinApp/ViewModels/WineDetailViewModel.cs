using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WeinApp.Models;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    [QueryProperty(nameof(WineId), nameof(WineId))]
    public class WineDetailViewModel : BaseViewModel
    {
        private string wineId;
        private string type;
        private string origin;
        private string vintage;
        private string wineName;

        public string Id { get; set; }

        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        public string Origin
        {
            get => origin;
            set => SetProperty(ref origin, value);
        }

        public string Vintage
        {
            get => vintage;
            set => SetProperty(ref vintage, value);
        }
        public string WineName
        {
            get => wineName;
            set => SetProperty(ref wineName, value);
        }

        public string WineId
        {
            get
            {
                return wineId;
            }
            set
            {
                wineId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string wineId)
        {
            try
            {
                var wine = await DataStore.GetWineAsync(wineId);
                Id = wine.Id;
                Type = wine.Type;
                Origin = wine.Origin;
                Vintage = wine.Vintage;
                WineName = wine.WineName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Fehler beim laden");
            }
        }
    }
}
