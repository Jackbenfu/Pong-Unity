using Pong.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pong.Menu
{
    public class MenuSceneButtonScript : MonoBehaviour
    {
        public void Start1PlayerMode()
        {
            SceneManager.LoadScene(Const.SCENE_1_PLAYER);
        }

        public void Start2PlayerMode()
        {
            SceneManager.LoadScene(Const.SCENE_2_PLAYERS);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
