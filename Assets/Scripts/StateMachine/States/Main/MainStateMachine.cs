namespace _clone.Scripts.StateMachine.States.Main
{
    public class MainStateMachine : BaseStateMachine
    {
        private BaseState currentState;

        public override void Start()
        {
            currentState = InitStartState();
            ChangeState(currentState);
        }

        protected override BaseState InitStartState()
        {
            return new StartState();
        }

        protected override void ChangeState(BaseState state)
        {
            currentState.OnComplete -= ChangeState;
            currentState.Dispose();
            
            base.ChangeState(state);
            
            currentState = state;
            currentState.OnComplete += ChangeState;

            currentState.Enter();
        }
    }
}