﻿using NbicDragonflies.Data;
using NbicDragonflies.Views.ListItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NbicDragonflies.Views
{
	/// <summary>
	/// Class to handle a list of all observations. 
	/// </summary>
    public partial class ObservationList : ContentView
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.ObservationList"/> class.
		/// </summary>
        public ObservationList()
        {
            InitializeComponent();

            FillObservationsList();
        }

		/// <summary>
		/// Fills the observations list.
		/// </summary>
        public async void FillObservationsList()
        {          
            Models.ObservationList recentObservationsList = await ApplicationDataManager.GetObservationListAsync("list");
            if(recentObservationsList != null && recentObservationsList.Observations != null) {
                var recentObservationsCells = new List<ObservationsCell>();
                foreach (Models.Observation observation in recentObservationsList.Observations)
                {
					if (observation.Name != null)
					{
						observation.Name = observation.Name.Substring(0, 1).ToUpper() + observation.Name.Substring(1);
					}

                    ObservationsCell cell = new ObservationsCell
                    {
						Species = observation.Name==null?observation.ScientificName:observation.Name + " (" + observation.ScientificName + ")",
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
