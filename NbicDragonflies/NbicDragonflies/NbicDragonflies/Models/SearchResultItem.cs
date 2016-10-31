using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models
{
	
    public class Resource
    {
		/// <summary>
		/// Gets or sets the Id.
		/// </summary>
		/// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
		public object Title { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
		public string Type { get; set; }
    }

	/// <summary>
	/// Search result item.
	/// </summary>
    public class SearchResultItem
    {
        /// <summary>
        /// Gets or sets the resource.
        /// </summary>
        /// <value>The resource.</value>
		public Resource Resource { get; set; }
        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        /// <value>The heading.</value>
		public string Heading { get; set; }
        /// <summary>
        /// Gets or sets the intro.
        /// </summary>
        /// <value>The intro.</value>
		public string Intro { get; set; }
        /// <summary>
        /// Gets or sets the references.
        /// </summary>
        /// <value>The references.</value>
		public List<object> References { get; set; }
        /// <summary>
        /// Gets or sets the search fragments.
        /// </summary>
        /// <value>The search fragments.</value>
		public List<string> SearchFragments { get; set; }
        /// <summary>
        /// Gets or sets the scientific names.
        /// </summary>
        /// <value>The name of the scientific.</value>
		public List<string> ScientificName { get; set; }
        /// <summary>
        /// Gets or sets the vernacular names. 
        /// </summary>
        /// <value>The name of the vernacular.</value>
		public List<string> VernacularName { get; set; }
    }

}
