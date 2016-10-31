using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {

    public partial class Identify : TabbedPage {

        private IKeyController _controller;

        public Identify(IKeyController controller)

        {
            InitializeComponent();

            _controller = controller;

            SetQuestion(_controller.CurrentQuestion());
            ResultsList.ItemsSource = _controller.GetSuggestions();

            NextQuestion.Clicked += NextButtonClicked;
            PreviousQuestion.Clicked += PreviousButtonClicked;

			ResultsList.ItemSelected += OnResultItemSelected;
        }

        private void SetQuestion(KeyQuestion question)
        {
            KeyQuestionView view = new KeyQuestionView(question);
            foreach (var alternative in view.Alternatives)
            {
                alternative.AlternativeTap.Tapped += HandleAlternativeTap;
            }
            QuestionsLayout.Children.Clear();
            QuestionsLayout.Children.Insert(0, view);

            NextQuestion.IsEnabled = _controller.HasNextQuestion();
            PreviousQuestion.IsEnabled = _controller.HasPreviousQuestion();

        }

        private void HandleAlternativeTap(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Frame))
            {
                IdentifyAlternativeView alternativeView = (IdentifyAlternativeView) Utility.Utilities.GetAncestor((Frame)sender, typeof(IdentifyAlternativeView));

                _controller.SetAlternative(alternativeView.Alternative);

                if (_controller.HasNextQuestion())
                {
                    SetQuestion(_controller.NextQuestion());
                }
                else
                {
                    SetQuestion(_controller.CurrentQuestion());
                    this.CurrentPage = ResultsTab;
                }
            }
            
        }

        private void NextButtonClicked(object sender, EventArgs e)
        {
            if (_controller.HasNextQuestion()) 
            {
                SetQuestion(_controller.NextQuestion());
            }
        }

        private void PreviousButtonClicked(object sender, EventArgs e)
        {
            if (_controller.HasPreviousQuestion())
            {
                SetQuestion(_controller.PreviousQuestion());
            }
        }


        private async void OnResultItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            ResultsList.IsEnabled = false;
            var item = e.SelectedItem;
            if (item != null)
            {
                KeySuggestion suggestion = (KeySuggestion)item;
                await Navigation.PushAsync(new SpeciesInfo(new Species(suggestion.Taxon)));
                ResultsList.SelectedItem = null;
            }
			System.Diagnostics.Debug.WriteLine("pressed");
            ResultsList.IsEnabled = true;
        }
    }
}
