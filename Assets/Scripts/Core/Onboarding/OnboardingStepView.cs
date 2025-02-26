using System;
using UnityEngine;

namespace _clone.Scripts.Core.Onboarding
{
    public abstract class OnboardingStepView : MonoBehaviour, IDisposable
    {
        public abstract string Id { get; }
        
        public abstract void Run();
        protected abstract void Complete();

        public virtual void Dispose()
        {
        }
    }
}