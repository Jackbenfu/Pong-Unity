using Pong.Exception;

namespace Pong.StateMachine.Exception
{
    public class NoStateDefinedException : StopExecutionException
    {
        public NoStateDefinedException()
            : base("No state was defined in the state machine. State machine must have at least one state.")
        {
        }
    }
}
