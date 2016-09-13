using System;
using Pong.Ball;
using Pong.Constants;
using Pong.OnePlayerMode.State.Rally;
using Pong.Player;
using Pong.StateMachine;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pong.OnePlayerMode.State.Service
{
    public class ServiceState1P : StateWithContext<OnePlayerStateMachineScript, ServiceState1PContext>
    {
        #region Private

        private Rigidbody2D ballBody;
        private BallScript _ballScript;

        private PlayerScoreScript highScore;

        #endregion

        #region State

        public override void Init()
        {
            Random.InitState((int)DateTime.UtcNow.Ticks);

            ballBody = Context.Ball.GetComponent<Rigidbody2D>();
            _ballScript = Context.Ball.GetComponent<BallScript>();

            highScore = Context.HighScore;
        }

        public override void Enter(object param)
        {
            highScore.SetScore(
                PlayerPrefs.GetInt(Const.PLAYER_PREFS_1PLAYER_HIGH_SCORE)
            );
        }

        public override void Exit()
        {
            // Nothing
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }

        #endregion

        #region Utils

        private void LaunchBall()
        {
            var impulse = new Vector2();
            impulse.x = 1f;
            impulse.y = 0 == Random.Range(0, 2) ? -1f : 1f;
            impulse.Normalize();

            var ballSpeed = _ballScript.GetSpeed();
            var speed = new Vector2(ballSpeed, ballSpeed);
            impulse.Scale(speed);

            ballBody.AddForce(impulse, ForceMode2D.Impulse);

            Context.Instruction.SetActive(false);

            StateMachine.GoToState<RallyState1P>();
        }

        #endregion
    }
}
