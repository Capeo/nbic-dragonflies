using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using NbicDragonflies.Models.IdentificationKey;
using NbicDragonflies.Models.Taxon;
using NbicDragonflies.Views;

namespace NbicDragonflies.Utility {

    class IdentifyController : IIdentifyController {

        private int _currentQuestion;
        private List<IdentifyQuestion> _questions;


        public IdentifyController()
        {
            _currentQuestion = 0;

            _questions = new List<IdentifyQuestion>();

            IdentifyOption q1Alt1 = new IdentifyOption("Vingene legges helt eller delvis bakover langs kroppen i hvile.", "hvilestilling1.png");
            IdentifyOption q1Alt2 = new IdentifyOption("Vingene står vinkelrett ut fra kroppen i hvile.", "hvilestilling2.png");
            _questions.Add(new IdentifyQuestion("Hvilestilling", new List<IdentifyOption> { q1Alt1, q1Alt2 }));

            IdentifyOption q2Alt1 = new IdentifyOption("Vingene smale med få ribber og smal basis. Fram- og bakvinge har samme fasong. (Små arter: opptil 40 mm.)", "vingefasong1.png");
            IdentifyOption q2Alt2 = new IdentifyOption("Vingene brede med tett ribbenett og smal basis. Fram- og bakvinge har samme fasong. (Middels store arter med metallisk grønn/blå kropp; lengde 45-50 mm.)", "vingefasong2.png");
            IdentifyOption q2Alt3 = new IdentifyOption("Vingene brede med tett ribbenett og bred basis. Bakvingen er bredere enn framvingen, særlig ved basis. (Små til store arter; lengde 29-84mm.)", "vingefasong3.png");
            q2Alt3.Status = OptionStatus.Disabled;
            _questions.Add(new IdentifyQuestion("Vingefasong", new List<IdentifyOption> { q2Alt1, q2Alt2, q2Alt3 }));
        }

        public List<IdentifySuggestion> GetSuggestions() 
        {
            List<IdentifySuggestion> suggestions = new List<IdentifySuggestion>();

            Taxon t = Data.ApplicationDataManager.GetTaxon(107).Result;
            Taxon t1 = Data.ApplicationDataManager.GetTaxon(32564).Result;

            suggestions.Add(new IdentifySuggestion(t1, "BrownDragonfly.jpg"));
            suggestions.Add(new IdentifySuggestion(t, "BrownDragonfly1.jpg"));
            suggestions.Add(new IdentifySuggestion(t, "dragonfly1.jpg"));
            suggestions.Add(new IdentifySuggestion(t, "dragonfly2.jpg"));
            suggestions.Add(new IdentifySuggestion(t, "dragonfly1.jpg"));
            suggestions.Add(new IdentifySuggestion(t, "dragonfly2.jpg"));

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

        public IdentifyQuestion GetNextQuestion() 
        {
            IdentifyQuestion q = null;
            if(_currentQuestion < _questions.Count - 1)
            {
                _currentQuestion++; 
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        public IdentifyQuestion GetPreviousQuestion()
        {
            IdentifyQuestion q = null;
            if (_currentQuestion > 0)
            {
                _currentQuestion--;
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        public IdentifyQuestion GetCurrentQuestion()
        {
            IdentifyQuestion q = null;
            if (_currentQuestion >= 0 && _currentQuestion < _questions.Count) {
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        public void SetSelectedOption(IdentifyOption alternative)
        {

            foreach (var alt in GetCurrentQuestion().Options)
            {
                alt.Status = OptionStatus.Enabled;
            }
            alternative.Status = OptionStatus.Selected;
        }
    }

}
