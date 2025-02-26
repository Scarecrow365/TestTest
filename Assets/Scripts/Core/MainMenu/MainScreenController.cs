using System;
using _clone.Scripts.Core.MainMenu.Footer;
using _clone.Scripts.Core.MainMenu.Tabs;
using _clone.Scripts.Core.MainMenu.Tabs.ActivityTab;
using _clone.Scripts.Core.MainMenu.Tabs.GamesTab;
using _clone.Scripts.Core.MainMenu.Tabs.MainTab;
using _clone.Scripts.Core.MainMenu.Tabs.ProfileTab;
using _clone.Scripts.Core.MainMenu.Tabs.StatsTab;
using _clone.Scripts.Data.MainMenu;
using _clone.Scripts.StateMachine.States.MainMenu;

namespace _clone.Scripts.Core.MainMenu
{
    public class MainScreenController
    {
        private readonly MainMenuStateDependencies dependencies;

        private Action onSignIn;
        private Action<string> onGamePressed;

        private MainScreenView view;
        private MainScreenProxyContainer container;
        private TabsControllersFactory tabsFactory;
        private ITabController currentTabController;

        public MainScreenController(MainMenuStateDependencies dependencies)
        {
            this.dependencies = dependencies;

            Init();
        }

        public void SetCallback(Action onSignIn, Action<string> onGamePressed)
        {
            this.onSignIn = onSignIn;
            this.onGamePressed = onGamePressed;
        }

        public void Run()
        {
            view.Run();
        }

        private void Init()
        {
            container = new MainScreenProxyContainer(dependencies.DataContainer);
            tabsFactory = new TabsControllersFactory(container);

            InitMainView();
        }

        private void InitMainView()
        {
            view = container.InitMainScreen();
            if (view == null) throw new NullReferenceException("Please, set main screen prefab");

            InitMainViewCallback();
        }

        private void InitMainViewCallback()
        {
            ChangeTab<MainTabController>();

            FooterCallbacks footerCallbacks = new();
            footerCallbacks.Main += ChangeTab<MainTabController>;
            footerCallbacks.Games += ChangeTab<GamesTabController>;
            footerCallbacks.Stats += ChangeTab<StatsTabController>;
            footerCallbacks.Profile += ChangeTab<ProfileTabController>;
            footerCallbacks.Activity += ChangeTab<ActivityTabController>;
            view.SetCallbacks(footerCallbacks);
        }

        private void ChangeTab<TTab>() where TTab : ITabController
        {
            currentTabController?.Disable();
            currentTabController = tabsFactory.GetController<TTab>();
            currentTabController.Enable();
            
            SetUpGameLaunchScreen();
        }

        private void SetUpGameLaunchScreen()
        {
            if (currentTabController is IGameLaunchController tab)
                tab.SetCallback(OnGamePressed);
        }

        private void OnGamePressed(string gameId)
        {
            dependencies.LogService.Log(gameId);
            onGamePressed?.Invoke(gameId);
        }

        private void CompleteSignIn()
        {
            onSignIn?.Invoke();
        }

        public void Dispose()
        {
            container.Dispose();
            view.Dispose();
            view = null;
        }
    }
}