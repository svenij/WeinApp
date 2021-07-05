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
        new Wine { Name = "Collazzi", Typ = "Rotwein", Jahrgang="2016", Land="Italien", Region="Toscana", Traubensorte="Merlot", Flaschengroesse="7dl"},
        new Wine { Name = "Le Volte", Typ = "Rotwein", Jahrgang="2017", Land="Italien", Region="Toscana",Traubensorte="Merlot", Flaschengroesse="7dl"},
        new Wine { Name = "Sapaio", Typ = "Rotwein", Jahrgang="2018", Land="Italien", Region="Toscana",Traubensorte="Merlot", Flaschengroesse="7dl"},
        new Wine { Name = "La Massa", Typ = "Rotwein", Jahrgang="2014", Land="Italien", Region="Toscana",Traubensorte="Merlot", Flaschengroesse="7dl"},
        new Wine { Name = "Montecastro", Typ = "Rotwein", Jahrgang="2018", Land="Italien", Region="Toscana",Traubensorte="Merlot", Flaschengroesse="1.5l"},
        new Wine { Name = "Dalla Cia ", Typ = "Weisswein", Jahrgang="2016", Land="Südafrika", Region="Stellenbosch",Traubensorte="Merlot", Flaschengroesse="7dl"},
        new Wine { Name = "Bricco dell'Uccellone", Typ = "Rotwein", Jahrgang="2017", Land="Italien", Region="Toscana",Traubensorte="Merlot", Flaschengroesse="7dl"},
        new Wine { Name = "Lani Ma", Typ = "Prosecco", Jahrgang="2019", Land="Italien", Region="Toscana",Traubensorte="Merlot", Flaschengroesse="1.5l"},
      };
        }
    }
}