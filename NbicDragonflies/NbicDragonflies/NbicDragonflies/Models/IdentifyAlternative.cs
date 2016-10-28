using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace NbicDragonflies.Models
{

    public enum AlternativeStatus
    {
        Selected,
        Disabled,
        Enabled
    }

    public class IdentifyAlternative
    {
        public string Image { get; set; }
        public string Text { get; set; }
        public AlternativeStatus Status { get; set; }

        public IdentifyAlternative(string text, string image)
        {
            Text = text;
            Image = image;
            Status = AlternativeStatus.Enabled;
        }
    }

}