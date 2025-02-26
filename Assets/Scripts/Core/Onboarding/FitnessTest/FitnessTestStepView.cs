using System;
using UnityEngine;
using UnityEngine.UI;
using _clone.Scripts.Constants.Onboarding;

namespace _clone.Scripts.Core.Onboarding.FitnessTest
{
    public class FitnessTestStepView : OnboardingStepView
    {
        [SerializeField] private Button skipButton;
        
        private Action onStepComplete;
        
        public override string Id => OnboardingStepsName.FitnessTestStep;

        private void Start()
        {
            skipButton.onClick.AddListener(OnSkipButtonPressed);
        }

        public override void Run()
        {
            gameObject.SetActive(true);
        }

        public void SetCallBacks(Action onStepComplete)
        {
            this.onStepComplete = onStepComplete;
        }

        private void OnSkipButtonPressed()
        {
            Complete();
        }
        
        protected override void Complete()
        {
            onStepComplete?.Invoke();
        }

        public override void Dispose()
        {
            gameObject.SetActive(false);
            base.Dispose();
            Destroy(gameObject);
        }
    }
}