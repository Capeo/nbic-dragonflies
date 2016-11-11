using System;
using NbicDragonflies.Controllers;
using NbicDragonflies.Models.IdentificationKey;
using NbicDragonflies.Models.Taxon;
using NbicDragonflies.Utility;
using Xamarin.Forms;

namespace NbicDragonflies.Views.Pages {

    /// <summary>
    /// Identification key page.
    /// </summary>
    public partial class IdentifyPage : TabbedPage {

        private IIdentifyController _controller;

        /// <summary>
        /// Constructor. Initializes new Identify page
        /// </summary>
        public IdentifyPage()
        {
            InitializeComponent();

            _controller = new IdentifyController();

            SetQuestion(_controller.GetCurrentQuestion());

            NextQuestion.Clicked += OnNextButtonClicked;
            PreviousQuestion.Clicked += OnPreviousButtonClicked;
			SuggestionsList.ItemSelected += OnSuggestedItemSelected;
        }

        private void SetQuestion(IdentifyQuestion question)
        {
            ViewElements.IdentifyQuestionView view = new ViewElements.IdentifyQuestionView(question);
            foreach (var optionView in view.Options)
            {
                optionView.OptionTap.Tapped += OnOptionTap;
            }
            QuestionsLayout.Children.Clear();
            QuestionsLayout.Children.Insert(0, view);

            NextQuestion.IsEnabled = _controller.HasNextQuestion();
            PreviousQuestion.IsEnabled = _controller.HasPreviousQuestion();

            SuggestionsList.ItemsSource = null;
            SuggestionsList.ItemsSource = _controller.GetSuggestions();
        }

        private void OnOptionTap(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Frame))
            {
                ViewElements.IdentifyOptionView optionView = (ViewElements.IdentifyOptionView) Utility.Utilities.GetWrapperView((Frame)sender, typeof(ViewElements.IdentifyOptionView));

                _controller.SetSelectedOption(optionView.Option);

                if (_controller.HasNextQuestion())
                {
                    SetQuestion(_controller.GetNextQuestion());
                }
                else
                {
                    SetQuestion(_controller.GetCurrentQuestion());
                    this.CurrentPage = SuggestionsTab;
                }
            }
            
        }

        private void OnNextButtonClicked(object sender, EventArgs e)
        {
            if (_controller.HasNextQuestion()) 
            {
                SetQuestion(_controller.GetNextQuestion());
                
            }
        }

        private void OnPreviousButtonClicked(object sender, EventArgs e)
        {
            if (_controller.HasPreviousQuestion())
            {
                SetQuestion(_controller.GetPreviousQuestion());
            }
        }


        private async void OnSuggestedItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            SuggestionsList.IsEnabled = false;
            var item = e.SelectedItem;
            if (item != null)
            {
                IdentifySuggestion suggestion = (IdentifySuggestion)item;
                await Navigation.PushAsync(new TaxonContentPage(suggestion.Taxon));
                SuggestionsList.SelectedItem = null;
            }
            SuggestionsList.IsEnabled = true;
        }
    }
}
