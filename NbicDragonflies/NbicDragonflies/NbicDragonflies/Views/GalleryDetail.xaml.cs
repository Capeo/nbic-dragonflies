using System;
using System.Collections.Generic;
using Xamarin.Forms;
using NbicDragonflies.Models;

namespace NbicDragonflies.Views
{
	public partial class GalleryDetail : MasterDetailPage
	{
		public GalleryDetail()
		{
			InitializeComponent();

			/*Gallery.ListView.ItemSelected += OnItemSelected;
		}

		void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as GalleryImages;
			if (item != null)
			{
				Detail = (Page)Activator.CreateInstance(item.TargetType);
				Gallery.ListView.SelectedItem = null;
				IsPresented = false;
			}*/
		}
	}
}


