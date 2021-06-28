using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeinApp.Models;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    public class NewWineViewModel : BaseViewModel
    {
        private string type;
        private string vintage;
        private string origin;
        private string wineName;

        public NewWineViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(type)
                && !String.IsNullOrWhiteSpace(vintage);
        }

        public string WineName
        {
            get => wineName;
            set => SetProperty(ref wineName, value);
        }

        public string Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }

        public string Vintage
        {
            get => vintage;
            set => SetProperty(ref vintage, value);
        }
        public string Origin
        {
            get => origin;
            set => SetProperty(ref origin, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Wine newWine = new Wine()
            {
                Id = Guid.NewGuid().ToString(),
                WineName = WineName,
                Vintage = Vintage,
                Origin = Origin,
                Type = Type
            };

            await DataStore.AddWineAsync(newWine);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
