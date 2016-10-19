using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class TaxonButton : ContentView
    {
    
        private TaxonItem _taxon;

        public TaxonItem Taxon
        {
            get { return _taxon; }
            set
            {
                _taxon = value;
                SetTaxon(value);
            }
        }

        public TapGestureRecognizer NavigationTap;
        public TapGestureRecognizer InfoTap;

        public bool Open { get; private set; }

        public int Level { get; set; }

        public List<TaxonButton> Subclasses { get; set; }

        public TaxonButton(TaxonItem taxon, int level)
        {
            InitializeComponent();

            Taxon = taxon;
            Level = level;

            NavigationTap = new TapGestureRecognizer();
            InfoTap = new TapGestureRecognizer();

            NavigationFrame.GestureRecognizers.Add(NavigationTap);
            InfoFrame.GestureRecognizers.Add(InfoTap);

            Open = false;
            if (Taxon.taxonRank != Utility.Constants.order.ElementAt(Utility.Constants.order.Count - 1))
            {
                Icon.Aspect = Aspect.AspectFit;
                Icon.Source = ImageSource.FromFile("ic_keyboard_arrow_right.png");
            }
            
            Subclasses = new List<TaxonButton>();

        }

        private void SetTaxon(TaxonItem taxon)
        {
            if (taxon.vernacularName.Length > 0)
            {
                Name.Text = taxon.vernacularName;
            }

            else
            {
                Name.Text = taxon.scientificName;
            }
        }

        public void SwitchState()
        {
            if (Open)
            {
                Open = false;
                Icon.Source = ImageSource.FromFile("ic_keyboard_arrow_right.png");
            }
            else
            {
                Open = true;
                Icon.Source = ImageSource.FromFile("ic_keyboard_arrow_down.png");
            }
        }
    }
}
