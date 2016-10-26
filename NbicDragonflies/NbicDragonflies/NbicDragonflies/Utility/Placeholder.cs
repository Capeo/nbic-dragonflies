using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using NbicDragonflies.Views;

namespace NbicDragonflies.Utility {

    class Placeholder : IKeyController {

        public List<KeySuggestion> GetSuggestions() {
            List<KeySuggestion> suggestions = new List<KeySuggestion>();

            suggestions.Add(new KeySuggestion {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 1",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            suggestions.Add(new KeySuggestion {
                ImageSource = "dragonfly2.jpg",
                Text = "Dragonfly 2",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            suggestions.Add(new KeySuggestion {
                ImageSource = "dragonfly2.jpg",
                Text = "Dragonfly 3",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            suggestions.Add(new KeySuggestion {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 4",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            suggestions.Add(new KeySuggestion {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 5",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            suggestions.Add(new KeySuggestion {
                ImageSource = "dragonfly2.jpg",
                Text = "Dragonfly 6",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            suggestions.Add(new KeySuggestion {
                ImageSource = "dragonfly1.jpg",
                Text = "Dragonfly 7",
                Detail = "Something latin",
                TargetType = typeof(Home)
            });

            return suggestions;
        }

        public bool HasNextQuestion()
        {
            return false;
        }

        public KeyQuestion NextQuestion() {
            IdentifyAlternative alt1 = new IdentifyAlternative("Vingene legges helt eller delvis bakover langs kroppen i hvile.", "hvilestilling1.png");
            IdentifyAlternative alt2 = new IdentifyAlternative("Vingene står vinkelrett ut fra kroppen i hvile.", "hvilestilling2.png");
            return new KeyQuestion("Hvilestilling", new List<IdentifyAlternative> { alt1, alt2 });
        }

        public void SetAlternative(IdentifyAlternative alternative) {
            throw new NotImplementedException();
        }
    }

}
