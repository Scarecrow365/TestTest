using System;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Onboarding.Authentication
{
    public class WelcomeScreenView : MonoBehaviour
    {
        [SerializeField] private ScrollRect scrollRect;

        //[SerializeField] private ScrollSnapOriginal scrollSnap;
        [SerializeField] private RectTransform scrollSecondPartStart;

        [SerializeField] private Button skipButton;
        [SerializeField] private Button nextButton;
        //[SerializeField] private Button finalButton;
        [SerializeField] private Button signInButton;

        [SerializeField] private WelcomeScreenAnimations animations;

        private bool isAtFirstScrollPart = true;

        private event Action onSkip;
        private event Action onSignIn;
        private event Action onComplete;

        private void Awake()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            skipButton.onClick.AddListener(OnSkip);
            signInButton.onClick.AddListener(OnSignIn);
            //finalButton.onClick.AddListener(OnComplete);
            nextButton.onClick.AddListener(NextButtonButtonHandler);
            scrollRect.onValueChanged.AddListener(_ => SwitchCommonElementsIfNeeded());
        }

        private void SwitchCommonElementsIfNeeded()
        {
            Vector3 position = GetComponent<RectTransform>().position;
            bool isSwitchingToSecondScrollPart = Mathf.Abs(scrollSecondPartStart.position.x - position.x) < position.x;

            if (!isSwitchingToSecondScrollPart && !isAtFirstScrollPart)
            {
                isAtFirstScrollPart = true;
                animations.ShowContainer(0);
                return;
            }

            if (isSwitchingToSecondScrollPart && isAtFirstScrollPart)
            {
                isAtFirstScrollPart = false;
                animations.ShowContainer(1);
            }
        }

        private void OnSkip()
        {
            onSkip?.Invoke();
        }

        private void OnSignIn()
        {
            onSignIn?.Invoke();
        }

        private void OnComplete()
        {
            onComplete?.Invoke();
        }

        private void NextButtonButtonHandler()
        {
            //scrollSnap.ChangePage(scrollSnap.CurrentPage() + 1);
        }

        public void Show(Action onSkip, Action onComplete, Action onSignIn)
        {
            gameObject.SetActive(true);
            SetCallbacks(onSkip, onComplete, onSignIn);
        }

        public void Hide()
        {
            ClearCallbacks();
            gameObject.SetActive(false);
        }

        private void SetCallbacks(Action onSkip, Action onComplete, Action onSignIn)
        {
            this.onSkip = onSkip;
            this.onComplete = onComplete;
            this.onSignIn = onSignIn;
        }

        private void ClearCallbacks()
        {
            onSkip = null;
            onComplete = null;
            onSignIn = null;
        }

        private void OnDestroy()
        {
            ClearCallbacks();
        }
    }
}