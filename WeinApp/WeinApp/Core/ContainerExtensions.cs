using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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

        public static Container RegisterAlbumServices([NotNull] this Container container)
        {
            if (container is null) { throw new ArgumentNullException(nameof(container)); }

            container.RegisterSingleton<IDataStore<Album>, SQLiteDataStore<Album>>();
            container.RegisterSingleton<IDialogService, DialogService>();
            container.RegisterSingleton<IAlbumSaver, AlbumSaver>();

            return container;
        }
    }
}