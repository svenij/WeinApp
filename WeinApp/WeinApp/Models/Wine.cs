using System;

namespace WeinApp.Models
{
    public class Wine : ContentWine
    {
        public string Name { get; set; }

        public string Typ { get; set; }
        public string Jahrgang { get; set; }
        public string Land { get; set; }
        public string Region { get; set; }
    }
}