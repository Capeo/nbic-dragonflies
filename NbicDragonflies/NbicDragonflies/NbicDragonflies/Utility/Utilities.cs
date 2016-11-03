using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Views.ListItems;
using Xamarin.Forms;

namespace NbicDragonflies.Utility
{

    public class Utilities
    {
        public static string CapitalizeFirstLetter(string str)
        {
            if (str.Length >= 1)
            {
                return str.Substring(0, 1).ToUpper() + str.Substring(1);
            }
            return str;
        }

        public static View GetWrapperView(VisualElement e, Type ancestorType) 
        {
            if (e != null) {
                var viewParent = e.Parent;
                while (viewParent != null) {
                    if (viewParent.GetType() == ancestorType ) {
                        return (View)viewParent;
                    }
                    viewParent = viewParent.Parent;
                }
            }
            return null;
        }

        public static List<ObservationsCell> GetObservationCellList(List<Observation> observations)
        {
            var observationCells = new List<ObservationsCell>();
            if (observations != null) {
                foreach (Observation observation in observations) {
                    if (observation.Name != null) {
                        observation.Name = observation.Name.Substring(0, 1).ToUpper() + observation.Name.Substring(1);
                    }

                    ObservationsCell cell = new ObservationsCell {
                        Species = observation.Name == null ? observation.ScientificName : observation.Name + " (" + observation.ScientificName + ")",
                        Location = observation.GetLocationText(),
                        Date = observation.CollctedDate,
                        User = observation.Collector,
                    };
                    observationCells.Add(cell);
                }
            }
            return observationCells;
        }

    }
}
