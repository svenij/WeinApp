using WeinApp.Models;

namespace WeinApp.ViewModels
{
    public class WineDetailViewModel : WineViewModelBase<Wine>
    {
        public WineDetailViewModel(Wine wine = null)
        {
            Weinname = wine?.Weinname;
            Jahrgang = wine?.Jahrgang;
            Typ = wine?.Typ;
            Herkunft = wine?.Herkunft;
            Flaschengroesse = wine?.Flaschengroesse;
            AnzahlFlaschen = wine?.AnzahlFlaschen;

            Wine = wine;
        }

        public Wine Wine { get; set; }
    }
}

