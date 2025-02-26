using System;
using _clone.Scripts.Constants.Onboarding;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Onboarding.Complete
{
    public class CompeteStepView : OnboardingStepView
    {
        [SerializeField] private Button CompleteButton;

        private Action onStepComplete;
        public override string Id => OnboardingStepsName.CompleteStep;
        
        private void Start()
        {
            CompleteButton.onClick.AddListener(OnCompleteButtonPressed);
        }

        public void SetCallBacks(Action onStepComplete)
        {
            this.onStepComplete = onStepComplete;
        }

        public override void Run()
        {
            gameObject.SetActive(true);
        }

        protected override void Complete()
        {
            onStepComplete?.Invoke();
        }
        
        private void OnCompleteButtonPressed()
        {
            Complete();
        }

        public override void Dispose()
        {
            gameObject.SetActive(false);
            base.Dispose();
            Destroy(gameObject);
        }
    }
}