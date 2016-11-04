using System.Collections.Generic;

namespace NbicDragonflies.Models.IdentificationKey
{

    /// <summary>
    /// Model class representing a question for the identification key
    /// </summary>
    public class IdentifyQuestion {

        /// <summary>
        /// Title of the question
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// List of options for the question
        /// </summary>
        public List<IdentifyOption> Options { get; set; }

        /// <summary>
        /// The currently selected option. Default is null, i.e. no selected option
        /// </summary>
        public IdentifyOption SelectedOption { get; set; } = null;

        /// <summary>
        /// Constructor. Sets title and options from parameters
        /// </summary>
        /// <param name="title">Title of the question</param>
        /// <param name="options">List of options for the question</param>
        public IdentifyQuestion(string title, List<IdentifyOption> options)
        {
            Title = title;
            Options = options;
        }
    }
}
