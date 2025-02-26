using System;
using _clone.Scripts.Data.MainMenu;

namespace _clone.Scripts.Core.MainMenu.Tabs.GamesTab
{
    public class GamesTabController : ITabController, IGameLaunchController
    {
        private readonly GamesTabNode view;
        private readonly GamesTabContainer data;
        
        public GamesTabController(GamesTabNode view, GamesTabContainer data)
        {
            this.data = data;
            this.view = view;
        }

        public void Enable()
        {
            view.SetData(data);
            view.Enable();
        }

        public void Disable()
        {
            view.Disable();
        }

        public void SetCallback(Action<string> onGamePressed)
        {
            view.SetCallback(onGamePressed);
        }
    }
}