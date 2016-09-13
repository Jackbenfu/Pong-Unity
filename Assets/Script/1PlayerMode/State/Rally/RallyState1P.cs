using Pong.OnePlayerMode.State.GameOver;
using Pong.StateMachine;
using UnityEngine;

namespace Pong.OnePlayerMode.State.Rally
{
    public class RallyState1P : StateWithContext<OnePlayerStateMachineScript, RallyState1PContext>
    {
        #region Private

        private RectTransform ballTransform;
        private RectTransform paddleTransform;

        private const float ballExitOffset = 40f;

        #endregion

        public override void Init()
        {
            ballTransform = Context.Ball.GetComponent<RectTransform>();
            paddleTransform = Context.Paddle.GetComponent<RectTransform>();
        }

        public override void Enter(object param)
        {
            // Nothing
        }

        public override void Exit()
        {
            // Nothing
        }

        public override void Update()
        {
            if (ballTransform.position.x < paddleTransform.position.x - ballExitOffset)
            {
                StateMachine.GoToState<GameOver1PState>();
            }
        }
    }
}
