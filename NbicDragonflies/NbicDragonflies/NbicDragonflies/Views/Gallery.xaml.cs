using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;


namespace NbicDragonflies.Views
{
	public partial class Gallery : ContentPage
	{
		public ListView ListView { get { return GalleryList; } }

		public Gallery()
		{
			InitializeComponent();

			var galleryPageItems = new List<GalleryImages>();

			galleryPageItems.Add(new GalleryImages
			{
				ImageSource = "dragonfly1.jpg",
				Text = "Dragonfly 1",
				Detail = "This is dragonfly 1",
				TargetType = typeof(Home)
			});

			galleryPageItems.Add(new GalleryImages
			{
				ImageSource = "dragonfly2.jpg",
				Text = "Dragonfly 2",
				Detail = "This is dragonfly 2",
				TargetType = typeof(Home)
			});

			GalleryList.ItemsSource = galleryPageItems;
		}
	}
}





		