using NbicDragonflies.Views.ListItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NbicDragonflies.Views
{
    public partial class ObservationList : ContentView
    {
        public ObservationList()
        {
            InitializeComponent();
            var recentObservations = new List<ObservationsCell>();

            recentObservations.Add(new ObservationsCell
            {
                Species = "Brun øyenstikker",
                LocationTime = "Trondehim, 30.09.16",
                User = "Odd Cappelen",
                ImageFilename = "dragonfly2.jpg"
            });

            recentObservations.Add(new ObservationsCell
            {
                Species = "Blå øyenstikker",
                LocationTime = "Trondheim, 29.09.16",
                User = "Odd Cappelen",
                ImageFilename = "dragonfly1.jpg"
            });

            recentObservations.Add(new ObservationsCell
            {
                Species = "Gul øyenstikker",
                LocationTime = "Trondheim, 28.09.16",
                User = "Odd Cappelen",
                ImageFilename = ""
            });

            RecentObservationsList.ItemsSource = recentObservations;
        }
    }
}
