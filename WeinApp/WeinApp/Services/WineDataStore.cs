using System.Threading.Tasks;
using WeinApp.Models;

namespace WeinApp.Services
{
    public  class WineDataStore : SQLiteDataStore<Wine>
    {
        //private readonly IWebService<Wine> _albumsWebService;

        public WineDataStore(IWebService<Wine> winesWebService)
        {
            _winesWebService = winesWebService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            var initialWines = await _winesWebService.Get();

            await Connection.InsertAllAsync(initialWines);
        }

        private readonly IWebService<Wine> _winesWebService;
    }
}