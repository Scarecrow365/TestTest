using _clone.Scripts.Core.Game.GameplayState;
using _clone.Scripts.Core.Game.PreGamePanelState;
using _clone.Scripts.Data.Game;
using _clone.Scripts.Services.SceneLoader;
using _clone.Scripts.StateMachine.States.MainMenu;
using UnityEngine.SceneManagement;

namespace _clone.Scripts.StateMachine.States.Game
{
    public class GameState : BaseState
    {
        private BaseGameBundle gameBundle;
        private GameStateDependencies dependencies;
        private GameplayController gameplayController;
        private PreGamePanelController preGamePanelController;

        private readonly string gameId;

        public GameState(string gameId)
        {
            this.gameId = gameId;

            SetNextState(new MainMenuState());
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
            dependencies = new GameStateDependencies();
        }

        protected override void Exit()
        {
            dependencies.SceneLoader
                .LoadMainScene(LoadSceneMode.Additive, () =>
                {
                    UnloadScene(SceneLoader.GameSceneName);
                    base.Exit();
                    preGamePanelController.Exit();
                });
        }

        private void Prepare()
        {
            if (!dependencies.Container.TryGetGameBundleById(gameId, out gameBundle) || gameBundle == null)
            {
                dependencies.LogService.LogError($"Game with id: {gameId} not found");
                Exit();
                return;
            }
            
            LoadGameScene();
        }

        private void LoadGameScene()
        {
            dependencies.SceneLoader
                .LoadGameScene(LoadSceneMode.Additive, () =>
                {
                    UnloadScene(SceneLoader.MainSceneName);
                    PreparePreGamePanel();
                    dependencies.LogService.Log($"Game with id: {gameId}");
                });
        }

        private void PreparePreGamePanel()
        {
            var viewPrefab = dependencies.Container.PreGamePanelPrefab;
            preGamePanelController = new PreGamePanelController(viewPrefab);
            preGamePanelController.Init(gameBundle.PreGameData, OnPlay, Exit);
            preGamePanelController.Show();
        }

        private void OnPlay()
        {
            preGamePanelController.Hide();
            gameplayController = new GameplayController();
            gameplayController.Init(gameBundle.GamePrefab, dependencies.Container.PauseMenuPrefab, OnGameComplete, Exit);
        }

        private void OnGameComplete()
        {
            Exit();
        }

        private void Run()
        {
            
        }

        private void UnloadScene(string sceneName) => dependencies.SceneLoader.UnloadScene(sceneName);

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}