using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WeinApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public string Weinname
        {
            get => _weinname;
            set => SetProperty(ref _weinname, value);
        }

        public string Jahrgang
        {
            get => _jahrgang;
            set => SetProperty(ref _jahrgang, value);
        }
        public string Typ
        {
            get => _typ;
            set => SetProperty(ref _typ, value);
        }
        public string Herkunft
        {
            get => _herkunft;
            set => SetProperty(ref _herkunft, value);
        }
        public string Flaschengroesse
        {
            get => _flaschengroesse;
            set => SetProperty(ref _flaschengroesse, value);
        }
        public string AnzahlFlaschen
        {
            get => _anzahlFlaschen;
            set => SetProperty(ref _anzahlFlaschen, value);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(
          ref T backingStore,
          T value,
          [CallerMemberName] string propertyName = "",
          Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }

        private bool _isBusy;
        private string _weinname = string.Empty;
        private string _jahrgang = string.Empty;
        private string _typ = string.Empty;
        private string _herkunft = string.Empty;
        private string _flaschengroesse = string.Empty;
        private string _anzahlFlaschen = string.Empty;
    }
}
