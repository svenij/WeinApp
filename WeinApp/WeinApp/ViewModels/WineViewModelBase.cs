using System;
using System.Collections.Generic;
using System.Text;
using WeinApp.Services;

namespace WeinApp.ViewModels
{
    public class WineViewModelBase<T> : ViewModelBase
    {
        protected IDataStore<T> DataStore => App.Services.GetInstance<IDataStore<T>>();
    }
}
