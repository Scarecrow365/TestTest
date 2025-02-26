using System;

namespace _clone.Scripts.Core.MainMenu.Tabs
{
    public interface IGameLaunchController
    {
        void SetCallback(Action<string> onGamePressed);
    }
}