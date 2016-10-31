using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using NbicDragonflies.Views;

namespace NbicDragonflies.Utility {

    class PlaceholderKey : IKeyController {

        private int _currentQuestion;
        private List<KeyQuestion> _questions;


        public PlaceholderKey() {
            _currentQuestion = 0;

            _questions = new List<KeyQuestion>();

            IdentifyAlternative q1Alt1 = new IdentifyAlternative("Vingene legges helt eller delvis bakover langs kroppen i hvile.", "hvilestilling1.png");
            IdentifyAlternative q1Alt2 = new IdentifyAlternative("Vingene står vinkelrett ut fra kroppen i hvile.", "hvilestilling2.png");
            _questions.Add(new KeyQuestion("Hvilestilling", new List<IdentifyAlternative> { q1Alt1, q1Alt2 }));

            IdentifyAlternative q2Alt1 = new IdentifyAlternative("Vingene smale med få ribber og smal basis. Fram- og bakvinge har samme fasong. (Små arter: opptil 40 mm.)", "vingefasong1.png");
            IdentifyAlternative q2Alt2 = new IdentifyAlternative("Vingene brede med tett ribbenett og smal basis. Fram- og bakvinge har samme fasong. (Middels store arter med metallisk grønn/blå kropp; lengde 45-50 mm.)", "vingefasong2.png");
            IdentifyAlternative q2Alt3 = new IdentifyAlternative("Vingene brede med tett ribbenett og bred basis. Bakvingen er bredere enn framvingen, særlig ved basis. (Små til store arter; lengde 29-84mm.)", "vingefasong3.png");
            q2Alt3.Status = AlternativeStatus.Disabled;
            _questions.Add(new KeyQuestion("Vingefasong", new List<IdentifyAlternative> { q2Alt1, q2Alt2, q2Alt3 }));
        }

        public List<KeySuggestion> GetSuggestions() {
            List<KeySuggestion> suggestions = new List<KeySuggestion>();

            Taxon t = Data.ApplicationDataManager.GetTaxon(107).Result;
            Taxon t1 = Data.ApplicationDataManager.GetTaxon(32564).Result;

            suggestions.Add(new KeySuggestion(t1, "BrownDragonfly.jpg"));
            suggestions.Add(new KeySuggestion(t, "BrownDragonfly1.jpg"));
            suggestions.Add(new KeySuggestion(t, "dragonfly1.jpg"));
            suggestions.Add(new KeySuggestion(t, "dragonfly2.jpg"));
            suggestions.Add(new KeySuggestion(t, "dragonfly1.jpg"));
            suggestions.Add(new KeySuggestion(t, "dragonfly2.jpg"));

            return suggestions;
        }

        public bool HasNextQuestion()
        {
            return _currentQuestion < _questions.Count - 1;
        }

        public bool HasPreviousQuestion()
        {
            return _currentQuestion > 0;
        }

        public KeyQuestion NextQuestion() 
        {
            KeyQuestion q = null;
            if(_currentQuestion < _questions.Count - 1)
            {
                _currentQuestion++; 
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        public KeyQuestion PreviousQuestion()
        {
            KeyQuestion q = null;
            if (_currentQuestion > 0)
            {
                _currentQuestion--;
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        public KeyQuestion CurrentQuestion()
        {
            KeyQuestion q = null;
            if (_currentQuestion >= 0 && _currentQuestion < _questions.Count) {
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        public void SetAlternative(IdentifyAlternative alternative) {

            foreach (var alt in CurrentQuestion().Alternatives)
            {
                alt.Status = AlternativeStatus.Enabled;
            }
            alternative.Status = AlternativeStatus.Selected;
        }
    }

}
