namespace Pong.StateMachine
{
    public abstract class StateWithContext<TStateMachine, TStateContext> : State<TStateMachine>
        where TStateMachine : StateMachineScript<TStateMachine>
    {
        public TStateContext Context { get; set; }
    }
}
