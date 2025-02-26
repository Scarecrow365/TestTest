using _clone.Scripts.Constants.Onboarding;
using _clone.Scripts.Core.Onboarding;
using _clone.Scripts.Core.Onboarding.Welcome;

namespace _clone.Scripts.StateMachine.States.Onboarding.WelcomeStep
{
    public class OnboardingWelcomeStep : BaseOnboardingStep
    {
        public override string Id => OnboardingStepsName.WelcomeViewStep;

        public override void Enter()
        {
            base.Enter();
            Run();
        }

        public override void Prepare(OnboardingStepView viewPrefab)
        {
            if (viewPrefab is WelcomeStepView stepViewPrefab)
            {
                var view = InitView(stepViewPrefab);
                InitController(view);
                return;
            }

            base.Prepare(viewPrefab);
        }

        private void InitController(WelcomeStepView view)
        {
            var stepController = new WelcomeStepController(view);
            stepController.SetCallback(OnSignInComplete, OnStepComplete);

            Controller = stepController;
        }
    }
}