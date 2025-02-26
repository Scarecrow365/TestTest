using System;
using _clone.Scripts.Constants.Onboarding;
using _clone.Scripts.Core.Onboarding.Authentication;
using UnityEngine;

namespace _clone.Scripts.Core.Onboarding.Welcome
{
    public class WelcomeStepView : OnboardingStepView
    {
        [SerializeField] private AuthenticationView signInScreen;
        [SerializeField] private WelcomeScreenView welcomeScreen;
        [SerializeField] private GetStartedScreenView getStartedScreenView;

        public override string Id => OnboardingStepsName.WelcomeViewStep;

        private event Action onSignIn;
        private event Action onStepComplete;

        public void Init(Action onSignIn, Action onStepComplete)
        {
            this.onSignIn = onSignIn;
            this.onStepComplete = onStepComplete;
        }

        public override void Run()
        {
            gameObject.SetActive(true);
            getStartedScreenView.gameObject.SetActive(false);
            getStartedScreenView.Show(OnGetStarted, OnAlreadyMember);
        }

        private void OnGetStarted()
        {
            getStartedScreenView.Hide();
            welcomeScreen.Show(Complete, Complete, OnWelcomeSignIn);
        }

        private void OnAlreadyMember()
        {
            getStartedScreenView.Hide();
            signInScreen.Show(OnCompleteSignIn, FromSignInToGetStarted);
        }

        private void FromSignInToGetStarted()
        {
            signInScreen.Hide();
            getStartedScreenView.Show(OnGetStarted, OnAlreadyMember);
        }

        private void OnWelcomeSignIn()
        {
            welcomeScreen.Hide();
            signInScreen.Show(OnCompleteSignIn, FromSignInToWelcomeScreen);
        }

        private void FromSignInToWelcomeScreen()
        {
            signInScreen.Hide();
            welcomeScreen.Show(Complete, Complete, OnWelcomeSignIn);
        }

        private void OnCompleteSignIn()
        {
            onSignIn?.Invoke();
            Complete();
        }

        protected override void Complete()
        {
            onStepComplete?.Invoke();
        }

        public override void Dispose()
        {
            gameObject.SetActive(false);
            base.Dispose();
            Destroy(gameObject);
        }
    }
}