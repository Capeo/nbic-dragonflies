using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class TaxonButton : ContentView {

        public TaxonItem Taxon { get; set; }

        public TaxonButton() {
            InitializeComponent();
        }
    }
}
