using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeinApp.Services
{
    public class SQLiteDataStore <T>: IDataStore<T>
    where T : new()
    {
        public SQLiteDataStore()
        {
            var options = new SQLiteConnectionString(DatabasePath);
            _connection = new SQLiteAsyncConnection(options);
        }
        public async Task Initialize() { 
            // Check whether our table already exists. If not, we're creating it here.
            if (_connection.TableMappings.All(x => !x.TableName.Equals(typeof(T).Name, StringComparison.InvariantCultureIgnoreCase)))
            {
               await _connection.CreateTableAsync<T>();
            }
        }

        public async Task<bool> AddWineAsync(T wine)
        {
            return await _connection.InsertAsync(wine) ==1;
        }

        public async Task<bool> DeleteWineAsync(string id)
        {
            return await _connection.DeleteAsync<T>(id) == 1;
        }

        public Task<T> GetWineAsync(string id)
        {
            return _connection.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetWinesAsync(bool forceRefresh = false)
        {
            return await _connection.Table<T>().ToListAsync();
        }

        public async Task<bool> UpdateWineAsync(T wine)
        {
            return await _connection.UpdateAsync(wine) == 1;
        }

        protected SQLiteAsyncConnection _connection { get; }

        /// <summary>
        /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
        /// </summary>
        private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Wines.db3");
    }
}