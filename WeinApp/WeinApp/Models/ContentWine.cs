using System;
using System.Collections.Generic;
using System.Text;

namespace WeinApp.Models
{
    public class ContentWine : UniqueItem
    {
        public string Weinname { get; set; }

        public string Jahrgang { get; set; }
        public override string ToString()
        {
            return $"{Weinname}: {Jahrgang}";
        }
    }
}
