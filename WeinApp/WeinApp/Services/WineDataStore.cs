using System.Threading.Tasks;
using WeinApp.Models;

namespace WeinApp.Services
{
    public class WineDataStore : SQLiteDataStore<Wine>
    {
        public override async Task Initialize()
        {
            await base.Initialize();
        }
    }
}