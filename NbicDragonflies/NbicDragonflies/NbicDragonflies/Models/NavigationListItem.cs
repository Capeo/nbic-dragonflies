using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NbicDragonflies.Models {

    /// <summary>
    /// Model class representing the elements in the navigation drawer.
    /// </summary>
    public class NavigationListItem {

        /// <summary>
        /// Title of the navigation element
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Path to icon used for navigation element
        /// </summary>
        public string IconSource { get; set; }

        /// <summary>
        /// Type of page created when pressing the element in navigation drawer
        /// </summary>
        public Type TargetType { get; set; }

        /// <summary>
        /// Constructor. Sets all fields from parameters.
        /// </summary>
        /// <param name="title">Title of the element</param>
        /// <param name="iconSource">Path to icon used for element</param>
        /// <param name="targetType">Type of target page</param>
        public NavigationListItem(string title, string iconSource, Type targetType)
        {
            Title = title;
            IconSource = iconSource;
            TargetType = targetType;
        }
    }
}
