using System;
using System.Collections.Generic;
using System.Text;

namespace WeinApp.Services
{
    public class WineSaver : IWineSaver
    {
        public AlbumSaver(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        public async Task<bool> TrySaveAsync(Album album)
        {
            if (album is null) { throw new ArgumentNullException(nameof(album)); }

            if (string.IsNullOrEmpty(album.Title))
            {
                await _dialogService.Show("Validation failed", "The title cannot be empty.");

                return false;
            }

            if (string.IsNullOrEmpty(album.Description))
            {
                await _dialogService.Show("Validation failed", "The description cannot be empty.");

                return false;
            }

            return true;
        }

        private readonly IDialogService _dialogService;
    }
}
