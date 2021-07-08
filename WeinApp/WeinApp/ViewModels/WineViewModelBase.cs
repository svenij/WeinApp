using WeinApp.Services;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    public class WineViewModelBase<T> : ViewModelBase
    {
        protected IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
    }
}
