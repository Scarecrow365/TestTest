using System;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Onboarding.Questionnaire
{
    public class QuestionnaireElement : MonoBehaviour
    {
        [SerializeField] private Button backButton;
        [SerializeField] private Button skipButton;
        [SerializeField] private Button yesButton;
        [SerializeField] private Button noButton;

        [SerializeField] private float onAnswerButtonClickedDelay = 0.5f;

        public void Set(bool useBack)
        {
            backButton.gameObject.SetActive(useBack);
        }

        public void SetCallbacks(QuestionnaryScreenCallbacks callbacks)
        {
            SetBackButtonCallback(callbacks.BackButtonCallback);
            SetSkipButtonCallback(callbacks.SkipButtonCallback);
            SetNoButtonCallback(callbacks.NoButtonCallback);
            SetYesButtonCallback(callbacks.YesButtonCallback);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void SetInteractableState(bool state)
        {
            backButton.interactable = state;
            skipButton.interactable = state;
            yesButton.enabled = state;
            noButton.enabled = state;
        }

        private void SetBackButtonCallback(Action callback) => 
            backButton.onClick.AddListener(() => callback?.Invoke());
        private void SetSkipButtonCallback(Action callback) => 
            skipButton.onClick.AddListener(() => callback?.Invoke());
        private void SetNoButtonCallback(Action callback) =>
            noButton.onClick.AddListener(() => OnAnswerButtonClicked(callback, noButton));
        private void SetYesButtonCallback(Action callback) =>
            yesButton.onClick.AddListener(() => OnAnswerButtonClicked(callback, yesButton));

        private void OnAnswerButtonClicked(Action callback, Button clickedButton)
        {
            var normalButtonColor = clickedButton.targetGraphic.color;

            clickedButton.targetGraphic.color = normalButtonColor * clickedButton.colors.selectedColor;
            SetInteractableState(false);

            callback?.Invoke();
        }

        private void ClearButtonsCallbacks()
        {
            backButton.onClick.RemoveAllListeners();
            skipButton.onClick.RemoveAllListeners();
            yesButton.onClick.RemoveAllListeners();
            noButton.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            ClearButtonsCallbacks();
        }
    }
}