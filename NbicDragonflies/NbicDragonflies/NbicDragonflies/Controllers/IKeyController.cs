using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;

namespace NbicDragonflies.Controllers {

    public interface IKeyController
    {

        KeyQuestion CurrentQuestion();

        KeyQuestion NextQuestion();

        KeyQuestion PreviousQuestion();

        bool HasNextQuestion();

        bool HasPreviousQuestion();

        void SetAlternative(IdentifyAlternative alternative);

        List<KeySuggestion> GetSuggestions();

    }
}
