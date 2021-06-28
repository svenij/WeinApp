using System.ComponentModel;
using WeinApp.ViewModels;
using Xamarin.Forms;

namespace WeinApp.Views
{
    public partial class WineDetailPage : ContentPage
    {
        public WineDetailPage()
        {
            InitializeComponent();
            BindingContext = new WineDetailViewModel();
        }
    }
}