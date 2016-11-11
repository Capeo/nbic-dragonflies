using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {

    /// <summary>
    /// Model class representing the notice displayed on the Home page. May be used for "Dragonfly of the day" or other information.
    /// </summary>
    public class HomeNotice {

        /// <summary>
        /// Title of the notice
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Main text of the notice
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Path to image associated with notice
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Taxon associated with notice
        /// </summary>
        public Taxon.Taxon Taxon { get; set; }

        /// <summary>
        /// Constructor. Sets all fields from parameters.
        /// </summary>
        /// <param name="title">Title of the notice</param>
        /// <param name="text">Text of the notice</param>
        /// <param name="image">Path to image for the notice</param>
        /// <param name="taxon">Taxon associated with the notice</param>
        public HomeNotice(string title, string text, string image, Taxon.Taxon taxon)
        {
            Title = title;
            Text = text;
            Image = image;
            Taxon = taxon;
        }

    }
}
