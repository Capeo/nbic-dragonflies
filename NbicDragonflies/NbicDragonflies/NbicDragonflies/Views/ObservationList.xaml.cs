using NbicDragonflies.Data;
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

            FillRecentObservationsList();
        }

        public async void FillRecentObservationsList()
        {
            ApplicationDataManager applicationDataManager = new ApplicationDataManager(new RestService());
            Models.ObservationList recentObservationsList = await applicationDataManager.GetObservationListAsync("list");
            var recentObservationsCells = new List<ObservationsCell>();
            foreach (Models.Observation observation in recentObservationsList.Observations)
            {
                ObservationsCell cell = new ObservationsCell
                {
                    Species = observation.Name,
                    LocationTime = observation.GetLocationText() + ", " + observation.CollctedDate,
                    User = observation.Collector,
                    ImageFilename = "hamburger.png" //TODO
                };
                recentObservationsCells.Add(cell);
            }
            RecentObservationsList.ItemsSource = recentObservationsCells;
        }
    }
}
