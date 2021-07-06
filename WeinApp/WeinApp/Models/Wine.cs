using SQLite;
using System;

namespace WeinApp.Models
{
    public class Wine : ContentWine
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Weinname { get; set; }
        public string Jahrgang { get; set; }
        public string Typ { get; set; }
        public string Land { get; set; }
        public string Region { get; set; }
        public string Traubensorte { get; set; }
        public string Flaschengroesse { get; set; }
    }
}