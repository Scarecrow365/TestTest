using System;

namespace _clone.Scripts.Core.Onboarding.Welcome
{
    public class WelcomeStepController : OnboardingStepController
    {
        private WelcomeStepView view;

        private Action onSignIn;
        private Action onStepComplete;

        public WelcomeStepController(WelcomeStepView view)
        {
            this.view = view;
            Init();
        }

        public void SetCallback(Action onSignIn, Action onStepComplete)
        {
            this.onSignIn = onSignIn;
            this.onStepComplete = onStepComplete;
        }

        public override void Run()
        {
            view.Run();
        }

        private void Init()
        {
            view.Init(CompleteSignIn, Complete);
        }

        private void Complete()
        {
            onStepComplete?.Invoke();
        }

        private void CompleteSignIn()
        {
            onSignIn?.Invoke();
        }

        public override void Dispose()
        {
            base.Dispose();
            view.Dispose();
            view = null;
        }
    }
}