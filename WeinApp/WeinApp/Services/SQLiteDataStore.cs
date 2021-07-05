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
            _connection = new SQLiteConnection(options);

            // Check whether our table already exists. If not, we're creating it here.
            if (_connection.TableMappings.All(x => !x.TableName.Equals(typeof(T).Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                _connection.CreateTable<T>();
            }
        }

        public Task<bool> AddWineAsync(T wine)
        {
            var wineInsertedCount = _connection.Insert(wine);

            return Task.FromResult(wineInsertedCount == 1);
        }

        public Task<bool> DeleteWineAsync(string id)
        {
            var wineDeletedCount = _connection.Delete<T>(id);

            return Task.FromResult(wineDeletedCount == 1);
        }

        public Task<T> GetWineAsync(string id)
        {
            var result = _connection.Get<T>(id);

            return Task.FromResult(result);
        }

        public Task<IEnumerable<T>> GetWinesAsync(bool forceRefresh = false)
        {
            IEnumerable<T> allWines = _connection.Table<T>().ToList();

            return Task.FromResult(allWines);
        }

        public Task<bool> UpdateWineAsync(T wine)
        {
            var wineUpdatedCount = _connection.Update(wine);

            return Task.FromResult(wineUpdatedCount == 1);
        }

        private SQLiteConnection _connection;

        /// <summary>
        /// Gets the static path to the database. The <see cref="Environment.SpecialFolder"/> is used to resolve the right path.
        /// </summary>
        private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Albums.db3");
    }
}