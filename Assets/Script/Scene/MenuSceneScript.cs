using UnityEngine;

namespace Pong.Scene
{
    public class MenuSceneScript : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private GameObject quitButton;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
#if UNITY_WEBGL
            quitButton.SetActive(false);
#endif
        }

        #endregion
    }
}
