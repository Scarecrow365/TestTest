using _clone.Scripts.Data.Game;
using _clone.Scripts.Data.Loader;
using _clone.Scripts.Data.MainMenu;
using _clone.Scripts.Data.Onboarding;
using _clone.Scripts.Data.User.Cheats;
using _clone.Scripts.Data.User.Location;
using _clone.Scripts.Data.User.OnBoarding;
using _clone.Scripts.Data.User.Personal;
using _clone.Scripts.Data.User.Reminder;
using _clone.Scripts.Data.User.Settings;
using _clone.Scripts.Data.User.Subscription;
using _clone.Scripts.Services.LogService;
using UnityEngine;

namespace _clone.Scripts.Data
{
    public class Data : MonoBehaviour
    {
        [SerializeField] private GamesContainer gamesContainer;
        [SerializeField] private LoaderContainer loaderContainer;
        [SerializeField] private MainMenuContainer mainMenuContainer;
        [SerializeField] private OnboardingContainer onboardingContainer;

        public static Data Container;

        private ILogService logService;

        public void Init()
        {
            Container ??= this;
            if (Container != this)
                Destroy(this);

            Register();

            logService = new LogService();
        }

        private void Register()
        {
            RegisterSingle(gamesContainer);
            RegisterSingle(loaderContainer);
            RegisterSingle(mainMenuContainer);
            RegisterSingle(onboardingContainer);

            RegisterSingle(new CheatData());
            RegisterSingle(new PersonData());
            RegisterSingle(new LocationData());
            RegisterSingle(new ReminderData());
            RegisterSingle(new SettingsData());
            RegisterSingle(new OnBoardingData());
            RegisterSingle(new SubscriptionData());
        }

        public TData Single<TData>() where TData : IData
        {
            var result = Implementation<TData>.ServiceInstance;

            if (result == null)
            {
                logService.LogError($"Not found data {typeof(TData)}, probably not register");
            }
            
            return result;
        }

        private static void RegisterSingle<TData>(TData implementation) where TData : IData
        {
            Implementation<TData>.ServiceInstance = implementation;
        }

        private static class Implementation<TData> where TData : IData
        {
            public static TData ServiceInstance;
        }
    }
}