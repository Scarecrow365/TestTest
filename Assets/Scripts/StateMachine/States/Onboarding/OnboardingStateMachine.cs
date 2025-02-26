using System;
using _clone.Scripts.Core.Onboarding;
using _clone.Scripts.Data.Onboarding;

namespace _clone.Scripts.StateMachine.States.Onboarding
{
    public class OnboardingStateMachine : BaseStateMachine
    {
        private readonly OnboardingContainer onboardingContainer;

        private BaseOnboardingStep currentOnboardingStep;

        private int currentStep;
        
        private event Action onExit;

        public OnboardingStateMachine(OnboardingContainer onboardingContainer)
        {
            this.onboardingContainer = onboardingContainer;
        }
        
        public override void Start()
        {
            SetNextOnboardingStep();
        }

        public void SetExitCallback(Action onExit)
        {
            this.onExit = onExit;
        }
        
        private void SetNextOnboardingStep()
        {
            var state = GetNextStep();
            if (state == null)
            {
                OnExit();
                return;
            }

            if (!onboardingContainer.TryGetStepViewPrefab(state.Id, out var viewPrefab))
            {
                OnExit();
                return;
            }

            Clean();
            PrepareNewStep(state, viewPrefab);
            currentOnboardingStep.Enter();

            currentStep++;
        }

        private BaseOnboardingStep GetNextStep()
        {
            var isStepsCountValid = onboardingContainer.StepsCount > 0;
            var isCurrentStepValid = currentStep <= onboardingContainer.StepsCount - 1;

            if (!isStepsCountValid || !isCurrentStepValid) return null;
            
            return onboardingContainer.GetOnboardingStep(currentStep);
        }
        
        private void PrepareNewStep(BaseOnboardingStep state, OnboardingStepView viewPrefab)
        {
            currentOnboardingStep = state;
            currentOnboardingStep.Prepare(viewPrefab);
            Subscribe();
        }

        private void Clean()
        {
            if (currentOnboardingStep == null) return;
            
            Unsubscribe();
            currentOnboardingStep.Clean();
        }

        private void OnSignIn()
        {
            OnExit();
        }

        private void OnExit()
        {
            onExit?.Invoke();
            Dispose();
        }
        
        private void Subscribe()
        {
            currentOnboardingStep.OnSignIn += OnSignIn;
            currentOnboardingStep.OnFinishStep += SetNextOnboardingStep;
        }
        
        private void Unsubscribe()
        {
            currentOnboardingStep.OnSignIn -= OnSignIn;
            currentOnboardingStep.OnFinishStep -= SetNextOnboardingStep;
        }

        public override void Dispose()
        {
            Clean();
            base.Dispose();
        }
    }
}