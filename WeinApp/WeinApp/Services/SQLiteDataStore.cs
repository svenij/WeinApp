using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WeinApp.Services
{
    public class SQLiteDataStore<T> : IDataStore<T>
    where T : new()
    {
        public SQLiteDataStore()
        {
            var options = new SQLiteConnectionString(DatabasePath);
            Connection = new SQLiteAsyncConnection(options);
        }
        public virtual async Task Initialize()
        {
            if (Connection.TableMappings.All(x => !x.TableName.Equals(typeof(T).Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                await Connection.CreateTableAsync<T>();
            }
        }

        public async Task<bool> AddWineAsync(T wine)
        {
            return await Connection.InsertAsync(wine) == 1;
        }

        public async Task<bool> DeleteWineAsync(string id)
        {
            return await Connection.DeleteAsync<T>(id) == 1;
        }

        public Task<T> GetWineAsync(string id)
        {
            return Connection.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetWinesAsync(bool forceRefresh = false)
        {
            return await Connection.Table<T>().ToListAsync();
        }

        public async Task<bool> UpdateWineAsync(T wine)
        {
            return await Connection.UpdateAsync(wine) == 1;
        }

        protected SQLiteAsyncConnection Connection { get; private set; }

        private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Wines.db3");
    }
}