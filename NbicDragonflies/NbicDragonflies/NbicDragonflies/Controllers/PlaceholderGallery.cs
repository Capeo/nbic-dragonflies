using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies
{
	class PlaceholderGallery : IGalleryControllers {

		private List<SpeciesImage> _galleryImages;

		public PlaceholderGallery()
		{
			_galleryImages = new List<SpeciesImage>();


		}

		public List<SpeciesImage> GetGalleryImages()
		{
			//Examples of pictures in Gallery
			List<SpeciesImage> list = new List<SpeciesImage> {
				new SpeciesImage("dragonfly2.jpg", "Camarophyllus ovinus", "Phrida Norrhall", "12.03.2014", "LC4400", "De norske artene er små til meget store og har vanligvis tydelig kraftigere kroppsbygning enn vannymfene (Zygoptera). Kroppens fargetegninger varierer meget, og vingene kan være glassklare eller bruntonede og kan ha mer eller mindre utbredte svarte og/eller ravgule felter. Nær basis av vingen danner vingeribbene et trekantet felt, 'triangelet', som er viktig for bestemmelse til familie.Underordenen kan skilles fra vannymfene (Zygoptera) på følgende trekk: Hodet er maks ca. halvannen gang så bredt som Øynene er store og enten smalt adskilt eller i berøring. Avstanden mellom dem er i høyden 1/3 av hodets bredde, og den fremskutte pannen er bredere enn minsteavstanden mellom øynene. Fram- og bakvingen har ulik fasong. Bakvingen er betydelig bredere ved basis enn framvinge. I hvile står vingene vinkelrett ut fra kroppen. De vannlevende nymfene er kraftig bygget, brune eller grønnlige med lange bein. Munndelene danner en utkrengbar fangstmaske som kan skytes frem og gripe byttet. Bakkroppen mangler ytre gjeller, og åndingen foregår innvendig over tarmoverflaten. Bakkroppsspissen er utstyrt med små, tagglignende vedheng. Nymfene kan skilles fra Zygoptera-nymfene på den kraftigere kroppsformen og på at bakkroppen mangler bladgjeller bakerst.", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("BrownDragonfly.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "De norske artene er små til meget store og har vanligvis tydelig kraftigere kroppsbygning enn vannymfene (Zygoptera). Kroppens fargetegninger varierer meget, og vingene kan være glassklare eller bruntonede og kan ha mer eller mindre utbredte svarte og/eller ravgule felter. Nær basis av vingen danner vingeribbene et trekantet felt, 'triangelet', som er viktig for bestemmelse til familie.Underordenen kan skilles fra vannymfene (Zygoptera) på følgende trekk: Hodet er maks ca. halvannen gang så bredt som Øynene er store og enten smalt adskilt eller i berøring. Avstanden mellom dem er i høyden 1/3 av hodets bredde, og den fremskutte pannen er bredere enn minsteavstanden mellom øynene. Fram- og bakvingen har ulik fasong. Bakvingen er betydelig bredere ved basis enn framvinge. I hvile står vingene vinkelrett ut fra kroppen. De vannlevende nymfene er kraftig bygget, brune eller grønnlige med lange bein. Munndelene danner en utkrengbar fangstmaske som kan skytes frem og gripe byttet. Bakkroppen mangler ytre gjeller, og åndingen foregår innvendig over tarmoverflaten. Bakkroppsspissen er utstyrt med små, tagglignende vedheng. Nymfene kan skilles fra Zygoptera-nymfene på den kraftigere kroppsformen og på at bakkroppen mangler bladgjeller bakerst.", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
					new SpeciesImage("dragonfly1.jpg", "Odonata", "Odd Cappelen", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
					new SpeciesImage("dragonfly1.jpg", "Odonata", "Daniel Groos", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
					new SpeciesImage("dragonfly2.jpg", "Odonata", "Jonas Løchsen", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),

				};

			return list;
		}



	}
}
