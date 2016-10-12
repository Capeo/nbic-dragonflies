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
		int tapCount = 0;
		public Gallery()
		{
			InitializeComponent();

			var tgr = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
			tgr.Tapped += (sender, args) =>
			{
				tapCount++;

				System.Diagnostics.Debug.WriteLine("tapped ");

			};

			p00.GestureRecognizers.Add(tgr);
			p01.GestureRecognizers.Add(tgr);
			p02.GestureRecognizers.Add(tgr);
			p10.GestureRecognizers.Add(tgr);
			p11.GestureRecognizers.Add(tgr);
			p12.GestureRecognizers.Add(tgr);
			p20.GestureRecognizers.Add(tgr);
			p21.GestureRecognizers.Add(tgr);
			p22.GestureRecognizers.Add(tgr);




			p00.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};
			p01.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};
			p02.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};
			p10.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};
			p11.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};

			p12.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};
			p20.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};
			p21.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};
			p22.Image = new SpeciesImage
			{
				ImageSource = "dragonfly1.jpg",
				Owner = "Phrida Norrhall",
				Caption = "23 Januari, 2012"
			};
		}
	}
}
	