using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {

	/// <summary>
	/// Species information with image and content
	/// </summary>
	public class SpeciesImage
	{

		/// <summary>
		/// Gets or sets the image source.
		/// </summary>
		/// <value>The image source.</value>
		public string ImageSource { get; set; }
		/// <summary>
		/// Gets or sets the name of the species.
		/// </summary>
		/// <value>The name of the species.</value>
		public string SpeciesName { get; set; }
		/// <summary>
		/// Gets or sets the owner of the image.
		/// </summary>
		/// <value>The owner.</value>
		public string Owner { get; set; }
		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		/// <value>The date.</value>
		public string Date { get; set; }
		/// <summary>
		/// Gets or sets the license.
		/// </summary>
		/// <value>The license.</value>
		public string License { get; set; }
		/// <summary>
		/// Gets or sets the description of the image.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }
		/// <summary>
		/// Gets or sets the taxons.
		/// </summary>
		/// <value>The taxons.</value>
		public List<Taxon> Taxons { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Models.SpeciesImage"/> class.
		/// </summary>
	    public SpeciesImage()
	    {
	        
	    }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NbicDragonflies.Models.SpeciesImage"/> class with all the content as parameters.
		/// </summary>
		/// <param name="ImageSource">Image source.</param>
		/// <param name="SpeciesName">Species name.</param>
		/// <param name="Owner">Owner.</param>
		/// <param name="Caption">Caption.</param>
		/// <param name="License">License.</param>
		/// <param name="Description">Description.</param>
		/// <param name="Taxons">Taxons.</param>
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
