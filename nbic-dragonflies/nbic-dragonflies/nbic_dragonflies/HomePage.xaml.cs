using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace nbic_dragonflies
{
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}

        private void Button_OnClicked(object sender, EventArgs e)
        {
            string text = MainEntry.Text;

            MainLabel.Text = "Hello" + text;
        }
	}
}
