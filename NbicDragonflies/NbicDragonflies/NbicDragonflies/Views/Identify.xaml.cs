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
        }

        public void SetController(IKeyController controller)
        {
            _controller = controller;
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
            // Send alternative
            if (_controller.HasNextQuestion())
            {
                SetQuestion(_controller.NextQuestion());
            }
            else
            {
                this.CurrentPage = ResultsTab;
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

    }
}
