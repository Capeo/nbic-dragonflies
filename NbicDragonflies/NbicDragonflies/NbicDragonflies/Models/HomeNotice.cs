using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbicDragonflies.Models {

    public class HomeNotice {

        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public Taxon.Taxon Taxon { get; set; }

        public HomeNotice(string title, string text, string image, Taxon.Taxon taxon)
        {
            Title = title;
            Text = text;
            Image = image;
            Taxon = taxon;
        }

    }
}
