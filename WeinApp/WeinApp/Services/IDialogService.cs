using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeinApp.Services
{
    public interface IDialogService
    {
        Task Show(string title, string message);

        Task<bool> Show(string title, string message, string positive, string negative);
    }
}
