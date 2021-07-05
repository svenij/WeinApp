using System;
using System.Collections.Generic;
using System.Text;
using WeinApp.Models;

namespace WeinApp.Services
{
    public class WineMockDataStore : MockDataStore<Wine>
    {
        public WineMockDataStore()
        {
            Wines = new List<Wine>()
      {
        new Wine { Name = "First album", Typ = "This is an album description." },
        new Wine { Name = "Second album", Typ = "This is an album description." },
        new Wine { Name = "Third album", Typ = "This is an album description." },
        new Wine { Name = "Fourth album", Typ = "This is an album description." },
        new Wine { Name = "Fifth album", Typ = "This is an album description." },
        new Wine { Name = "Sixth album", Typ = "This is an album description." }
      };
        }
    }
}