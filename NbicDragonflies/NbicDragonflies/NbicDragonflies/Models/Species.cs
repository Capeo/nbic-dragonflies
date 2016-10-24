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
            TopImage = new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12/3-14", "LC4400", "Description", new List<Taxon> { new Taxon(107) });

            Attributes = new List<Tuple<string, string>> { new Tuple<string, string>("Vitenskapelig navn ", "Anisoptera"), new Tuple<string, string>("Taksonomi (0-5) ", "4"), new Tuple<string, string>("Utbredelse (0-5) ", "3"), new Tuple<string, string>("Økologi 0 - 5 ",  "4")};

            Content = new List<Tuple<string, string>> { new Tuple<string, string>("Antall og utbredelse", "Øyenstikkerne og libellene (Anisoptera) omfatter 34 norske arter fordelt på fem familier. Underordenen er utbredt på alle kontinenter utenom Antarktis."), new Tuple<string, string>("Kjennetegn", "De norske artene er små til meget store og har vanligvis tydelig kraftigere kroppsbygning enn vannymfene (Zygoptera). Kroppens fargetegninger varierer meget, og vingene kan være glassklare eller bruntonede og kan ha mer eller mindre utbredte svarte og/eller ravgule felter. Nær basis av vingen danner vingeribbene et trekantet felt, 'triangelet', som er viktig for bestemmelse til familie.Underordenen kan skilles fra vannymfene (Zygoptera) på følgende trekk: Hodet er maks ca. halvannen gang så bredt som Øynene er store og enten smalt adskilt eller i berøring. Avstanden mellom dem er i høyden 1/3 av hodets bredde, og den fremskutte pannen er bredere enn minsteavstanden mellom øynene. Fram- og bakvingen har ulik fasong. Bakvingen er betydelig bredere ved basis enn framvinge. I hvile står vingene vinkelrett ut fra kroppen. De vannlevende nymfene er kraftig bygget, brune eller grønnlige med lange bein. Munndelene danner en utkrengbar fangstmaske som kan skytes frem og gripe byttet. Bakkroppen mangler ytre gjeller, og åndingen foregår innvendig over tarmoverflaten. Bakkroppsspissen er utstyrt med små, tagglignende vedheng. Nymfene kan skilles fra Zygoptera-nymfene på den kraftigere kroppsformen og på at bakkroppen mangler bladgjeller bakerst.") };

            Images = new List<SpeciesImage> { new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12/3-14", "LC4400", "Description", new List<Taxon> { new Taxon(107) }), new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12/3-14", "LC4400", "Description", new List<Taxon> { new Taxon(107) }) };
        }
    }
}
