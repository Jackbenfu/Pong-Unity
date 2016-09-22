namespace Pong.StateMachine
{
    public abstract class State<TStateMachine>
        where TStateMachine : StateMachineScript<TStateMachine>
    {
        public TStateMachine StateMachine { get; set; }

        public abstract void Init();

        public abstract void Enter(object param);

        public abstract void Exit();

        public abstract void Update(float deltaTime);
    }
}
