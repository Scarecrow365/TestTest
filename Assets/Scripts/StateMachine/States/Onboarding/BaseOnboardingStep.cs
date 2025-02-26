using System;
using _clone.Scripts.Core.Onboarding;

namespace _clone.Scripts.StateMachine.States.Onboarding
{
    public abstract class BaseOnboardingStep : BaseState
    {
        public abstract string Id { get; }
        protected override string StateTag => "Sub State";
        
        protected OnboardingStepController Controller;

        public event Action OnSignIn;
        public event Action OnFinishStep;

        public virtual void Prepare(OnboardingStepView viewPrefab)
        {
            Controller = null;
            logService.LogError($"{Id} step not found. ViewPrefab is null = {viewPrefab is null}");
        }

        protected void OnSignInComplete() => OnSignIn?.Invoke();
        protected void OnStepFinish() => OnFinishStep?.Invoke();
        
        protected static TView InitView<TView>(TView viewPrefab) where TView : OnboardingStepView
        {
            var view = UnityEngine.Object.Instantiate(viewPrefab);
            view.gameObject.SetActive(false);
            return view;
        }

        protected void Run()
        {
            if (Controller == null)
            {
                Exit();
                return;
            }
            
            Controller.Run();
        }
        
        protected void OnStepComplete()
        {
            Exit();
            OnStepFinish();
        }

        public void Clean()
        {
            if (Controller == null) return;
            Controller.Dispose();
            Controller = null;
        }

        public override void Dispose()
        {
            base.Dispose();
            Clean();
        }
    }
}