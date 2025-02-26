using System;
using _clone.Scripts.Constants.Onboarding;
using UnityEngine;

namespace _clone.Scripts.Core.Onboarding.Questionnaire
{
    public class QuestionnaireStepView : OnboardingStepView
    {
        [SerializeField] private QuestionnaireElement[] elements;

        private event Action onStepComplete;

        private int questionnaireElementIndex;
        
        public override string Id => OnboardingStepsName.QuestionnaireStep;

        public void Init(Action onStepComplete)
        {
            this.onStepComplete = onStepComplete;

            for (int i = 0; i < elements.Length; i++)
            {
                elements[i].Hide();
                elements[i].Set(i != 0);
                elements[i].SetCallbacks(GetCallbacks());
            }
        }

        public override void Run()
        {
            gameObject.SetActive(true);
            elements[questionnaireElementIndex].Show();
        }

        protected override void Complete()
        {
            onStepComplete?.Invoke();
            gameObject.SetActive(false);
        }
        
        private void OnNoButtonPressed()
        {
            if (TryShowNextElement()) return;
            Complete();
        }

        private void OnYesButtonPressed()
        {
            if (TryShowNextElement()) return;
            Complete();
        }

        private void OnSkipPressed()
        {
            Complete();
        }

        private void OnBackPressed()
        {
            elements[questionnaireElementIndex].gameObject.SetActive(false);
            questionnaireElementIndex--;
        }
        
        private bool TryShowNextElement()
        {
            elements[questionnaireElementIndex].Hide();
            questionnaireElementIndex++;
            
            if (questionnaireElementIndex >= elements.Length) return false;
            
            elements[questionnaireElementIndex].Show();
            return true;
        }

        private QuestionnaryScreenCallbacks GetCallbacks()
        {
            return new QuestionnaryScreenCallbacks
            {
                BackButtonCallback = OnBackPressed,
                SkipButtonCallback = OnSkipPressed,
                YesButtonCallback = OnYesButtonPressed,
                NoButtonCallback = OnNoButtonPressed
            };
        }

        public override void Dispose()
        {
            gameObject.SetActive(false);
            base.Dispose();
            Destroy(gameObject);
        }
    }
}