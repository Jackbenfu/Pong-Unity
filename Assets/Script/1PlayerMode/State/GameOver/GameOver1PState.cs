using Pong.Constants;
using Pong.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.OnePlayerMode.State.GameOver
{
    public class GameOver1PState : StateWithContext<OnePlayerStateMachineScript, GameOver1PStateContext>
    {
        #region Private

        private GameObject gameOver;

        #endregion

        #region State

        public override void Init()
        {
            gameOver = Context.GameOver;
        }

        public override void Enter(object param)
        {
            gameOver.SetActive(true);
        }

        public override void Exit()
        {
            gameOver.SetActive(false);
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(Const.SCENE_MENU);
            }
        }

        #endregion
    }
}
