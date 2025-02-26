using System;

namespace _clone.Scripts.Core.Onboarding
{
    public abstract class OnboardingStepController : IDisposable
    {
        public abstract void Run();

        public virtual void Dispose()
        {
        }
    }
}