using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NbicDragonflies.Views
{
	public partial class Gallery : ContentPage
	{
		public Gallery()
		{
			InitializeComponent();

			Label header = new Label
			{
				Text = "Gallery",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			TableView tableView = new TableView
			{
				Intent = TableIntent.Form,
				Root = new TableRoot
				{
					new TableSection
					{
						new ImageCell
						{
							ImageSource = ImageSource.FromFile("dragonfly1.jpg"),
							Text = "Dragonfly 1",
							Detail = "This is dragonfly 1",
							DetailColor = Color.Aqua,
						}
					}
				}
			};

			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			this.Content = new StackLayout
			{
				Children =
				{
					header,
					tableView
				}
			};
		}
	}
}

		