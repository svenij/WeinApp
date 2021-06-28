using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeinApp.Services
{
    public static class DialogServiceExtensions
    {
        public static Task<bool> Ask(this IDialogService dialogService, string title, string message)
        {
            return dialogService.Show(title, message, "YES", "NO");
        }
    }
}
