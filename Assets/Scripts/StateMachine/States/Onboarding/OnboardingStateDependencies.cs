using _clone.Scripts.Data.Onboarding;

namespace _clone.Scripts.StateMachine.States.Onboarding
{
    public class OnboardingStateDependencies
    {
        public OnboardingContainer DataContainer { get; private set; }

        public OnboardingStateDependencies()
        {
            AddDataContainer();
        }

        private void AddDataContainer() => DataContainer = Data.Data.Container.Single<OnboardingContainer>();
    }
}