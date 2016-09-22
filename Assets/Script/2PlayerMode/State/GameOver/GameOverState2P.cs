using Pong.Constants;
using Pong.Player;
using Pong.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.TwoPlayerMode.State.GameOver
{
    public class GameOverState2P : StateWithContext<TwoPlayerStateMachineScript, GameOverState2PContext>
    {
        #region Private properties

        private PlayerScoreScript leftScoreScript;
        private PlayerResultScript leftResultScript;

        private PlayerScoreScript rightScoreScript;
        private PlayerResultScript rightResultScript;

        #endregion

        #region State

        public override void Init()
        {
            leftScoreScript = Context.LeftScore;
            leftResultScript = Context.LeftResult;

            rightScoreScript = Context.RightScore;
            rightResultScript = Context.RightResult;
        }

        public override void Enter(object param)
        {
            if (leftScoreScript.GetScore() > rightScoreScript.GetScore())
            {
                leftResultScript.SetWin();
                rightResultScript.SetLose();
            }
            else
            {
                leftResultScript.SetLose();
                rightResultScript.SetWin();
            }

            Context.GameOver.SetActive(true);
        }

        public override void Exit()
        {
            Context.GameOver.SetActive(false);
        }

        public override void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(Const.SCENE_MENU);
            }
        }

        #endregion
    }
}
