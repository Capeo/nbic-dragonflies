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

        public ListView ListView1 { get { return ResultsList; } }

        private IKeyController _controller;

        private bool _previousQuestion;

        public Identify(IKeyController controller)
        {
            InitializeComponent();

            _controller = controller;

            _previousQuestion = false;

            SetQuestion(_controller.NextQuestion());

            ResultsList.ItemsSource = _controller.GetSuggestions();
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
            QuestionsLayout.Children.Insert(0, view);

            NextQuestion.IsEnabled = _controller.HasNextQuestion();
            PreviousQuestion.IsEnabled = _previousQuestion;
        }

        private void HandleAlternativeTap(object sender, EventArgs e)
        {
            // Send alternative
            if (_controller.HasNextQuestion())
            {
                _previousQuestion = true;
                SetQuestion(_controller.NextQuestion());
            }
            else
            {
                this.CurrentPage = ResultsTab;
            }
        }
    }
}
