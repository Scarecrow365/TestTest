using System;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Onboarding.Welcome
{
    public class GetStartedScreenView : MonoBehaviour
    {
        [SerializeField] private Button getStartedButton;
        [SerializeField] private Button alreadyMemberButton;

        private event Action OnGetStarted;
        private event Action OnAlreadyMember;

        private void Awake()
        {
            SubscribeButtons();
        }

        private void OnDestroy()
        {
            ClearCallbacks();
        }

        public void Show(Action onGetStarted, Action onAlreadyMember)
        {
            gameObject.SetActive(true);
            UnlockInput();
            SetCallbacks(onGetStarted, onAlreadyMember);
            GetStartedHandler();
        }

        public void Hide()
        {
            LockInput();
            ClearCallbacks();
            gameObject.SetActive(false);
        }

        private void LockInput()
        {
            getStartedButton.enabled = false;
            alreadyMemberButton.enabled = false;
        }

        private void UnlockInput()
        {
            getStartedButton.enabled = true;
            alreadyMemberButton.enabled = true;
        }

        private void SubscribeButtons()
        {
            getStartedButton.onClick.AddListener(GetStartedHandler);
            alreadyMemberButton.onClick.AddListener(AlreadyMemberHandler);
        }

        private void GetStartedHandler()
        {
            OnGetStarted?.Invoke();
        }

        private void AlreadyMemberHandler()
        {
            OnAlreadyMember?.Invoke();
        }

        private void SetCallbacks(Action onGetStarted, Action onAlreadyMember)
        {
            OnGetStarted = onGetStarted;
            OnAlreadyMember = onAlreadyMember;
        }

        private void ClearCallbacks()
        {
            OnGetStarted = null;
            OnAlreadyMember = null;
        }
    }
}