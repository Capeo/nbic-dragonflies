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

    /// <summary>
    /// Class for static utility methods used throughout the application
    /// </summary>
    public static class Utilities
    {

        /// <summary>
        /// Capitalizes the first letter of the given string
        /// </summary>
        /// <param name="str">string</param>
        /// <returns>Parameter string with first letter capitalized</returns>
        public static string CapitalizeFirstLetter(string str)
        {
            if (str.Length >= 1)
            {
                return str.Substring(0, 1).ToUpper() + str.Substring(1);
            }
            return str;
        }

        /// <summary>
        /// Navigates the VisualElement ancestors of an element e and returns the first instance which matches the ancestorType. 
        /// I.e. finds the first ancestor og a given element belonging to a given type.
        /// </summary>
        /// <param name="e">The VisualElement from which to start the search.</param>
        /// <param name="ancestorType">The ancestor type to search for.</param>
        /// <returns>View element of ancestorType</returns>
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

        /// <summary>
        /// Returns a list of ObservationCell items from a list of observations
        /// </summary>
        /// <param name="observations">List of observations</param>
        /// <returns>List of observation cells</returns>
        public static List<ObservationsCell> GetObservationCellList(List<Observation> observations)
        {
            var observationCells = new List<ObservationsCell>();
            if (observations != null) {
                foreach (Observation observation in observations) {
                    if (observation.Name != null) {
                        observation.Name = observation.Name.Substring(0, 1).ToUpper() + observation.Name.Substring(1);
                    }

                    ObservationsCell cell = new ObservationsCell {
                        Taxon = observation.Name == null ? observation.ScientificName : observation.Name + " (" + observation.ScientificName + ")",
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
