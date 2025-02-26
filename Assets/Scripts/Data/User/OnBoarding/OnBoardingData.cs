namespace _clone.Scripts.Data.User.OnBoarding
{
    public class OnBoardingData : IData
    {
        public bool IsCompleted { get; private set; }
        public string CurrentStep { get; private set; }

        public void Set(SerializeOnboardingData data)
        {
            IsCompleted = data.isCompleted;
            CurrentStep = data.currentStep;
        }

        public void Set(SerializeOnboardingStepData data)
        {
            CurrentStep = data.name;
        }
    }
}