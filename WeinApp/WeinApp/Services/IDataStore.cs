using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeinApp.Services
{
    public interface IDataStore<T>
    {
        Task Initialize();
        Task<bool> AddWineAsync(T item);
        Task<bool> UpdateWineAsync(T item);
        Task<bool> DeleteWineAsync(string id);
        Task<T> GetWineAsync(string id);
        Task<IEnumerable<T>> GetWinesAsync(bool forceRefresh = false);
    }
}
