using Catel.IoC;
using Catel.Logging;
using Catel.MVVM;
using CatelLobDemo.Services;
using CatelLobDemo.ViewModels;
using CatelLobDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelLobDemo
{
    /// <summary>
    /// Used by the ModuleInit. All code inside the Initialize method is ran as soon as the assembly is loaded.
    /// </summary>
    public static class ModuleInitializer
    {
        /// <summary>
        /// Initializes the module.
        /// </summary>
        public static void Initialize()
        {
            SetupLogger();
            RegisterNavigation();
            RegisterServices();
        }

        /// <summary>
        /// Setup logging system.
        /// Please note that FileLogger and MemoryLogger is instantiated by services
        /// </summary>
        private static void SetupLogger()
        {
            LogManager.AddDebugListener();
            LogManager.IgnoreCatelLogging = true;
        }

        /// <summary>
        /// Register services
        /// </summary>
        private static void RegisterServices()
        {
            var serviceLocator = ServiceLocator.Default;

            serviceLocator.RegisterType<IDataRepositoryService, DataRepositoryService>();
        }

        /// <summary>
        /// Register navigation
        /// </summary>
        private static void RegisterNavigation()
        {
            var serviceLocator = ServiceLocator.Default;

            // content navigation (default INavigationService)
            var contentNavigationRoot = new NavigationRootContentService();
            serviceLocator.RegisterInstance<Catel.Services.INavigationRootService>(contentNavigationRoot);
        }
    }
}