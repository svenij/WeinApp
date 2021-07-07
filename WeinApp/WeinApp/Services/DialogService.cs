using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeinApp.Services
{
    public class DialogService : IDialogService
    {
        public DialogService(Page page)
        {
            _page = page;
        }

        public async Task Show(string title, string message)
        {
            await _page.DisplayAlert(title, message, "OK");
        }

        public async Task<bool> Show(string title, string message, string positive, string negative)
        {
            return await _page.DisplayAlert(title, message, positive, negative);
        }

        private readonly Page _page;
    }
}
