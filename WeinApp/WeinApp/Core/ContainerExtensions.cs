using SimpleInjector;
using System;
using WeinApp.Models;
using WeinApp.Services;


namespace WeinApp.Core
{
    public static class ContainerExtensions
    {
        public static Container CreateContainer()
        {
            return new Container()
            {
                Options =
        {
          ResolveUnregisteredConcreteTypes = true,
          AllowOverridingRegistrations = true
        }
            }.RegisterAlbumServices();
        }

        public static Container RegisterAlbumServices([JetBrains.Annotations.NotNull] this Container container)
        {
            if (container is null) { throw new ArgumentNullException(nameof(container)); }

            container.RegisterSingleton<IDataStore<Wine>, SQLiteDataStore<Wine>>();
            container.RegisterSingleton<IDialogService, DialogService>();
            container.RegisterSingleton<IWineSaver, WineSaver>();

            return container;
        }
    }
}