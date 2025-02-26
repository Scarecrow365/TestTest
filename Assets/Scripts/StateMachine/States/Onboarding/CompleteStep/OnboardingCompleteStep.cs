using _clone.Scripts.Constants.Onboarding;
using _clone.Scripts.Core.Onboarding;
using _clone.Scripts.Core.Onboarding.Complete;

namespace _clone.Scripts.StateMachine.States.Onboarding.CompleteStep
{
    public class OnboardingCompleteStep : BaseOnboardingStep
    {
        public override string Id => OnboardingStepsName.CompleteStep;

        public override void Enter()
        {
            base.Enter();
            Run();
        }
        
        public override void Prepare(OnboardingStepView viewPrefab)
        {
            if (viewPrefab is CompeteStepView stepViewPrefab)
            {
                var view = InitView(stepViewPrefab);
                InitController(view);
                return;
            }

            base.Prepare(viewPrefab);
        }
        
        private void InitController(CompeteStepView view)
        {
            var stepController = new CompeteStepController(view);
            stepController.SetCallback(OnStepComplete);

            Controller = stepController;
        }
    }
}