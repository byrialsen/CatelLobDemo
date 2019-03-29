using Catel.Services;
using Windows.UI.Xaml.Controls;

namespace CatelLobDemo.Services
{
    /// <summary>
    /// NavigationRootService used for content area/frame
    /// </summary>
    public class NavigationRootContentService : NavigationRootService
    {
        /// <summary>
        /// NavigationRootFrame
        /// </summary>
        public static Frame NavigationRootFrame { get; set; }

        /// <summary>
        /// Get application root frame
        /// </summary>
        /// <returns></returns>
        protected override Frame GetApplicationRootFrame()
        {
            return NavigationRootFrame ?? base.GetApplicationRootFrame();
        }

        /// <summary>
        /// Get navigation root
        /// </summary>
        /// <returns></returns>
        public override object GetNavigationRoot()
        {
            return base.GetNavigationRoot();
        }
    }
}
