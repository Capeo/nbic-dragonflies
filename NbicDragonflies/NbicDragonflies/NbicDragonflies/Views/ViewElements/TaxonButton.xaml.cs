using System.Collections.Generic;
using System.Linq;
using NbicDragonflies.Models.Taxon;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements {

    public partial class TaxonButton : ContentView
    {

        private Taxon _taxon;

		/// <summary>
		/// Gets or sets the taxon.
		/// </summary>
		/// <value>The taxon.</value>
        public Taxon Taxon
        {
            get { return _taxon; }
            set
            {
                _taxon = value;
                SetTaxon(value);
            }
        }

		/// <summary>
		/// TapGestureRecognizer for tap to expanding Taxon tree. 
		/// </summary>
        public TapGestureRecognizer NavigationTap;
        /// <summary>
        /// TapGestureRecognizer for tap to get information about species. 
        /// </summary>
		public TapGestureRecognizer InfoTap;

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:NbicDragonflies.Views.ViewElements.TaxonButton"/> is open.
		/// </summary>
		/// <value><c>true</c> if open; otherwise, <c>false</c>.</value>
        public bool Open { get; private set; }

		/// <summary>
		/// Gets or sets the level in the taxon tree.
		/// </summary>
		/// <value>The level.</value>
        public int Level { get; set; }

		/// <summary>
		/// Gets or sets the children in the taxon tree.
		/// </summary>
		/// <value>The children.</value>
        public List<TaxonButton> Children { get; set; }

		/// <summary>
		/// Gets or sets the name of the taxon.
		/// </summary>
		/// <value>The name.</value>
        public string Name { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Views.ViewElements.TaxonButton"/> class with taxon and level as parameters.
		/// </summary>
		/// <param name="taxon">Taxon.</param>
		/// <param name="level">Level.</param>
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

            Info.Source = ImageSource.FromFile("Info.png");

            Children = new List<TaxonButton>();

        }

        private void SetTaxon(Taxon taxon)
        {
            NameLabel.Text = Utility.Utilities.CapitalizeFirstLetter(taxon.GetPreferredName());
        }


		/// <summary>
		/// Switchs the state to another level.
		/// </summary>
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
