using _clone.Scripts.Services;
using _clone.Scripts.Services.Loader;
using _clone.Scripts.Services.LogService;
using _clone.Scripts.Services.SceneLoader;
using _clone.Scripts.StateMachine.States.Onboarding;

namespace _clone.Scripts.StateMachine.States.Main
{
    public class StartState : BaseState
    {
        public override void Enter()
        {
            base.Enter();
            RegisterServices();
            Prepare();
            Exit();
        }

        private static void RegisterServices()
        {
            ServiceLocator.Container.RegisterSingle(new Loader());
            ServiceLocator.Container.RegisterSingle(new SceneLoader());
            
            ServiceLocator.Container.RegisterSingle<ILogService>(new LogService());
        }

        private void Prepare()
        {
            SetNextState(new OnboardingState());
        }
    }
}