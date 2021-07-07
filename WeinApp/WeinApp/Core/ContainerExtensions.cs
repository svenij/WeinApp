using JetBrains.Annotations;
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
            }.RegisterServices();
        }

        public static Container RegisterServices([NotNull] this Container container)
        {
            if (container is null) { throw new ArgumentNullException(nameof(container)); }

            container.RegisterSingleton<IDataStore<Wine>, WineDataStore>();

            return container;
        }
    }
}