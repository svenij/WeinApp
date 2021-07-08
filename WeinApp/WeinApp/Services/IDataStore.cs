using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeinApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddWineAsync(T wine);
        Task<bool> UpdateWineAsync(T wine);
        Task<bool> DeleteWineAsync(string id);
        Task<T> GetWineAsync(string id);
        Task<IEnumerable<T>> GetWinesAsync(bool forceRefresh = false);
    }
}
