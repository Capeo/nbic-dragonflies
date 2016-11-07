using System.Collections.Generic;
using NbicDragonflies.Models.IdentificationKey;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements {

    /// <summary>
    /// View element representing an identification key question
    /// </summary>
    public partial class IdentifyQuestionView : ContentView {

        /// <summary>
        /// The question associated with the view
        /// </summary>
        public IdentifyQuestion Question { get; private set; }

        /// <summary>
        /// List of IdentifyOptionViews belonging to the view
        /// </summary>
        public List<ViewElements.IdentifyOptionView> Options { get; private set; } 

        /// <summary>
        /// Default, empty constructor. Initializes empty question view.
        /// </summary>
        public IdentifyQuestionView()
        {
            // TODO remove?
            InitializeComponent();
        }

        /// <summary>
        /// Constructor. Initializes new instance of the view from given question.
        /// </summary>
        /// <param name="question">Question associated with the view.</param>
        public IdentifyQuestionView(IdentifyQuestion question)
        {
            InitializeComponent();

            SetQuestion(question);
        }

        private void SetQuestion(IdentifyQuestion question)
        {
            List<ViewElements.IdentifyOptionView> optionViews = new List<ViewElements.IdentifyOptionView>();
            OptionCategory.Text = question.Title;
            StackLayout.Children.Clear();
            foreach (var option in question.Options) {
                ViewElements.IdentifyOptionView optionView = new ViewElements.IdentifyOptionView(option);
                optionViews.Add(optionView);
                StackLayout.Children.Add(optionView);
            }
            Options = optionViews;
            Question = question;
        }

    }
}
