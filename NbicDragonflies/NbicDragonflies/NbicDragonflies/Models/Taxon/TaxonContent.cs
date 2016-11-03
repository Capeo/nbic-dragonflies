using System;
using System.Collections.Generic;
using NbicDragonflies.Controllers;

namespace NbicDragonflies.Models.Taxon {

    public class TaxonContent {

        // Taxon 
        public Models.Taxon.Taxon Taxon { get; set; }

        // Header image of the species
        public ImageElement TopImage { get; set; }

        // List of key attributes of the species. Each attribute consists of a Title and Content
        public List<Tuple<string, string>> Attributes { get; set; }

        // List of text content. Each element represents one paragraph and consits of a Title and Content
        public List<Tuple<string, string>> Content { get; set; }

        // List of images associated with the species 
        public List<ImageElement> Images { get; set; }

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
