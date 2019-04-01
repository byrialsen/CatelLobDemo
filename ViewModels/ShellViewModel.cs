using Catel;
using Catel.MVVM;
using Catel.Services;
using CatelLobDemo.Models;
using CatelLobDemo.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CatelLobDemo.ViewModels
{
    public class ShellViewModel : ViewModelBaseEx
    {
        private readonly INavigationService _navigationService;

        private Command<object> _navigateToMenuItemCommand;

        /// <summary>
        /// Menu items
        /// </summary>
        public ObservableCollection<MenuItem> MenuItems { get; private set; }

        /// <summary>
        /// Selected menu item
        /// </summary>
        public MenuItem SelectedMenuItem { get; set; }

        public Command<object> NavigateToMenuItemCommand
        {
            get
            {
                return _navigateToMenuItemCommand ?? (_navigateToMenuItemCommand = new Command<object>(
                    (arg) =>
                    {
                        if ((arg as ItemClickEventArgs)?.ClickedItem is MenuItem menuItem)
                        {
                            _navigationService.Navigate(menuItem.ViewModelType, null);
                        }
                    }));
            }
        }

        /// <summary>
        /// Defaul constructor
        /// </summary>
        /// <param name="navigationService"></param>
        public ShellViewModel(INavigationService navigationService)
        {
            Argument.IsNotNull(() => navigationService);

            _navigationService = navigationService;
        }

        /// <summary>
        /// Initialize override
        /// </summary>
        /// <returns></returns>
        protected override Task InitializeAsync()
        {
            MenuItems = new ObservableCollection<MenuItem>(BuildMenuStructure());

            // initial selected menu item
            var initialMenuItem = MenuItems.FirstOrDefault();
            _navigationService.Navigate(initialMenuItem.ViewModelType);
            SelectedMenuItem = initialMenuItem;

            return base.InitializeAsync();
        }

        private IEnumerable<MenuItem> BuildMenuStructure()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem() { DisplayName = "One", ViewModelType = typeof(OneViewModel) });
            menuItems.Add(new MenuItem() { DisplayName = "Two", ViewModelType = typeof(TwoViewModel) });
            menuItems.Add(new MenuItem() { DisplayName = "Three", ViewModelType = typeof(ThreeViewModel) });

            return menuItems;
        }
    }
}
