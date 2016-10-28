using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {


	public class SpeciesImage
	{
		
		public string ImageSource { get; set; }
		public string SpeciesName { get; set; }
		public string Owner { get; set; }
		public string Date { get; set; }
		public string License { get; set; }
		public string Description { get; set; }
		public List<Taxon> Taxons { get; set; }

	    public SpeciesImage()
	    {
	        
	    }

		public SpeciesImage(string ImageSource, string SpeciesName, string Owner, string Caption, string License, string Description, List<Taxon> Taxons)
		{
			this.ImageSource = ImageSource;
			this.SpeciesName = SpeciesName;
			this.Owner = Owner;
			this.Date = Caption;
			this.License = License;
			this.Description = Description;
			this.Taxons = Taxons;
		}
	}
}
