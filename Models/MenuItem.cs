using System;

namespace CatelLobDemo.Models
{
    public class MenuItem
    {
        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// View model navigation type
        /// </summary>
        public Type ViewModelType { get; set; }
    }
}
