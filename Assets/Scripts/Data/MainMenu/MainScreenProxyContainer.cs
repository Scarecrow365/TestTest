using System;
using _clone.Scripts.Core.MainMenu;
using _clone.Scripts.Core.MainMenu.Tabs;
using Object = UnityEngine.Object;

namespace _clone.Scripts.Data.MainMenu
{
    public class MainScreenProxyContainer : IDisposable
    {
        private readonly TabPool tabPool = new();
        private readonly MainMenuContainer container;

        private MainScreenView mainView;
        private BaseTabNode currentTab;

        public MainScreenProxyContainer(MainMenuContainer container)
        {
            this.container = container;
        }

        public MainScreenView InitMainScreen()
        {
            if (mainView == null) mainView = Object.Instantiate(container.MainScreenPrefab);
            return mainView;
        }

        public TTab GetTab<TTab>() where TTab : BaseTabNode
        {
            if (tabPool.TryGetTab<TTab>(out var tab))
            {
                return tab as TTab;
            }

            var tabPrefab = container.GetTabPrefab<TTab>();
            var newTab = Object.Instantiate(tabPrefab, mainView.Root);
            tabPool.AddNew(newTab);

            return newTab;
        }

        public GamesTabContainer GetGamesData()
        {
            return container.GamesTabContainer;
        }

        private void ReleaseCurrentTab()
        {
            if (currentTab == null) return;
            currentTab.Dispose();
            currentTab = null;
        }

        public void Dispose()
        {
            ReleaseCurrentTab();
            tabPool.Dispose();
        }
    }
}