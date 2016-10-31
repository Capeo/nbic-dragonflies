using NbicDragonflies.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {

    public class Species {

        // Taxon 
        public Taxon Taxon { get; set; }

        // Header image of the species
        public SpeciesImage TopImage { get; set; }

        // List of key attributes of the species. Each attribute consists of a Title and Content
        public List<Tuple<string, string>> Attributes { get; set; }

        // List of text content. Each element represents one paragraph and consits of a Title and Content
        public List<Tuple<string, string>> Content { get; set; }

        // List of images associated with the species 
        public List<SpeciesImage> Images { get; set; }


        public Species()
        {
            Attributes = new List<Tuple<string, string>>();

            Content = new List<Tuple<string, string>>();

            Images = new List<SpeciesImage>();

            CreatePlaceholderSpecies();            
        }

		public Species(Taxon taxon)
		{
		    Taxon = taxon;
            CreatePlaceholderSpecies();
		}

        private void CreatePlaceholderSpecies() {
            TopImage = new SpeciesImage("BrownDragonflyTop.png", "Brun øyenstikker", "Phrida Norrhall", "12/3-14", "LC4400", "Description", new List<Taxon> { new Taxon(107) });

            Attributes = new List<Tuple<string, string>> { new Tuple<string, string>("Vitenskapelig navn ", "Aeshna grandis"), new Tuple<string, string>("Taksonomisk kategori ", "Art"), new Tuple<string, string>("Autor ", "(Linnaeus, 1758)"), new Tuple<string, string>("Bokmål ",  "Brun øyenstikker")};

            Content = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Størrelse", "Kroppslengde 69–76 mm, vingespenn 96–104 mm."),
                new Tuple<string, string>("Kjennetegn", "Begge kjønn har nøttebrun grunnfarge. Brystet mangler skulderstreker og har to smale, gule eller blå diagonalbånd på siden. Bakkroppen har gråblå sideflekker, ett par blå flekker på ryggsiden av ledd 2, og ellers bare små, gule parstreker på ryggsiden. Vingene er kraftig bruntonet hos begge kjønn."),
                new Tuple<string, string>("Forvekslingsarter", "Vanligvis lett å kjenne på den nøttebrune fargen og de kraftig bruntonede vingene. Også hunner av bl.a. A. juncea kan imidlertid være brunlige og ha bruntonede vinger. Et sikkert kjennetegn er at de fleste bakkroppsleddene mangler lyse parflekker i bakkanten. A. isosceles (ikke funnet i Norge) er også brun og mangler parflekker, men denne arten har grønne øyne og en kraftig gul kiletegning på det 2. bakkroppsleddet."),
                new Tuple<string, string>("Totalutbredelse", "Foruten i Norden er arten utbredt i Mellom-Europa, inkludert Storbritannia, og østover i Russland."),
                new Tuple<string, string>("Utbredelse i Norge", "Vanlig i Sør-Norge, og noe mer spredt i Nordland."),
                new Tuple<string, string>("Levested og økologi", "Ved de fleste typer vann, men foretrekker vegetasjonsrike vann og sjøer. Påtreffes ofte langt fra vann, patruljerende i skog og på dyrket mark. Nymfen blir 40–47 mm. Utviklingen tar fra 2–3 år."),
                new Tuple<string, string>("Flyvetid", "Juli til september.")
            };

            Images = new List<SpeciesImage> { new SpeciesImage("BrownDragonfly.jpg", "Brun øyenstikker", "Phrida Norrhall", "12/3-14", "LC4400", "Hann av Aeshna grandis. Arten er en av våre største øyenstikkere. Den er en sterk flyger som kan påtreffes langt fra vann. Både kropp og vinger er påfallende brunlige.", new List<Taxon> { new Taxon(107) }), new SpeciesImage("BrownDragonfly1.jpg", "Brun øyenstikker", "Phrida Norrhall", "12/3-14", "LC4400", "Hunn av Aeshna grandis i egglegging. Eggene legges gjerne i død flytevegetasjon eller, som her, i alger ved en stein.", new List<Taxon> { new Taxon(107) }) };
        }
    }
}
