using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeinApp.Models;

namespace WeinApp.Services
{
    public class WineSaver : IWineSaver
    {
        public WineSaver(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        public async Task<bool> TrySaveAsync(Wine wine)
        {
            if (wine is null) { throw new ArgumentNullException(nameof(wine)); }

            if (string.IsNullOrEmpty(wine.Title))
            {
                await _dialogService.Show("Validation failed", "The title cannot be empty.");

                return false;
            }

            if (string.IsNullOrEmpty(wine.Description))
            {
                await _dialogService.Show("Validation failed", "The description cannot be empty.");

                return false;
            }

            return true;
        }

        private readonly IDialogService _dialogService;
    }
}
