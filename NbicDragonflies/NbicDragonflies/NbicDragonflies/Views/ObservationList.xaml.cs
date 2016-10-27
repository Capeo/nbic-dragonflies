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

            FillObservationsList();
        }

        public async void FillObservationsList()
        {
            Models.ObservationList recentObservationsList = await ApplicationDataManager.GetObservationListAsync("list");
            if(recentObservationsList != null && recentObservationsList.Observations != null) {
                var recentObservationsCells = new List<ObservationsCell>();
                foreach (Models.Observation observation in recentObservationsList.Observations)
                {
                    ObservationsCell cell = new ObservationsCell
                    {
                        Species = observation.Name==null?observation.ScientificName:observation.Name+", "+observation.ScientificName,
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
