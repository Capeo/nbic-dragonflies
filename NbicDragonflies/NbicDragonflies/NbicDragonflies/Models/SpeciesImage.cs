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
		public string Owner { get; set; }
		public string Date { get; set; }
		public string License { get; set; }

		public SpeciesImage(string ImageSource, string Owner, string Caption, string License)
		{
			this.ImageSource = ImageSource;
			this.Owner = Owner;
			this.Date = Caption;
			this.License = License;
		}
	}
}
