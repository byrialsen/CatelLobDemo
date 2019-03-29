using CatelLobDemo.Services;

namespace CatelLobDemo.Views
{
    /// <summary>
    /// Shell page
    /// </summary>
    public sealed partial class ShellView : Catel.Windows.Controls.Page
    {
        public ShellView()
        {
            this.InitializeComponent();

            NavigationRootContentService.NavigationRootFrame = this.FrameContent;
        }
    }
}
