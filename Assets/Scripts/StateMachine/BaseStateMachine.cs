using System;
using _clone.Scripts.Services;
using _clone.Scripts.Services.LogService;
using UnityEngine;

namespace _clone.Scripts.StateMachine
{
    public abstract class BaseStateMachine : IDisposable
    {
        public abstract void Start();

        public virtual void Dispose()
        {
        }

        protected virtual BaseState InitStartState()
        {
            return default;
        }

        protected virtual void ChangeState(BaseState state)
        {
            if (state == null)
            {
                var logService = ServiceLocator.Container.Single<ILogService>();
                logService ??= new LogService();
                
                logService.LogError("Cannot open state. State is null");
                Application.Quit();
            }

            if (state is ExitState)
            {
                Application.Quit();
            }
        }
    }
}