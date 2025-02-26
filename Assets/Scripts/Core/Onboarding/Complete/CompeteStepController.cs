using System;

namespace _clone.Scripts.Core.Onboarding.Complete
{
    public class CompeteStepController : OnboardingStepController
    {
        private CompeteStepView view;
        private Action onStepComplete;

        public CompeteStepController(CompeteStepView view)
        {
            this.view = view;
        }
        
        public override void Run()
        {
            view.SetCallBacks(OnStepComplete);
            view.Run();
        }

        public void SetCallback(Action onStepComplete)
        {
            this.onStepComplete = onStepComplete;
        }
        
        private void OnStepComplete()
        {
            onStepComplete?.Invoke();
        }

        public override void Dispose()
        {
            base.Dispose();
            view.Dispose();
            view = null;
        }
    }
}