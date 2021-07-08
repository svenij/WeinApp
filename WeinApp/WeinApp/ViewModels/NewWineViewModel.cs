using System;
using System.Collections.Generic;
using System.Text;
using WeinApp.Models;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    public class NewWineViewModel : BaseViewModel
    {
        private string weinname;
        private string jahrgang;

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
                && !String.IsNullOrWhiteSpace(jahrgang);
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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("//WinesPage");
        }

        private async void OnSave()
        {
            Wine newWine = new Wine()
            {
                Id = Guid.NewGuid().ToString(),
                Weinname = Weinname,
                Jahrgang = Jahrgang
            };

            await DataStore.AddWineAsync(newWine);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("//WinesPage");
        }
    }
}
