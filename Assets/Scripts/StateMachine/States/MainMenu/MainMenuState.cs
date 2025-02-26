using _clone.Scripts.Core.MainMenu;
using _clone.Scripts.StateMachine.States.Game;

namespace _clone.Scripts.StateMachine.States.MainMenu
{
    public class MainMenuState : BaseState
    {
        private MainScreenController controller;
        private MainMenuStateDependencies dependencies;

        public MainMenuState()
        {
            SetNextState(new ExitState());
        }

        public override void Enter()
        {
            base.Enter();
            Prepare();
            Run();
        }

        protected override void SetDependencies()
        {
            base.SetDependencies();

            dependencies = new MainMenuStateDependencies();
            
            if (dependencies.DataContainer == null)
                logService.LogError("Not found data, probably not register");
        }

        private void Prepare()
        {
            InitController();
        }

        private void InitController()
        {
            controller = new MainScreenController(dependencies);
            controller.SetCallback(OnSignIn, OnGamePressed);
        }

        private void OnGamePressed(string gameId)
        {
            logService.Log($"Game id - {gameId}");
            SetNextState(new GameState(gameId));
            Exit();
        }

        private void OnSignIn()
        {
            SetNextState(new ExitState());
            Exit();
        }

        private void Run()
        {
            controller.Run();
        }
        
        public override void Dispose()
        {
            base.Dispose();
            controller.Dispose();
            controller = null;
        }
    }
}