﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WeinApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
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
        private string _title = string.Empty;
    }
}
