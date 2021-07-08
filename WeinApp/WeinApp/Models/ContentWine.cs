namespace WeinApp.Models
{
    public class ContentWine : UniqueItem
    {
        public string Weinname { get; set; }
        public string Jahrgang { get; set; }
        public string Typ { get; set; }
        public string Herkunft { get; set; }
        public string Flaschengroesse { get; set; }
        public string AnzahlFlaschen { get; set; }
    }
}
