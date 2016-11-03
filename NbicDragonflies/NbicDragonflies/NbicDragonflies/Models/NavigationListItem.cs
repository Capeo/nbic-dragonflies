using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NbicDragonflies.Models {

    // Item structure used in NavigationPage List
    class NavigationListItem {

        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }

        public NavigationListItem(string title, string iconSource, Type targetType)
        {
            Title = title;
            IconSource = iconSource;
            TargetType = targetType;
        }
    }
}
