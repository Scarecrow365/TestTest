using UnityEngine;
using UnityEngine.UI;

namespace _clone.Scripts.Core.Onboarding.Authentication
{
    public class ForgotPasswordView : MonoBehaviour
    {
        private const string MessageOffline = "You appear to be offline,\n please check your network connection";

        [SerializeField] private Image background;

        [Header("Recover Screen")] [SerializeField]
        private Text errorText;

        [SerializeField] private Button cancelButton;
        [SerializeField] private Button recoverButton;
        [SerializeField] private InputField emailField;
        [SerializeField] private GameObject recoverScreen;

        [Header("After Recover Screen")] [SerializeField]
        private GameObject afterCorrectRecoverScreen;

        [SerializeField] private Button closeButtonAfterRecoverScreen;

        private string email;

        private void Start()
        {
            emailField.text = string.Empty;

            cancelButton.onClick.AddListener(CloseWindow);
            emailField.onValueChanged.AddListener(CheckEmail);
            recoverButton.onClick.AddListener(ActivateRecover);
            closeButtonAfterRecoverScreen.onClick.AddListener(CloseWindow);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            background.color = new Color(1, 1, 1, 0);
            //background.DOFade(.3f, .25f).OnComplete(() => recoverScreen.SetActive(true));
        }

        private async void ActivateRecover()
        {
            ShowAfterCorrectRecoverScreen();

            // if (await NetworkManager.Instance.ActivateRecoverPasswordRequest(email))
            // {
            //     ShowAfterCorrectRecoverScreen();
            // }
            // else
            // {
            //     bool hasInternet = Application.internetReachability != NetworkReachability.NotReachable;
            //     string error = hasInternet ? "Email not Found." : MessageOffline;
            //     ActivateErrorMessage(error);
            // }
        }

        private void CheckEmail(string content)
        {
            try
            {
                email = new System.Net.Mail.MailAddress(content).Address;
                DeactivateErrorMessage();
            }
            catch
            {
                ActivateErrorMessage("incorrect Email");
            }
        }

        private void ActivateErrorMessage(string message)
        {
            errorText.text = message;
            errorText.gameObject.SetActive(true);
        }

        private void CloseWindow()
        {
            gameObject.SetActive(false);
        }

        private void DeactivateErrorMessage()
        {
            errorText.gameObject.SetActive(false);
        }

        private void ShowAfterCorrectRecoverScreen()
        {
            afterCorrectRecoverScreen.SetActive(true);
        }
    }
}