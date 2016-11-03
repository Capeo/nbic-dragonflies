using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies.Controllers
{

	/// <summary>
	/// Ïnterface for GalleryPage Page controller. Binds data between GalleryPage Page view and model classes.
	/// </summary>
	public interface IGalleryController
	{


		/// <summary>
		/// Retrieves images from the API/Database.
		/// </summary>
		/// <returns>List of ImageElements.</returns>
		List<ImageElement> GetGalleryImages();

	}
}
