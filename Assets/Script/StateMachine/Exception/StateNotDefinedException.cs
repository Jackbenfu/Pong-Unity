using Pong.Exception;

namespace Pong.StateMachine.Exception
{
    public class StateNotDefinedException : StopExecutionException
    {
        public StateNotDefinedException(string stateName)
            : base(string.Format("State of type {0} does not exist in the state machine.", stateName))
        {
        }
    }
}
