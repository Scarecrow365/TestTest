using System;
using System.Collections.Generic;
using System.Linq;
using _clone.Scripts.Core.MainMenu.Tabs;
using _clone.Scripts.Core.MainMenu.Tabs.ActivityTab;
using _clone.Scripts.Core.MainMenu.Tabs.GamesTab;
using _clone.Scripts.Core.MainMenu.Tabs.MainTab;
using _clone.Scripts.Core.MainMenu.Tabs.ProfileTab;
using _clone.Scripts.Core.MainMenu.Tabs.StatsTab;
using _clone.Scripts.Data.MainMenu;

namespace _clone.Scripts.Core.MainMenu
{
    public class TabsControllersFactory
    {
        private readonly List<ITabController> poolControllers = new();
        private Dictionary<Type, Func<ITabController>> controllerFactory = new();

        public TabsControllersFactory(MainScreenProxyContainer container)
        {
            FillFactory(container);
        }

        public ITabController GetController<TTab>() where TTab : ITabController
        {
            if (TryGetFromPool<TTab>(out var poolController)) return poolController;
            if (TryCreateNewController<TTab>(out var newController)) return newController;

            throw new InvalidOperationException($"Controller for type {typeof(TTab)} not found.");
        }

        private void FillFactory(MainScreenProxyContainer container)
        {
            controllerFactory = new Dictionary<Type, Func<ITabController>>
            {
                {typeof(MainTabController), () => new MainTabController(container.GetTab<MainTabNode>())},
                {typeof(GamesTabController), () => new GamesTabController(container.GetTab<GamesTabNode>(), container.GetGamesData())},
                {typeof(StatsTabController), () => new StatsTabController(container.GetTab<StatsTabNode>())},
                {typeof(ProfileTabController), () => new ProfileTabController(container.GetTab<ProfileTabNode>())},
                {typeof(ActivityTabController), () => new ActivityTabController(container.GetTab<ActivityTabNode>())}
            };
        }

        private bool TryCreateNewController<TTab>(out ITabController resultController) where TTab : ITabController
        {
            if (controllerFactory.TryGetValue(typeof(TTab), out var createController))
            {
                var newController = createController();
                poolControllers.Add(newController);
                resultController = newController;
                return true;
            }

            resultController = null;
            return false;
        }

        private bool TryGetFromPool<TTab>(out ITabController resultController) where TTab : ITabController
        {
            foreach (var poolController in poolControllers.OfType<TTab>())
            {
                resultController = poolController;
                return true;
            }

            resultController = null;
            return false;
        }
    }
}