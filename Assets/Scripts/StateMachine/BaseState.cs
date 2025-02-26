using System;
using _clone.Scripts.Services.LogService;

namespace _clone.Scripts.StateMachine
{
    public abstract class BaseState : IDisposable
    {
        protected ILogService logService;

        public event Action<BaseState> OnComplete;

        private BaseState nextState;

        protected virtual string StateTag => "State";

        public virtual void Enter()
        {
            SetDependencies();
            logService.Log($"<color=#FF9700>{StateTag} -></color> Start {GetType().Name}");
        }

        protected void SetNextState(BaseState nextState) => this.nextState = nextState;

        protected virtual void SetDependencies() => logService = new LogService();

        protected virtual void Exit()
        {
            logService.Log($"<color=#FF9700>{StateTag} <-</color> Exit {GetType().Name}");
            OnComplete?.Invoke(nextState);
        }

        public virtual void Dispose()
        {
        }
    }
}