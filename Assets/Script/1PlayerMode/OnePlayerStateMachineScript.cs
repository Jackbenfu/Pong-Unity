using Pong.OnePlayerMode.State.GameOver;
using Pong.OnePlayerMode.State.Rally;
using Pong.OnePlayerMode.State.Service;
using Pong.Player;
using Pong.StateMachine;
using UnityEngine;

namespace Pong.OnePlayerMode
{
    public class OnePlayerStateMachineScript : StateMachineScript<OnePlayerStateMachineScript>
    {
        #region Inspector

        [SerializeField]
        private GameObject ball;

        [SerializeField]
        private GameObject paddle;

        [SerializeField]
        private GameObject gameOver;

        [SerializeField]
        private GameObject instruction;

        [SerializeField]
        private PlayerScoreScript highScore;

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
            var context = new ServiceState1PContext
            {
                Ball = ball,
                Instruction = instruction,
                HighScore = highScore
            };

            AddState<ServiceState1P, ServiceState1PContext>(context);
        }

        private void AddRallyState()
        {
            var context = new RallyState1PContext
            {
                Ball = ball,
                Paddle = paddle
            };

            AddState<RallyState1P, RallyState1PContext>(context);
        }

        private void AddGameOverState()
        {
            var context = new GameOver1PStateContext
            {
                GameOver = gameOver
            };

            AddState<GameOver1PState, GameOver1PStateContext>(context);
        }

        #endregion
    }
}
