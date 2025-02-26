using System;
using Object = UnityEngine.Object;

namespace _clone.Scripts.Core.Game.GameplayState.PauseMenu
{
    public class PauseMenuController
    {
        private PauseMenuView view;

        public PauseMenuController(PauseMenuView viewPrefab)
        {
            CreateView(viewPrefab);
        }

        public void Show()
        {
            view.Show();
        }

        private void CreateView(PauseMenuView viewPrefab)
        {
            view = Object.Instantiate(viewPrefab);
        }

        public void SetCallbacks(Action restart, Action exit, Action onPauseMenuEnable, Action onPauseMenuDisable)
        {
            view.SetCallbacks(exit, onPauseMenuDisable, onPauseMenuEnable, restart);
        }

        public void Hide()
        {
            view.gameObject.SetActive(false);
        }
    }
}