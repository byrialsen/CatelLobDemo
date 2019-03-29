using Catel.IoC;
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
            // register services. Important to register navgiation related services first
            RegisterNavigation();
            RegisterServices();
        }

        /*
        /// <summary>
        /// Register views and viewmodels
        /// </summary>
        private static void RegisterViewsAndViewModels()
        {
            // clear/reset naming conventions
            var serviceLocator = ServiceLocator.Default;

            var viewModelLocator = serviceLocator.ResolveType<IViewModelLocator>();
            viewModelLocator.NamingConventions.Clear();
            viewModelLocator.ClearCache();

            var viewLocator = serviceLocator.ResolveType<IViewLocator>();
            viewLocator.NamingConventions.Clear();
            viewLocator.ClearCache();

            viewModelLocator.Register(typeof(ShellView), typeof(ShellViewModel));
            viewLocator.Register(typeof(ShellViewModel), typeof(ShellView));
        }
        */

        /// <summary>
        /// Register services
        /// </summary>
        private static void RegisterServices()
        {

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