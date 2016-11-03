using System.Collections.Generic;
using NbicDragonflies.Models.IdentificationKey;
using Xamarin.Forms;

namespace NbicDragonflies.Views.ViewElements {

    public partial class IdentifyQuestionView : ContentView {

        public IdentifyQuestion Question { get; private set; }

        public List<ViewElements.IdentifyOptionView> Options { get; private set; } 

        public IdentifyQuestionView()
        {
            InitializeComponent();
        }

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
