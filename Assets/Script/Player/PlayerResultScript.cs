using UnityEngine;
using UnityEngine.UI;

namespace Pong.Player
{
    public class PlayerResultScript : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private Text textScript;

        [SerializeField]
        private Color winColor;

        [SerializeField]
        private Color loseColor;

        [SerializeField]
        private string winText;

        [SerializeField]
        private string loseText;

        #endregion

        #region Result management

        public void SetWin()
        {
            textScript.text = winText;
            textScript.color = winColor;
        }

        public void SetLose()
        {
            textScript.text = loseText;
            textScript.color = loseColor;
        }

        #endregion
    }
}
