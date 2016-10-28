using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NbicDragonflies.Models;
using Xamarin.Forms;

namespace NbicDragonflies.Views {
    public partial class KeyQuestionView : ContentView {

        public KeyQuestion Question { get; private set; }

        public List<IdentifyAlternativeView> Alternatives { get; private set; } 

        public KeyQuestionView()
        {
            InitializeComponent();
        }

        public KeyQuestionView(KeyQuestion question)
        {
            InitializeComponent();

            SetQuestion(question);
        }

        private void SetQuestion(KeyQuestion question)
        {
            List<IdentifyAlternativeView> altViews = new List<IdentifyAlternativeView>();
            AlternativeCategory.Text = question.Title;
            StackLayout.Children.Clear();
            foreach (var alternative in question.Alternatives) {
                IdentifyAlternativeView alternativeView = new IdentifyAlternativeView(alternative);
                altViews.Add(alternativeView);
                StackLayout.Children.Add(alternativeView);
            }
            Alternatives = altViews;
            Question = question;
        }

    }
}
