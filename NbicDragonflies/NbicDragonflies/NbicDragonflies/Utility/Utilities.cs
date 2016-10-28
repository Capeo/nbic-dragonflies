using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NbicDragonflies.Utility {

    public static class Utilities {

        public static View GetAncestor(VisualElement e, Type ancestorType) {
            if (e != null) {
                var parent = e.Parent;
                while (parent != null) {
                    if (parent.GetType() == ancestorType ) {
                        return (View)parent;
                    }
                    parent = parent.Parent;
                }
            }
            return null;
        }


    }
}
