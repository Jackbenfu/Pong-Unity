using Pong.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.Scene
{
    public class GameSceneScript : MonoBehaviour
    {
        #region MonoBehaviour

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(Const.SCENE_MENU);
            }
        }

        #endregion
    }
}
