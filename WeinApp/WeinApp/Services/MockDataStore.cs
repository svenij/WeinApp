using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeinApp.Models;

namespace WeinApp.Services
{
    public class MockDataStore<T> : IDataStore<T>
    where T : UniqueItem
    {
        public Task Initialize()
        {
            return Task.CompletedTask;
        }

        public async Task<bool> AddWineAsync(T wine)
        {
            Wines.Add(wine);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateWineAsync(T wine)
        {
            var oldwine = Wines.FirstOrDefault(arg => arg.Id == wine.Id);
            Wines.Remove(oldwine);
            Wines.Add(wine);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteWineAsync(string id)
        {
            var oldwine = Wines.FirstOrDefault(arg => arg.Id == id);
            Wines.Remove(oldwine);

            return await Task.FromResult(true);
        }

        public async Task<T> GetWineAsync(string id)
        {
            return await Task.FromResult(Wines.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetWinesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Wines);
        }
        protected List<T> Wines { get; set; }
    }
}