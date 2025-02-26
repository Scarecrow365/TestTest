using _clone.Scripts.Data.MainMenu;
using _clone.Scripts.Services;
using _clone.Scripts.Services.LogService;

namespace _clone.Scripts.StateMachine.States.MainMenu
{
    public class MainMenuStateDependencies
    {
        public ILogService LogService { get; private set; }
        public MainMenuContainer DataContainer { get; private set; }

        public MainMenuStateDependencies()
        {
            AddLogService();
            AddDataContainer();
        }

        private void AddLogService() => LogService = ServiceLocator.Container.Single<ILogService>();
        private void AddDataContainer() => DataContainer = Data.Data.Container.Single<MainMenuContainer>();
    }
}