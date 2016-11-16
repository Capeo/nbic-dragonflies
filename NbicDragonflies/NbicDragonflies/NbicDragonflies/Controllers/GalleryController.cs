using System.Collections.Generic;
using NbicDragonflies.Models;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers
{
    /// <summary>
    /// Implementation of the IGalleryController interface.
    /// </summary>
	public class GalleryController : IGalleryController {

		private List<ImageElement> _galleryImages;

        /// <summary>
        /// Default constructor.
        /// </summary>
		public GalleryController()
		{
			_galleryImages = new List<ImageElement>();
		}

        /// <summary>
        /// Retrieves images for the Gallery Page.
        /// </summary>
        /// <returns>List of images</returns>
		public List<ImageElement> GetGalleryImages()
		{
            // TODO Currently only returns placeholder images. Should return actual images.

		    Taxon t = Data.ApplicationDataManager.GetTaxon(107).Result;
		    Taxon t1 = Data.ApplicationDataManager.GetTaxon(32634).Result;

			List<ImageElement> list = new List<ImageElement> {
				new ImageElement("dragonfly1.jpg", "Camarophyllus ovinus", "Phrida Norrhall", "12.03.2014", "LC4400", "De norske artene er små til meget store og har vanligvis tydelig kraftigere kroppsbygning enn vannymfene (Zygoptera). Kroppens fargetegninger varierer meget, og vingene kan være glassklare eller bruntonede og kan ha mer eller mindre utbredte svarte og/eller ravgule felter. Nær basis av vingen danner vingeribbene et trekantet felt, 'triangelet', som er viktig for bestemmelse til familie.Underordenen kan skilles fra vannymfene (Zygoptera) på følgende trekk: Hodet er maks ca. halvannen gang så bredt som Øynene er store og enten smalt adskilt eller i berøring. Avstanden mellom dem er i høyden 1/3 av hodets bredde, og den fremskutte pannen er bredere enn minsteavstanden mellom øynene. Fram- og bakvingen har ulik fasong. Bakvingen er betydelig bredere ved basis enn framvinge. I hvile står vingene vinkelrett ut fra kroppen. De vannlevende nymfene er kraftig bygget, brune eller grønnlige med lange bein. Munndelene danner en utkrengbar fangstmaske som kan skytes frem og gripe byttet. Bakkroppen mangler ytre gjeller, og åndingen foregår innvendig over tarmoverflaten. Bakkroppsspissen er utstyrt med små, tagglignende vedheng. Nymfene kan skilles fra Zygoptera-nymfene på den kraftigere kroppsformen og på at bakkroppen mangler bladgjeller bakerst.", new List<Taxon> { t }),
				new ImageElement("BrownDragonfly.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "De norske artene er små til meget store og har vanligvis tydelig kraftigere kroppsbygning enn vannymfene (Zygoptera). Kroppens fargetegninger varierer meget, og vingene kan være glassklare eller bruntonede og kan ha mer eller mindre utbredte svarte og/eller ravgule felter. Nær basis av vingen danner vingeribbene et trekantet felt, 'triangelet', som er viktig for bestemmelse til familie.Underordenen kan skilles fra vannymfene (Zygoptera) på følgende trekk: Hodet er maks ca. halvannen gang så bredt som Øynene er store og enten smalt adskilt eller i berøring. Avstanden mellom dem er i høyden 1/3 av hodets bredde, og den fremskutte pannen er bredere enn minsteavstanden mellom øynene. Fram- og bakvingen har ulik fasong. Bakvingen er betydelig bredere ved basis enn framvinge. I hvile står vingene vinkelrett ut fra kroppen. De vannlevende nymfene er kraftig bygget, brune eller grønnlige med lange bein. Munndelene danner en utkrengbar fangstmaske som kan skytes frem og gripe byttet. Bakkroppen mangler ytre gjeller, og åndingen foregår innvendig over tarmoverflaten. Bakkroppsspissen er utstyrt med små, tagglignende vedheng. Nymfene kan skilles fra Zygoptera-nymfene på den kraftigere kroppsformen og på at bakkroppen mangler bladgjeller bakerst.", new List<Taxon> { t }),
				new ImageElement("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly3.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly5.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly6.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly7.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly8.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
					new ImageElement("dragonfly9.jpg", "Odonata", "Odd Cappelen", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly10.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly3.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly4.jpg", "Rødbrun høstlibelle", "Mats Egedal", "31.10.2016", "LC4400", "Rødbrun høstlibelle er utbredt i et belte fra vest i Europa til Sibir i Asia. Finnes i Danmark, og Sverige, men mangler i Finland. I sydlige Norge langs kysten til Nordland.", new List<Taxon> { t1 }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly7.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly6.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly9.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
					new ImageElement("dragonfly5.jpg", "Odonata", "Daniel Groos", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly2.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
					new ImageElement("dragonfly2.jpg", "Odonata", "Jonas Løchsen", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),
				new ImageElement("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { t }),

				};
			return list;
		}

	}
}
