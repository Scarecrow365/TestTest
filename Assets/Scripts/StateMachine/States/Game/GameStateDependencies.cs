using _clone.Scripts.Data.Game;
using _clone.Scripts.Services;
using _clone.Scripts.Services.LogService;
using _clone.Scripts.Services.SceneLoader;

namespace _clone.Scripts.StateMachine.States.Game
{
    public class GameStateDependencies
    {
        public ILogService LogService { get; private set; }
        public SceneLoader SceneLoader { get; private set; }
        public GamesContainer Container { get; private set; }

        public GameStateDependencies()
        {
            AddLogService();
            AddSceneLoader();
            AddDataContainer();
        }

        private void AddLogService() => LogService = ServiceLocator.Container.Single<ILogService>();
        private void AddSceneLoader() => SceneLoader = ServiceLocator.Container.Single<SceneLoader>();
        private void AddDataContainer() => Container = Data.Data.Container.Single<GamesContainer>();
    }
}