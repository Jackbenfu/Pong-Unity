using Pong.Ball;
using Pong.Player;
using Pong.StateMachine;
using Pong.TwoPlayerMode.State.GameOver;
using Pong.TwoPlayerMode.State.Service;
using UnityEngine;

namespace Pong.TwoPlayerMode.State.Rally
{
    public class RallyState2P : StateWithContext<TwoPlayerStateMachineScript, RallyState2PContext>
    {
        #region Private properties

        private RectTransform ballTransform;
        private BallScript ballScript;

        private GameObject leftPaddle;
        private RectTransform leftPaddleTransform;
        private PlayerScoreScript leftScoreScript;

        private GameObject rightPaddle;
        private RectTransform rightPaddleTransform;
        private PlayerScoreScript rightScoreScript;

        private const float ballExitOffset = 40f;

        #endregion

        #region State

        public override void Init()
        {
            ballTransform = Context.Ball.GetComponent<RectTransform>();
            ballScript = Context.Ball.GetComponent<BallScript>();

            leftPaddle = Context.LeftPaddle;
            leftPaddleTransform = leftPaddle.GetComponent<RectTransform>();
            leftScoreScript = Context.LeftScore.GetComponent<PlayerScoreScript>();

            rightPaddle = Context.RightPaddle;
            rightPaddleTransform = rightPaddle.GetComponent<RectTransform>();
            rightScoreScript = Context.RightScore.GetComponent<PlayerScoreScript>();
        }

        public override void Enter(object param)
        {
            // Nothing
        }

        public override void Exit()
        {
            // Nothing
        }

        public override void Update(float deltaTime)
        {
            var needToRestartRally = false;
            GameObject servingPaddle = null;

            if (ballTransform.position.x < leftPaddleTransform.position.x - ballExitOffset)
            {
                rightScoreScript.IncrementScore();
                servingPaddle = rightPaddle;
                needToRestartRally = true;
            }
            else if (ballTransform.position.x > rightPaddleTransform.position.x + ballExitOffset)
            {
                leftScoreScript.IncrementScore();
                servingPaddle = leftPaddle;
                needToRestartRally = true;
            }

            if (Context.WinScore == leftScoreScript.GetScore() ||
                Context.WinScore == rightScoreScript.GetScore())
            {
                StateMachine.GoToState<GameOverState2P>();
                return;
            }

            if (needToRestartRally)
            {
                ballScript.ResetSpeed();

                StateMachine.GoToState<ServiceState2P>(servingPaddle);
            }
        }

        #endregion
    }
}
