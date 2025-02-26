using System;
using _clone.Scripts.Games;
using _clone.Scripts.Core.Game.GameplayState.PauseMenu;

namespace _clone.Scripts.Core.Game.GameplayState
{
    public class GameplayController
    {
        private BaseGame game;
        private PauseMenuController pauseMenu;

        private Action onExit;
        private Action onGameComplete;

        public void Init(BaseGame gamePrefab, PauseMenuView pauseViewPrefab, Action onGameComplete, Action onExit)
        {
            this.onExit = onExit;
            this.onGameComplete = onGameComplete;
            CreateGame(gamePrefab);
            CreatePauseMenu(pauseViewPrefab);

            game.Launch();
        }

        private void CreateGame(BaseGame gamePrefab)
        {
            game = UnityEngine.Object.Instantiate(gamePrefab);
            game.SetCallback(GameComplete);
            game.Init();
        }

        private void CreatePauseMenu(PauseMenuView pauseViewPrefab)
        {
            pauseMenu = new PauseMenuController(pauseViewPrefab);
            pauseMenu.Hide();
            pauseMenu.SetCallbacks(Restart, Exit, OnPauseMenuEnable, OnPauseMenuDisable);
        }

        private void Restart()
        {
            game.PrepareForRestart();
            game.Launch();
        }
        
        private void OnPauseMenuEnable()
        {
            game.Pause();
        }
        
        private void OnPauseMenuDisable()
        {
            game.Unpause();
        }

        private void GameComplete()
        {
            game.Exit();
            onGameComplete?.Invoke();
        }

        private void Exit()
        {
            game.Exit();
            onExit?.Invoke();
        }
    }
}