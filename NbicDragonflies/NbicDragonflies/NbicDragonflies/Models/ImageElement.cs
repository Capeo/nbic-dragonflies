using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {

	/// <summary>
	/// Model class representing an image and associated information
	/// </summary>
	public class ImageElement
	{

		/// <summary>
		/// Gets or sets the image source.
		/// </summary>
		/// <value>The image source.</value>
		public string ImageSource { get; set; }
		/// <summary>
		/// Gets or sets the name of the taxon.
		/// </summary>
		/// <value>The name of the taxon.</value>
		public string TaxonName { get; set; }
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
		public List<Taxon.Taxon> Taxons { get; set; }

		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
	    public ImageElement()
	    {
	        // TODO Remove?
	    }

		/// <summary>
		/// Constructor. Initializes a new instance of the class with all the content as parameters.
		/// </summary>
		/// <param name="imageSource">Image source.</param>
		/// <param name="taxonName">TaxonContent name.</param>
		/// <param name="owner">owner.</param>
		/// <param name="caption">caption.</param>
		/// <param name="license">license.</param>
		/// <param name="description">description.</param>
		/// <param name="taxons">taxons.</param>
		public ImageElement(string imageSource, string taxonName, string owner, string caption, string license, string description, List<Taxon.Taxon> taxons)
		{
			ImageSource = imageSource;
			TaxonName = taxonName;
			Owner = owner;
			Date = caption;
			License = license;
			Description = description;
			Taxons = taxons;
		}
	}
}
