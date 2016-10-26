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
				if (observation.Name != null)
				{
					observation.Name = observation.Name.Substring(0, 1).ToUpper() + observation.Name.Substring(1);
				}


                ObservationsCell cell = new ObservationsCell
                {
					Species = observation.Name==null?observation.ScientificName:observation.Name+" ("+observation.ScientificName+")",
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
