using System;

namespace _clone.Scripts.Core.Onboarding.Questionnaire
{
    public class QuestionnaireStepController : OnboardingStepController
    {
        private OnboardingStepView view;
        
        private Action complete;

        public QuestionnaireStepController(QuestionnaireStepView view)
        {
            view.Init(OnStepComplete);
            this.view = view;
        }

        public void SetCallback(Action onComplete)
        {
            complete = onComplete;
        }

        public override void Run()
        {
            view.Run();
        }

        private void OnStepComplete()
        {
            complete?.Invoke();
        }

        public override void Dispose()
        {
            base.Dispose();
            view.Dispose();
            view = null;
        }
    }
}