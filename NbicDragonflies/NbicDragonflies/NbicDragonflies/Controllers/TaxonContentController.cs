using NbicDragonflies.Data;
using NbicDragonflies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers
{
    public class TaxonContentController : ITaxonContentController
    {
        public TaxonInfo GetInfoFromTaxon(Taxon taxon)
        {
            return ApplicationDataManager.GetTaxonInfoFromTaxonAsync(taxon).Result;
        }

        TaxonContent ITaxonContentController.GetContentFromTaxon(Taxon taxon)
        {
            ImageElement topImage = new ImageElement("BrownDragonflyTop.png", "Brun øyenstikker", "Phrida Norrhall", "12/3-14", "LC4400", "Description", new List<Taxon> { taxon });

            List<Tuple<string, string>> attributes = new List<Tuple<string, string>> { new Tuple<string, string>("Vitenskapelig navn ", "Aeshna grandis"), new Tuple<string, string>("Taksonomisk kategori ", "Art"), new Tuple<string, string>("Autor ", "(Linnaeus, 1758)"), new Tuple<string, string>("Bokmål ", "Brun øyenstikker") };

            List<Tuple<string, string>> content = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Størrelse", "Kroppslengde 69–76 mm, vingespenn 96–104 mm."),
                new Tuple<string, string>("Kjennetegn", "Begge kjønn har nøttebrun grunnfarge. Brystet mangler skulderstreker og har to smale, gule eller blå diagonalbånd på siden. Bakkroppen har gråblå sideflekker, ett par blå flekker på ryggsiden av ledd 2, og ellers bare små, gule parstreker på ryggsiden. Vingene er kraftig bruntonet hos begge kjønn."),
                new Tuple<string, string>("Forvekslingsarter", "Vanligvis lett å kjenne på den nøttebrune fargen og de kraftig bruntonede vingene. Også hunner av bl.a. A. juncea kan imidlertid være brunlige og ha bruntonede vinger. Et sikkert kjennetegn er at de fleste bakkroppsleddene mangler lyse parflekker i bakkanten. A. isosceles (ikke funnet i Norge) er også brun og mangler parflekker, men denne arten har grønne øyne og en kraftig gul kiletegning på det 2. bakkroppsleddet."),
                new Tuple<string, string>("Totalutbredelse", "Foruten i Norden er arten utbredt i Mellom-Europa, inkludert Storbritannia, og østover i Russland."),
                new Tuple<string, string>("Utbredelse i Norge", "Vanlig i Sør-Norge, og noe mer spredt i Nordland."),
                new Tuple<string, string>("Levested og økologi", "Ved de fleste typer vann, men foretrekker vegetasjonsrike vann og sjøer. Påtreffes ofte langt fra vann, patruljerende i skog og på dyrket mark. Nymfen blir 40–47 mm. Utviklingen tar fra 2–3 år."),
                new Tuple<string, string>("Flyvetid", "Juli til september.")
            };

            List<ImageElement> images = new List<ImageElement> { new ImageElement("BrownDragonfly.jpg", "Brun øyenstikker", "Phrida Norrhall", "12/3-14", "LC4400", "Hann av Aeshna grandis. Arten er en av våre største øyenstikkere. Den er en sterk flyger som kan påtreffes langt fra vann. Både kropp og vinger er påfallende brunlige.", new List<Taxon> { taxon }), new ImageElement("BrownDragonfly1.jpg", "Brun øyenstikker", "Phrida Norrhall", "12/3-14", "LC4400", "Hunn av Aeshna grandis i egglegging. Eggene legges gjerne i død flytevegetasjon eller, som her, i alger ved en stein.", new List<Taxon> { taxon }) };

            return new TaxonContent(taxon, topImage, attributes, content, images);
        }

    }
}
