using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {
    public class HomeInfo {

        public string Text { get; set; }
        public string Image { get; set; }
        public Taxon Taxon { get; set; }

        public HomeInfo(string text, string image, Taxon taxon)
        {
            Text = text;
            Image = image;
            Taxon = taxon;
        }

    }
}
