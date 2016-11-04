using System.Collections.Generic;
using System.Linq;
using NbicDragonflies.Models.IdentificationKey;
using NbicDragonflies.Models.Taxon;

namespace NbicDragonflies.Controllers {

    /// <summary>
    /// Implementation of IIdentifyController interface.
    /// </summary>
    public class IdentifyController : IIdentifyController {

        private int _currentQuestion;
        private List<IdentifyQuestion> _questions;
        private List<IdentifySuggestion> _suggestions;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public IdentifyController()
        {
            // TODO Currently adds placeholder questions and suggestions.

            _currentQuestion = 0;
            _questions = new List<IdentifyQuestion>();
            _suggestions = new List<IdentifySuggestion>();

            IdentifyOption q1Alt1 = new IdentifyOption("Vingene legges helt eller delvis bakover langs kroppen i hvile.", "hvilestilling1.png");
            IdentifyOption q1Alt2 = new IdentifyOption("Vingene står vinkelrett ut fra kroppen i hvile.", "hvilestilling2.png");
            _questions.Add(new IdentifyQuestion("Hvilestilling", new List<IdentifyOption> { q1Alt1, q1Alt2 }));

            IdentifyOption q2Alt1 = new IdentifyOption("Vingene smale med få ribber og smal basis. Fram- og bakvinge har samme fasong. (Små arter: opptil 40 mm.)", "vingefasong1.png");
            IdentifyOption q2Alt2 = new IdentifyOption("Vingene brede med tett ribbenett og smal basis. Fram- og bakvinge har samme fasong. (Middels store arter med metallisk grønn/blå kropp; lengde 45-50 mm.)", "vingefasong2.png");
            IdentifyOption q2Alt3 = new IdentifyOption("Vingene brede med tett ribbenett og bred basis. Bakvingen er bredere enn framvingen, særlig ved basis. (Små til store arter; lengde 29-84mm.)", "vingefasong3.png");
            q2Alt3.Status = OptionStatus.Disabled;
            _questions.Add(new IdentifyQuestion("Vingefasong", new List<IdentifyOption> { q2Alt1, q2Alt2, q2Alt3 }));

            Taxon t = Data.ApplicationDataManager.GetTaxon(107).Result;
            Taxon t1 = Data.ApplicationDataManager.GetTaxon(32564).Result;

            _suggestions.Add(new IdentifySuggestion(t1, "BrownDragonfly.jpg"));
            _suggestions.Add(new IdentifySuggestion(t, "BrownDragonfly1.jpg"));
            _suggestions.Add(new IdentifySuggestion(t, "dragonfly1.jpg"));
            _suggestions.Add(new IdentifySuggestion(t, "dragonfly2.jpg"));
            _suggestions.Add(new IdentifySuggestion(t, "dragonfly1.jpg"));
            _suggestions.Add(new IdentifySuggestion(t, "dragonfly2.jpg"));
        }

        /// <summary>
        /// Returns list of current suggestions. 
        /// </summary>
        /// <returns>List of suggestions based on current selection.</returns>
        public List<IdentifySuggestion> GetSuggestions() 
        {
            // TODO Add real content

            return _suggestions;
        }

        /// <summary>
        /// Checks if another question exists, and returns true or false.
        /// </summary>
        /// <returns>True if there exists a new question, else false.</returns>
        public bool HasNextQuestion()
        {
            return _currentQuestion < _questions.Count - 1;
        }

        /// <summary>
        /// Checks if a previous question exists, and returns true or false.
        /// </summary>
        /// <returns>True if there exists a previous question, else false.</returns>
        public bool HasPreviousQuestion()
        {
            return _currentQuestion > 0;
        }

        /// <summary>
        /// Retrieves the next question.
        /// </summary>
        /// <returns>Next question, or null</returns>
        public IdentifyQuestion GetNextQuestion() 
        {
            IdentifyQuestion q = null;
            if(HasNextQuestion())
            {
                _currentQuestion++; 
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        /// <summary>
        /// Retrieves previous question.
        /// </summary>
        /// <returns>Previous question, or null</returns>
        public IdentifyQuestion GetPreviousQuestion()
        {
            IdentifyQuestion q = null;
            if (HasPreviousQuestion())
            {
                _currentQuestion--;
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        /// <summary>
        /// Retrieves the current question.
        /// </summary>
        /// <returns>Current question, or null</returns>
        public IdentifyQuestion GetCurrentQuestion()
        {
            IdentifyQuestion q = null;
            if (_currentQuestion >= 0 && _currentQuestion < _questions.Count) {
                q = _questions.ElementAt(_currentQuestion);
            }
            return q;
        }

        /// <summary>
        /// Set the selected option for the current question.
        /// </summary>
        /// <param name="option">The selected option for current question</param>
        public void SetSelectedOption(IdentifyOption option)
        {
            // TODO Should use selection to update suggestions and question list

            foreach (var alt in GetCurrentQuestion().Options)
            {
                alt.Status = OptionStatus.Enabled;
            }
            option.Status = OptionStatus.Selected;
        }
    }

}
