using _clone.Scripts.Constants.Onboarding;
using _clone.Scripts.Core.Onboarding;
using _clone.Scripts.Core.Onboarding.Questionnaire;

namespace _clone.Scripts.StateMachine.States.Onboarding.QuestionnaireStep
{
    public class OnboardingQuestionnaireStep : BaseOnboardingStep
    {
        public override string Id => OnboardingStepsName.QuestionnaireStep;

        public override void Enter()
        {
            base.Enter();
            Run();
        }

        public override void Prepare(OnboardingStepView viewPrefab)
        {
            if (viewPrefab is QuestionnaireStepView stepViewPrefab)
            {
                var view = InitView(stepViewPrefab);
                InitController(view);
                return;
            }

            base.Prepare(viewPrefab);
        }

        private void InitController(QuestionnaireStepView view)
        {
            var stepController = new QuestionnaireStepController(view);
            stepController.SetCallback(OnStepComplete);

            Controller = stepController;
        }
    }
}