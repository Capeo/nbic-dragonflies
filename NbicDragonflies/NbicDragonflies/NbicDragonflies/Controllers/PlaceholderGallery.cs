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
				new SpeciesImage("dragonfly2.jpg", "OdonataOdonata Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
				new SpeciesImage("dragonfly1.jpg", "Odonata", "Phrida Norrhall", "12.03.2014", "LC4400", "Description", new List<Taxon> { new Taxon(107) }),
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
