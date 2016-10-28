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

        private Taxon _taxon;

        public Taxon Taxon
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

        public List<TaxonButton> Children { get; set; }

        public string Name { get; set; }

        public TaxonButton(Taxon taxon, int level)
        {
            InitializeComponent();

            Taxon = taxon;
            Level = level;

            NavigationTap = new TapGestureRecognizer();
            InfoTap = new TapGestureRecognizer();

            NavigationFrame.GestureRecognizers.Add(NavigationTap);
            InfoFrame.GestureRecognizers.Add(InfoTap);

            Open = false;
            if (Taxon.taxonRank != Utility.Constants.TaxonRanks.ElementAt(Utility.Constants.TaxonRanks.Count - 1))
            {
                Icon.Aspect = Aspect.AspectFit;
                Icon.Source = ImageSource.FromFile("ic_keyboard_arrow_right.png");
            }
            
            Children = new List<TaxonButton>();

        }

        private void SetTaxon(Taxon taxon)
        {
            NameLabel.Text = Utility.Utilities.CapitalizeFirstLetter(taxon.GetPreferredName());
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
