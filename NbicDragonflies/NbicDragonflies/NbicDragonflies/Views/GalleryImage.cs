using System;

using Xamarin.Forms;

namespace NbicDragonflies
{
	public class GalleryImage : ContentPage
	{
		public GalleryImage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

