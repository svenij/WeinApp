using System;
using System.Collections.Generic;
using System.Text;

namespace WeinApp.Services
{
    public class WineMockDataStore : MockDataStore<Wine>
    {
        public WineMockDataStore()
        {
            Wines = new List<Wine>()
      {
        new Wine { Title = "First album", Description = "This is an album description." },
        new Wine { Title = "Second album", Description = "This is an album description." },
        new Wine { Title = "Third album", Description = "This is an album description." },
        new Wine { Title = "Fourth album", Description = "This is an album description." },
        new Wine { Title = "Fifth album", Description = "This is an album description." },
        new Wine { Title = "Sixth album", Description = "This is an album description." }
      };
        }
    }
}