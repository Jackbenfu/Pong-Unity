using Pong.Player;
using Pong.StateMachine;
using Pong.TwoPlayerMode.State.GameOver;
using Pong.TwoPlayerMode.State.Rally;
using Pong.TwoPlayerMode.State.Service;
using UnityEngine;
using UnityEngine.UI;

namespace Pong.TwoPlayerMode
{
    public class TwoPlayerStateMachineScript : StateMachineScript<TwoPlayerStateMachineScript>
    {
        #region Inspector

        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private GameObject ball;

        [SerializeField]
        private GameObject leftPaddle;
        [SerializeField]
        private PlayerScoreScript leftScore;
        [SerializeField]
        private PlayerScoreScript leftScoreMax;

        [SerializeField]
        private GameObject rightPaddle;
        [SerializeField]
        private PlayerScoreScript rightScore;
        [SerializeField]
        private PlayerScoreScript rightScoreMax;

        [SerializeField]
        private GameObject gameOver;
        [SerializeField]
        private PlayerResultScript leftResult;
        [SerializeField]
        private PlayerResultScript rightResult;

        [SerializeField]
        private GameObject instruction;
        [SerializeField]
        private Text goal;

        [SerializeField]
        [Range(1, 9)]
        private int winScore;

        #endregion

        #region StateMachineScript

        protected override void LoadStates()
        {
            AddServiceState();
            AddRallyState();
            AddGameOverState();
        }

        private void AddServiceState()
        {
            var context = new ServiceState2PContext
            {
                Ball = ball,
                LeftPaddle = leftPaddle,
                LeftScoreMax = leftScoreMax,
                RightPaddle = rightPaddle,
                RightScoreMax = rightScoreMax,
                Instruction = instruction,
                Goal = goal,
                WinScore = winScore
            };

            AddState<ServiceState2P, ServiceState2PContext>(context);
        }

        private void AddRallyState()
        {
            var context = new RallyState2PContext
            {
                Canvas = canvas,
                Ball = ball,
                LeftPaddle = leftPaddle,
                LeftScore = leftScore,
                RightPaddle = rightPaddle,
                RightScore = rightScore,
                WinScore = winScore
            };

            AddState<RallyState2P, RallyState2PContext>(context);
        }

        private void AddGameOverState()
        {
            var context = new GameOverState2PContext
            {
                GameOver = gameOver,
                LeftScore = leftScore,
                LeftResult = leftResult,
                RightScore = rightScore,
                RightResult = rightResult
            };

            AddState<GameOverState2P, GameOverState2PContext>(context);
        }

        #endregion
    }
}
