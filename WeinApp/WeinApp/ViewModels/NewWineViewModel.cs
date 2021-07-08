using System;
using WeinApp.Models;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    public class NewWineViewModel : BaseViewModel
    {
        private string weinname;
        private string jahrgang;
        public string typ;
        public string herkunft;
        public string flaschengroesse;
        public string anzahlFlaschen;

        public NewWineViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(weinname)
                && !String.IsNullOrWhiteSpace(jahrgang)
                 && !String.IsNullOrWhiteSpace(typ)
                  && !String.IsNullOrWhiteSpace(herkunft)
                   && !String.IsNullOrWhiteSpace(flaschengroesse)
                    && !String.IsNullOrWhiteSpace(anzahlFlaschen);
        }

        public string Weinname
        {
            get => weinname;
            set => SetProperty(ref weinname, value);
        }

        public string Jahrgang
        {
            get => jahrgang;
            set => SetProperty(ref jahrgang, value);
        }
        public string Typ
        {
            get => typ;
            set => SetProperty(ref typ, value);
        }
        public string Herkunft
        {
            get => herkunft;
            set => SetProperty(ref herkunft, value);
        }
        public string Flaschengroesse
        {
            get => flaschengroesse;
            set => SetProperty(ref flaschengroesse, value);
        }
        public string AnzahlFlaschen
        {
            get => anzahlFlaschen;
            set => SetProperty(ref anzahlFlaschen, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("//WinesPage");
        }

        private async void OnSave()
        {
            Wine newWine = new Wine()
            {
                Id = Guid.NewGuid().ToString(),
                Weinname = Weinname,
                Jahrgang = Jahrgang,
                Typ = typ,
                Herkunft = herkunft,
                Flaschengroesse = flaschengroesse,
                AnzahlFlaschen = anzahlFlaschen,
            };


            await DataStore.AddWineAsync(newWine);

            await Shell.Current.GoToAsync("//WinesPage");
        }
    }
}
