using System;
using System.Collections.Generic;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Location;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NbicDragonflies.Views.Pages
{
	/// <summary>
	/// ObservationsPage page.
	/// </summary>
    public partial class ObservationsPage : TabbedPage
    {
        private IObservationsController _controller;

        /// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.Pages.ObservationsPage"/> class.
		/// </summary>
        public ObservationsPage()
        {
            InitializeComponent();

            _controller = new ObservationsController();

            ObservationsMap.MoveToRegion(MapSpan.FromCenterAndRadius( new Position(63.487164718, 9.839663308), Distance.FromMiles(400)));

            //TODO Add pins here, will not work due to areas not being assigned to geocoordinates in the API
            //AddMapPins(_controller.GetObservationsMapPins());

            FillObservationsList(_controller.GetObservations());

            RecentObservationsList.ItemSelected += OnObservationSelected;
        }

        private void FillObservationsList(List<Observation> observations) 
        {
            RecentObservationsList.ItemsSource = Utility.Utilities.GetObservationCellList(observations);
        }

        private void AddMapPins(Dictionary<CountyDataSet,int> observationMapPins)
        {
            foreach (KeyValuePair<CountyDataSet, int> entry in observationMapPins)
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
