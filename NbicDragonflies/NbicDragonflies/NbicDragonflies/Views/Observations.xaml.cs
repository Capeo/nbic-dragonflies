using NbicDragonflies.Models;
using NbicDragonflies.Views.ListItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Controllers;
using NbicDragonflies.Data;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NbicDragonflies.Views
{
    public partial class Observations : TabbedPage
    {

        private IObservationsController _controller;

        public Observations(IObservationsController controller)
        {
            InitializeComponent();

            _controller = controller;

            ObservationsMap.MoveToRegion(MapSpan.FromCenterAndRadius( new Position(63.487164718, 9.839663308), Distance.FromMiles(400)));

            FillObservationsList(_controller.GetObservations());
        }

        private void FillObservationsList(List<Observation> observations) 
        {
            if (observations != null) {
                var recentObservationsCells = new List<ObservationsCell>();
                foreach (Observation observation in observations) {
                    ObservationsCell cell = new ObservationsCell {
                        Species = observation.Name == null ? observation.ScientificName : observation.Name + ", " + observation.ScientificName,
                        Location = observation.GetLocationText(),
                        Date = observation.CollctedDate,
                        User = observation.Collector,
                    };
                    recentObservationsCells.Add(cell);
                }
                RecentObservationsList.ItemsSource = recentObservationsCells;
            }
        }
    }
}
