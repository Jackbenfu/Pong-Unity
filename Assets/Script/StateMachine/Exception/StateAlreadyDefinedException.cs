using Pong.Exception;

namespace Pong.StateMachine.Exception
{
    public class StateAlreadyDefinedException : StopExecutionException
    {
        public StateAlreadyDefinedException(string stateName)
            : base(string.Format("State of type {0} already exists in the state machine.", stateName))
        {
        }
    }
}
