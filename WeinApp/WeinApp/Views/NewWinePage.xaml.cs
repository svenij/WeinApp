using WeinApp.Models;
using WeinApp.ViewModels;
using Xamarin.Forms;

namespace WeinApp.Views
{
    public partial class NewWinePage : ContentPage
    {
        public Wine Wine { get; set; }

        public NewWinePage()
        {
            InitializeComponent();
            BindingContext = new NewWineViewModel();
        }
    }
}