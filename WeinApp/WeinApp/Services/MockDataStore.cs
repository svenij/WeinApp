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
        protected List<T> Items { get; set; }

        public async Task<bool> AddWineAsync(T wine)
        {
            Items.Add(wine);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateWineAsync(T wine)
        {
            var oldWine = Items.FirstOrDefault(arg => arg.Id == wine.Id);
            Items.Remove(oldWine);
            Items.Add(wine);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteWineAsync(string id)
        {
            var oldWine = Items.FirstOrDefault(arg => arg.Id == id);
            Items.Remove(oldWine);

            return await Task.FromResult(true);
        }

        public async Task<T> GetWineAsync(string id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetWinesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}