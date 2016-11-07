using System;
using System.Collections.Generic;
using NbicDragonflies.Controllers;

namespace NbicDragonflies.Models.Taxon {

    /// <summary>
    /// Model class representing content associated with a Taxon. Used to populate the TaxonContent page.
    /// </summary>
    public class TaxonContent {

        /// <summary>
        /// The associated taxon
        /// </summary>
        public Models.Taxon.Taxon Taxon { get; set; }

        /// <summary>
        /// The header image for the taxon
        /// </summary>
        public ImageElement TopImage { get; set; }

        /// <summary>
        /// List of key attributes of the taxon. Each attribute consists of a Title and TaxonContent.
        /// </summary>
        public List<Tuple<string, string>> Attributes { get; set; }

        /// <summary>
        /// List of text content. Each element represents one paragraph and consits of a Title and TaxonContent.
        /// </summary>
        public List<Tuple<string, string>> Content { get; set; }

        /// <summary>
        /// List of images associated with the taxon. 
        /// </summary>
        public List<ImageElement> Images { get; set; }

        /// <summary>
        /// Constructor. Sets all fields from parameters
        /// </summary>
        /// <param name="taxon">Associated taxon.</param>
        /// <param name="topImage">Top image for taxon.</param>
        /// <param name="attributes">List of attributes, each consisting of title and content.</param>
        /// <param name="content">List of content, each consisting of paragraph title and body.</param>
        /// <param name="images">List of images for taxon.</param>
        public TaxonContent(Taxon taxon, ImageElement topImage, List<Tuple<string, string>> attributes,
            List<Tuple<string, string>> content, List<ImageElement> images)
        {
            Taxon = taxon;
            TopImage = topImage;
            Attributes = attributes;
            Content = content;
            Images = images;
        }

    }
}
