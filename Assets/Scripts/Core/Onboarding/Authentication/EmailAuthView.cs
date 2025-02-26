using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Onboarding.Authentication
{
    public class EmailAuthView : MonoBehaviour
    {
        private const string MessageError = "You already have an account or please check your network connection";

        [SerializeField] private Button backButton;
        [SerializeField] private TextMeshProUGUI errorText;
        [SerializeField] private Button createAccountButton;
        [Header("Email")] [SerializeField] private InputField emailInput;
        [SerializeField] private Image correctEmailInputSignal;
        [SerializeField] private Image incorrectEmailInputSignal;
        [Header("Password")] [SerializeField] private InputField passwordInput;
        [SerializeField] private Image passwordStatusImage;
        [SerializeField] private Sprite passwordHidePicture;
        [SerializeField] private Sprite passwordShowPicture;
        [SerializeField] private Button passwordStatusButton;
        [SerializeField] private GameObject passwordInputSignal;
        [SerializeField] private Image correctPasswordInputSignal;
        [SerializeField] private Image incorrectPasswordInputSignal;

        private string email;
        private string password;

        private bool isSignIn;
        private bool isCorrectEmail;
        private bool isPasswordHidden;
        private bool isCorrectPassword;

        public event Action OnSignInComplete;
        public event Action OnBackButtonPressed;

        private void Start()
        {
            Subscribe();
            CheckCreateAccountButton();
        }

        private void OnDisable()
        {
            ResetChanges();
        }

        public void Close()
        {
            OnBackButtonPressed?.Invoke();
            gameObject.SetActive(false);
        }

        public void Set(bool isSignIn)
        {
            this.isSignIn = isSignIn;
        }

        private void Subscribe()
        {
            backButton.onClick.AddListener(Close);
            emailInput.onEndEdit.AddListener(CheckCorrectEmail);
            passwordInput.onEndEdit.AddListener(CheckCorrectPassword);
            passwordStatusButton.onClick.AddListener(ShowHidePassword);
            createAccountButton.onClick.AddListener(OnCreateAccountPressed);
        }

        private async void OnCreateAccountPressed()
        {
            ShowLoader();
            bool isSuccess;
            // if (isSignIn) isSuccess = await SignInManager.SignInMail(email, password);
            // else isSuccess = await SignInManager.SignUpMail(email, password);

            HideLoader();

            // if (isSuccess) OnSignUp();
            // else OnSignUpFailed();
        }

        private void CheckCorrectPassword(string value)
        {
            errorText.gameObject.SetActive(false);

            bool passwordIsCorrect = value.Length >= 4;

            if (passwordIsCorrect) password = value;

            passwordInputSignal.SetActive(true);
            correctPasswordInputSignal.gameObject.SetActive(passwordIsCorrect);
            incorrectPasswordInputSignal.gameObject.SetActive(!passwordIsCorrect);
            isCorrectPassword = passwordIsCorrect;
            CheckCreateAccountButton();
        }

        private void CheckCorrectEmail(string value)
        {
            errorText.gameObject.SetActive(false);

            try
            {
                email = new System.Net.Mail.MailAddress(value).Address;
                isCorrectEmail = true;
                correctEmailInputSignal.gameObject.SetActive(true);
            }
            catch
            {
                isCorrectEmail = false;
            }

            incorrectEmailInputSignal.gameObject.SetActive(!isCorrectEmail);
            CheckCreateAccountButton();
        }

        private void ShowHidePassword()
        {
            passwordStatusImage.sprite = isPasswordHidden ? passwordShowPicture : passwordHidePicture;
            passwordInput.contentType =
                isPasswordHidden ? InputField.ContentType.Standard : InputField.ContentType.Password;
            passwordInput.ForceLabelUpdate();
            isPasswordHidden = !isPasswordHidden;
        }

        private void ResetChanges()
        {
            errorText.text = string.Empty;
            emailInput.text = string.Empty;
            passwordInput.text = string.Empty;

            passwordInputSignal.SetActive(false);
            errorText.gameObject.SetActive(false);
            correctEmailInputSignal.gameObject.SetActive(false);
            incorrectEmailInputSignal.gameObject.SetActive(false);
            correctPasswordInputSignal.gameObject.SetActive(false);
            incorrectPasswordInputSignal.gameObject.SetActive(false);

            isCorrectEmail = false;
            isPasswordHidden = false;
            isCorrectPassword = false;

            ShowHidePassword();
            CheckCreateAccountButton();
        }

        private void OnSignUp()
        {
            OnSignInComplete?.Invoke();
        }

        private void OnSignUpFailed()
        {
            errorText.text = MessageError;
            errorText.gameObject.SetActive(true);
        }

        private static void ShowLoader()
        {
            //NetworkManager.Instance.ActivateNetworkView();
        }

        private static void HideLoader()
        {
            //NetworkManager.Instance.DeactivateNetworkView();
        }

        private void CheckCreateAccountButton()
        {
            createAccountButton.interactable = isCorrectEmail && isCorrectPassword;
        }
    }
}