using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeinApp.Models;

namespace WeinApp.Services
{
    public class WineSaver : IWineSaver
    { } 
}

        //public WineSaver(IDialogService dialogService)
        //{
        //    _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        //}

        //public async Task<bool> TrySaveAsync(Wine wine)
        //{
        //    if (wine is null) { throw new ArgumentNullException(nameof(wine)); }

        //    if (string.IsNullOrEmpty(wine.Weinname))
        //    {
        //        await _dialogService.Show("Validierung fehlgeschlagen", "Der Weinname darf nicht leer sein!");

        //        return false;
        //    }
        //    if (string.IsNullOrEmpty(wine.Jahrgang))
        //    {
        //        await _dialogService.Show("Validierung fehlgeschlagen", "Der Jahrgang darf nicht leer sein!");

        //        return false;
        //    }

            //if (string.IsNullOrEmpty(wine.Typ))
            //{
            //    await _dialogService.Show("Validierung fehlgeschlagen", "Der Weintyp darf nicht leer sein!");

            //    return false;
            //}
            //if (string.IsNullOrEmpty(wine.Land))
            //{
            //    await _dialogService.Show("Validierung fehlgeschlagen", "Das Land darf nicht leer sein!");

            //    return false;
            //}
            //if (string.IsNullOrEmpty(wine.Region))
            //{
            //    await _dialogService.Show("Validierung fehlgeschlagen", "Die Region darf nicht leer sein!");

            //    return false;
            //}
            //if (string.IsNullOrEmpty(wine.Traubensorte))
            //{
            //    await _dialogService.Show("Validierung fehlgeschlagen", "Die Traubensorte darf nicht leer sein!");

            //    return false;
            //}
            //if (string.IsNullOrEmpty(wine.Flaschengroesse))
            //{
            //    await _dialogService.Show("Validierung fehlgeschlagen", "Die Flaschengrösse darf nicht leer sein!");

            //    return false;
            //}

            //return true;
    //    }

    //    //private readonly IDialogService _dialogService;
    //}

