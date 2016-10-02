using System;
using System.Collections.Generic;
using System.Text;
using Foundation;
using NbicDragonflies.iOS.Views;
using NbicDragonflies.Views.ListItems;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ObservationsCell), typeof(ObservationCellRenderer))]

namespace NbicDragonflies.iOS.Views {
    class ObservationCellRenderer : ViewCellRenderer {

        static NSString rid = new NSString("ObservationCell");

        public override UITableViewCell GetCell(Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var x = (ObservationsCell) item;

            ObservationsiOSCell c = reusableCell as ObservationsiOSCell;

            if (c == null)
            {
                c = new ObservationsiOSCell(rid);
            }

            UIImage i = null;
            if (!String.IsNullOrWhiteSpace(x.ImageFilename))
            {
                // Need to specify path, or find way to set image from URL
                i = UIImage.FromFile("");
            }
            c.UpdateCell(x.Species, x.LocationTime, x.User, i);

            return c;
        }
    }
}
