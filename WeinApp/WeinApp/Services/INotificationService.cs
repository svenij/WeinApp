using System;
using System.Collections.Generic;
using System.Text;

namespace WeinApp.Services
{
    public interface INotificationService
    {
        void Show(string title, string description);

        void CreateNotificationChannel();
    }
}
