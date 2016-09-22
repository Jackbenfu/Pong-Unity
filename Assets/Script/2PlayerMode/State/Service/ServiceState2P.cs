using System;
using Pong.Ball;
using Pong.StateMachine;
using Pong.TwoPlayerMode.State.Rally;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pong.TwoPlayerMode.State.Service
{
    public class ServiceState2P : StateWithContext<TwoPlayerStateMachineScript, ServiceState2PContext>
    {
        #region Private

        private Rigidbody2D ballBody;
        private RectTransform ballTransform;
        private BallScript ballScript;

        private GameObject leftPaddle;
        private RectTransform leftPaddleTransform;

        private GameObject rightPaddle;
        private RectTransform rightPaddleTransform;

        private GameObject servingPaddle;

        private const float ballStickOffset = 4f;

        #endregion

        #region State

        public override void Init()
        {
            Random.InitState((int)DateTime.UtcNow.Ticks);

            ballBody = Context.Ball.GetComponent<Rigidbody2D>();
            ballTransform = Context.Ball.GetComponent<RectTransform>();
            ballScript = Context.Ball.GetComponent<BallScript>();

            leftPaddle = Context.LeftPaddle;
            leftPaddleTransform = leftPaddle.GetComponent<RectTransform>();

            rightPaddle = Context.RightPaddle;
            rightPaddleTransform = rightPaddle.GetComponent<RectTransform>();

            Context.LeftScoreMax.SetScore(Context.WinScore);
            Context.RightScoreMax.SetScore(Context.WinScore);

            Context.Goal.text = string.Format(Context.Goal.text, Context.WinScore);

            if (0 == Random.Range(0, 2))
            {
                servingPaddle = leftPaddle;
            }
            else
            {
                servingPaddle = rightPaddle;
            }
        }

        public override void Enter(object param)
        {
            var servingPaddleParam = param as GameObject;
            if (null != servingPaddleParam)
            {
                servingPaddle = servingPaddleParam;
            }
        }

        public override void Exit()
        {
            // Nothing
        }

        public override void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
            else
            {
                StickBallToPaddle();
            }
        }

        #endregion

        #region Utils

        private void LaunchBall()
        {
            ballBody.isKinematic = false;

            var impulse = new Vector2();
            impulse.x = leftPaddle == servingPaddle ? 1f : -1f;
            impulse.y = 0 == Random.Range(0, 2) ? -1f : 1f;
            impulse.Normalize();

            var ballSpeed = ballScript.GetSpeed();
            var speed = new Vector2(ballSpeed, ballSpeed);
            impulse.Scale(speed);

            ballBody.AddForce(impulse, ForceMode2D.Impulse);

            Context.Instruction.SetActive(false);

            StateMachine.GoToState<RallyState2P>();
        }

        private void StickBallToPaddle()
        {
            ballBody.isKinematic = true;

            if (servingPaddle.GetInstanceID() == leftPaddle.GetInstanceID())
            {
                ballTransform.anchoredPosition = new Vector2(
                    leftPaddleTransform.offsetMax.x + ballTransform.sizeDelta.x - ballStickOffset,
                    leftPaddleTransform.offsetMax.y - leftPaddleTransform.sizeDelta.y / 2f
                );
            }
            else
            {
                ballTransform.anchoredPosition = new Vector2(
                    rightPaddleTransform.offsetMin.x - ballTransform.sizeDelta.x + ballStickOffset,
                    rightPaddleTransform.offsetMin.y + rightPaddleTransform.sizeDelta.y / 2f
                );
            }
        }

        #endregion
    }
}
