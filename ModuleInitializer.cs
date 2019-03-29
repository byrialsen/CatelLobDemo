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
        }
    }
}