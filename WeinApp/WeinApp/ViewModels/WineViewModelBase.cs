using WeinApp.Services;

namespace WeinApp.ViewModels
{
    public class WineViewModelBase<T> : ViewModelBase
    {
        //protected IDataStore<T> DataStore => App.WeinApp.Services.GetInstance<IDataStore<T>>();

        protected IDataStore<T> DataStore => App.Services.GetInstance<IDataStore<T>>();
    }
}
