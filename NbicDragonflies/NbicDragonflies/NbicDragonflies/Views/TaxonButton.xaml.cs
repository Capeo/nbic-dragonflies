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
            Icon.Aspect = Aspect.AspectFit;
            Icon.Source = ImageSource.FromFile("ic_keyboard_arrow_right.png");

        }

        private void SetTaxon(TaxonItem taxon)
        {
            Name.Text = taxon.scientificName;
        }

        public void SwitchState()
        {
            if (Open)
            {
                Open = false;
                Icon.Source = ImageSource.FromFile("ic_keyboard_arrow_down.png");
            }
            else
            {
                Open = true;
                Icon.Source = ImageSource.FromFile("ic_keyboard_arrow_right.png");
            }
        }

    }
}
