using System;
using System.Collections.ObjectModel;


namespace NbicDragonflies.Models
{

    public class IdentifyAlternative
    {
        public string Image { get; set; }
        public string Text { get; set; }

        public IdentifyAlternative(string text, string image)
        {
            Text = text;
            Image = image;
        }
    }

}