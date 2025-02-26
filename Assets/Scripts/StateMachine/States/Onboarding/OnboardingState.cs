using _clone.Scripts.StateMachine.States.MainMenu;

namespace _clone.Scripts.StateMachine.States.Onboarding
{
    public class OnboardingState : BaseState
    {
        private BaseStateMachine stateMachine;
        
        private OnboardingStateDependencies dependencies;

        public OnboardingState()
        {
            SetNextState(new MainMenuState());
        }

        public override void Enter()
        {
            base.Enter();

            var onboardingStateMachine = new OnboardingStateMachine(dependencies.DataContainer);
            onboardingStateMachine.SetExitCallback(Exit);
            stateMachine = onboardingStateMachine;
            stateMachine.Start();
        }

        protected override void SetDependencies()
        {
            base.SetDependencies();

            dependencies = new OnboardingStateDependencies();
            
            if (dependencies.DataContainer == null)
                logService.LogError("Not found data, probably not register");
        }

        public override void Dispose()
        {
            base.Dispose();
            
            stateMachine.Dispose();
            stateMachine = null;
        }
    }
}