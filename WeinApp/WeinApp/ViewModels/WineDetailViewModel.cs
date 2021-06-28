using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WeinApp.Models;
using Xamarin.Forms;

namespace WeinApp.ViewModels
{
    public class WineDetailViewModel : WineViewModelBase<Wine>
    {
        public WineDetailViewModel(Wine wine = null)
        {
            Title = wine?.Title;
            Wine = wine;
        }

        public Wine Wine { get; set; }
    }
}

