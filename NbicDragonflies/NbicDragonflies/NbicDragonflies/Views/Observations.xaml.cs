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
	/// <summary>
	/// Observations page.
	/// </summary>
    public partial class Observations : TabbedPage
    {
        private IObservationsController _controller;

        /// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.Observations"/> class.
		/// </summary>
        public Observations(IObservationsController controller)
        {
            InitializeComponent();

            _controller = controller;

            ObservationsMap.MoveToRegion(MapSpan.FromCenterAndRadius( new Position(63.487164718, 9.839663308), Distance.FromMiles(400)));

            //TODO Add pins here, will not work due to areas not being assigned to geocoordinates in the API
            //AddMapPins(_controller.GetObservationsMapPins());

            FillObservationsList(_controller.GetObservations());

            RecentObservationsList.ItemSelected += OnObservationSelected;
        }

        private void FillObservationsList(List<Observation> observations) 
        {
            if (observations != null) {
                var recentObservationsCells = new List<ObservationsCell>();
                foreach (Observation observation in observations) 
				{
					if (observation.Name != null)
					{
						observation.Name = observation.Name.Substring(0, 1).ToUpper() + observation.Name.Substring(1);
					}

                    ObservationsCell cell = new ObservationsCell {
						Species = observation.Name == null ? observation.ScientificName : observation.Name + " (" + observation.ScientificName + ")",
                        Location = observation.GetLocationText(),
                        Date = observation.CollctedDate,
                        User = observation.Collector,
                    };
                    recentObservationsCells.Add(cell);
                }
                RecentObservationsList.ItemsSource = recentObservationsCells;
            }
        }

        private void AddMapPins(Dictionary<AreaDataSet,int> observationMapPins)
        {
            foreach (KeyValuePair<AreaDataSet, int> entry in observationMapPins)
            {
                var entryCoordinates = entry.Key.Location;
                var pin = new Pin()
                {
                    Position = new Position(entryCoordinates.Latitude, entryCoordinates.Longitude),
                    Label = entry.Key.Name + " " + entry.Value
                };
                ObservationsMap.Pins.Add(pin);
            }
        }

        private void OnObservationSelected(Object sender, SelectedItemChangedEventArgs e) {
            RecentObservationsList.SelectedItem = null;
        }
    }
}
