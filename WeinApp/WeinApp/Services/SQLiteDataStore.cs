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
               await _connection.CreateTable<T>();
            }
        }

        public Task<bool> AddWineAsync(T item)
        {
            var itemInsertedCount = Connection.Insert(item);

            return Task.FromResult(itemInsertedCount == 1);
        }

        public Task<bool> DeleteWineAsync(string id)
        {
            var itemDeletedCount = Connection.Delete<T>(id);

            return Task.FromResult(itemDeletedCount == 1);
        }

        public Task<T> GetWineAsync(string id)
        {
            var result = Connection.Get<T>(id);

            return Task.FromResult(result);
        }

        public Task<IEnumerable<T>> GetWinesAsync(bool forceRefresh = false)
        {
            IEnumerable<T> allItems = Connection.Table<T>().ToList();

            return Task.FromResult(allItems);
        }

        public Task<bool> UpdateWineAsync(T item)
        {
            var itemUpdatedCount = Connection.Update(item);

            return Task.FromResult(itemUpdatedCount == 1);
        }

        protected SQLiteConnection Connection { get; }

        /// <summary>
        /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
        /// </summary>
        private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Albums.db3");
    }
}