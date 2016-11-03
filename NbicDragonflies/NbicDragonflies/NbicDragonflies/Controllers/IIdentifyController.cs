using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using NbicDragonflies.Models.IdentificationKey;

namespace NbicDragonflies.Controllers {


    /// <summary>
    /// Ïnterface for Identification Key Page controller. Binds data between Identification Key Page view and model classes.
    /// </summary>
    public interface IIdentifyController
    {


        /// <summary>
        /// Retrieves the current question for the Identification Key.
        /// </summary>
        /// <returns>IdentifyQuestion</returns>
        IdentifyQuestion GetCurrentQuestion();


        /// <summary>
        /// Retrieves next question for the Identification Key.
        /// </summary>
        /// <returns>IdentifyQuestion</returns>
        IdentifyQuestion GetNextQuestion();

        /// <summary>
        /// Retrieves the previous question for the Identification Key.
        /// </summary>
        /// <returns>IdentifyQuestion</returns>
        IdentifyQuestion GetPreviousQuestion();

        /// <summary>
        /// Checks if there exists another question.
        /// </summary>
        /// <returns>bool</returns>
        bool HasNextQuestion();


        /// <summary>
        /// Checks if there exists a previous question.
        /// </summary>
        /// <returns>bool</returns>
        bool HasPreviousQuestion();


        /// <summary>
        /// Sets the option selected by the user for the current question.
        /// </summary>
        /// <param name="option">The selected option</param>
        void SetSelectedOption(IdentifyOption option);


        /// <summary>
        /// Retrieves list of suggetions.
        /// </summary>
        /// <returns>List of IdentifySuggestion objects</returns>
        List<IdentifySuggestion> GetSuggestions();

    }
}
