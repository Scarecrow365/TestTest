using System;
using _clone.Scripts.Data.Game;
using Object = UnityEngine.Object;

namespace _clone.Scripts.Core.Game.PreGamePanelState
{
    public class PreGamePanelController
    {
        private PreGamePanelView view;
        
        public PreGamePanelController(PreGamePanelView gameBundleGamePrefab)
        {
            CreateView(gameBundleGamePrefab);
        }

        public void Init(PreGameData preGameData, Action onPlay, Action onExit)
        {
            view.Init(preGameData);
            view.SetSubscribes(onPlay, onExit);
        }

        public void Show()
        {
            view.Show();
        }

        public void Hide()
        {
            view.Hide();
        }

        private void CreateView(PreGamePanelView prefab)
        {
            view = Object.Instantiate(prefab);
        }

        public void Exit()
        {
            
        }
    }
}