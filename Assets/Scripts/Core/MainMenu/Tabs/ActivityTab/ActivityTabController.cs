using System;

namespace _clone.Scripts.Core.MainMenu.Tabs.ActivityTab
{
    public class ActivityTabController : ITabController, IGameLaunchController
    {
        private readonly ActivityTabNode view;
        private Action<string> onGamePressed;

        public ActivityTabController(ActivityTabNode view)
        {
            this.view = view;
            view.SetCallbacks(OnGamePressed, OnGamePressed);
        }

        private void OnGamePressed()
        {
            onGamePressed?.Invoke("qwe");
        }

        public void Enable()
        {
            view.Enable();
        }

        public void Disable()
        {
            view.Disable();
            onGamePressed = null;
        }

        public void SetCallback(Action<string> onGamePressed)
        {
            this.onGamePressed = onGamePressed;
        }
    }
}