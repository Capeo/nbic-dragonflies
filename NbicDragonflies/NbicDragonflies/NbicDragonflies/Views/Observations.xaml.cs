using NbicDragonflies.Models;
using NbicDragonflies.Views.ListItems;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NbicDragonflies.Views
{
    public partial class Observations : TabbedPage
    {
        public Observations()
        {
            InitializeComponent();
            ObservationsMap.MoveToRegion(MapSpan.FromCenterAndRadius( new Position(63.487164718, 9.839663308), Distance.FromMiles(400)));
        }
    }
}
