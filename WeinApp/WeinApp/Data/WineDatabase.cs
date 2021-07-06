using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeinApp.Models;

namespace WeinApp.Services
{
    public class WineDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<WineDatabase> Instance = new AsyncLazy<WineDatabase>(async () =>
        {
            var instance = new WineDatabase();
            CreateTableResult result = await Database.CreateTableAsync<Wine>();
            return instance;
        });

        public WineDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<Wine>> GetItemsAsync()
        {
            return Database.Table<Wine>().ToListAsync();
        }

        public Task<List<Wine>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<Wine>("SELECT * FROM [Wines] WHERE [Done] = 0");
        }

        public Task<Wine> GetItemAsync(int id)
        {
            return Database.Table<Wine>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Wine wine)
        {
            if (wine.Id != 0)
            {
                return Database.UpdateAsync(wine);
            }
            else
            {
                return Database.InsertAsync(wine);
            }
        }

        public Task<int> DeleteItemAsync(Wine wine)
        {
            return Database.DeleteAsync(wine);
        }
    }
}
