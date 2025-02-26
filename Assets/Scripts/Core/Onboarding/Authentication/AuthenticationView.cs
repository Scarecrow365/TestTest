using System;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Onboarding.Authentication
{
    public class AuthenticationView : MonoBehaviour
    {
        [SerializeField] private Button appleButton;
        [SerializeField] private Button googleButton;
        [SerializeField] private Button facebookButton;

        [SerializeField] private Button forgotPasswordButton;

        [SerializeField] private EmailAuthView emailSignUpView;

        // [SerializeField] private SignInWithAppleWrapper appleWrapper;
        [SerializeField] private ForgotPasswordView forgotPasswordView;

        // public SignInWithAppleWrapper AppleWrapper => appleWrapper;

        public event Action OnBack;
        public event Action OnSignIn;

        private void Awake()
        {
            emailSignUpView.Set(true);
            appleButton.gameObject.SetActive(IsIos());
            Subscribe();
        }

        private void Start()
        {
            // SignInManager.SetUpIosWrapper(AppleWrapper);
        }

        private void OnDestroy()
        {
            ClearCallbacks();
            ClearButtonsCallbacks();
        }

        public void Show(Action onComplete, Action onBack)
        {
            gameObject.SetActive(true);
            SetCallbacks(onComplete, onBack);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            ClearCallbacks();
        }

        private void Subscribe()
        {
            appleButton.onClick.AddListener(AppleButtonClick);
            googleButton.onClick.AddListener(GoogleButtonClick);
            facebookButton.onClick.AddListener(FacebookButtonClick);
            forgotPasswordButton.onClick.AddListener(OpenForgotPasswordWindow);

            emailSignUpView.OnBackButtonPressed += OnBackButtonPressed;
        }

        private void ClearButtonsCallbacks()
        {
            appleButton.onClick.RemoveAllListeners();
            googleButton.onClick.RemoveAllListeners();
            facebookButton.onClick.RemoveAllListeners();

            emailSignUpView.OnBackButtonPressed -= OnBackButtonPressed;
        }

        private void AppleButtonClick()
        {
            OnAppleSignIn();
        }

        private void GoogleButtonClick()
        {
            OnGoogleSignIn();
        }

        private void FacebookButtonClick()
        {
            OnFacebookSignIn();
        }

        private void OnBackButtonPressed()
        {
            OnBack?.Invoke();
        }

        private void OpenForgotPasswordWindow()
        {
            forgotPasswordView.Show();
        }

        private async void OnAppleSignIn()
        {
            OnLoginSuccess();
            // ShowLoader();
            // bool isSuccess = await SignInManager.SignIn(Socials.Apple);
            // HideLoader();
            //if (isSuccess) OnLoginSuccess();
        }

        private async void OnGoogleSignIn()
        {
            OnLoginSuccess();
            // ShowLoader();
            // bool isSuccess = await SignInManager.SignIn(Socials.Google);
            // HideLoader();
            //if (isSuccess) OnLoginSuccess();
        }

        private async void OnFacebookSignIn()
        {
            OnLoginSuccess();
            // ShowLoader();
            // bool isSuccess = await SignInManager.SignIn(Socials.Facebook);
            // HideLoader();
            //if (isSuccess) OnLoginSuccess();
        }

        private async void OnLoginSuccess()
        {
            //Artificial delay for loading managers
            // ShowLoader();
            // await UniTask.Delay(3000);
            OnSignIn?.Invoke();
        }

        // private static void ShowLoader() => NetworkManager.Instance.ActivateNetworkView();
        // private static void HideLoader() => NetworkManager.Instance.DeactivateNetworkView();

        private void SetCallbacks(Action onComplete, Action onBack)
        {
            OnSignIn = onComplete;
            OnBack = onBack;
        }

        private void ClearCallbacks()
        {
            OnSignIn = null;
            OnBack = null;
        }

        private static bool IsIos()
        {
#if UNITY_IOS
            return true;
#endif
            return false;
        }
    }
}