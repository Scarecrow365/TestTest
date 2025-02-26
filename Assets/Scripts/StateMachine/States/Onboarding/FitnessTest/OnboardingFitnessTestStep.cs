using _clone.Scripts.Constants.Onboarding;
using _clone.Scripts.Core.Onboarding;
using _clone.Scripts.Core.Onboarding.FitnessTest;

namespace _clone.Scripts.StateMachine.States.Onboarding.FitnessTest
{
    public class OnboardingFitnessTestStep : BaseOnboardingStep
    {
        public override string Id => OnboardingStepsName.FitnessTestStep;

        public override void Enter()
        {
            base.Enter();
            Run();
        }
        
        public override void Prepare(OnboardingStepView viewPrefab)
        {
            if (viewPrefab is FitnessTestStepView stepViewPrefab)
            {
                var view = InitView(stepViewPrefab);
                InitController(view);
                return;
            }

            base.Prepare(viewPrefab);
        }
        
        private void InitController(FitnessTestStepView view)
        {
            var stepController = new FitnessTestStepController(view);
            stepController.SetCallback(OnStepComplete);

            Controller = stepController;
        }
    }
}