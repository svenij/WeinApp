using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeinApp.Models;

namespace WeinApp.Services
{
    public class WineDataStore : SQLiteDataStore<Wine>
    {

        //public WineDataStore(IWebService<Album> albumsWebService)
        //{
        //    _albumsWebService = albumsWebService;
        //}

        public override async Task Initialize()
        {
            await base.Initialize();

            //var initialAlbums = await _albumsWebService.Get();
            //await Connection.InsertAllAsync(initialWines);
        }
  //private readonly IWebService<Album> _albumsWebService;
    }
}