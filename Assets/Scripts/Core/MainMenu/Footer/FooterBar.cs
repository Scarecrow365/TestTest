using UnityEngine;

namespace _clone.Scripts.Core.MainMenu.Footer
{
    public class FooterBar : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Footer elements")] 
        [SerializeField] private FooterElement mainButton;
        [SerializeField] private FooterElement activitiesButton;
        [SerializeField] private FooterElement gamesButton;
        [SerializeField] private FooterElement statsButton;
        [SerializeField] private FooterElement profileButton;

        private FooterCallbacks callbacks;

        private void Start()
        {
            mainButton.Init();
            gamesButton.Init();
            statsButton.Init();
            profileButton.Init();
            activitiesButton.Init();

            Subscribe();
            mainButton.Press();
        }

        public void SetCallbacks(FooterCallbacks footerCallbacks)
        {
            callbacks = footerCallbacks;
        }

        public void Show()
        {
            canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            canvasGroup.alpha = 0;
        }

        private void Subscribe()
        {
            mainButton.SetCallback(OnMainButtonPressed);
            gamesButton.SetCallback(OnGamesButtonPressed);
            statsButton.SetCallback(OnStatsButtonPressed);
            profileButton.SetCallback(OnProfileButtonPressed);
            activitiesButton.SetCallback(OnActivitiesButtonPressed);
        }

        private void OnMainButtonPressed(bool isOn)
        {
            if (isOn) callbacks.FireMain();
        }

        private void OnActivitiesButtonPressed(bool isOn)
        {
            if (isOn) callbacks.FireActivity();
        }

        private void OnGamesButtonPressed(bool isOn)
        {
            if (isOn) callbacks.FireGames();
        }

        private void OnStatsButtonPressed(bool isOn)
        {
            if (isOn) callbacks.FireStats();
        }

        private void OnProfileButtonPressed(bool isOn)
        {
            if (isOn) callbacks.FireProfile();
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}