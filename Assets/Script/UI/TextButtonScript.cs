using UnityEngine;
using UnityEngine.UI;

namespace Pong.UI
{
    [RequireComponent(typeof(Text))]
    public class TextButtonScript : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private Text textComponent;

        [SerializeField]
        private Color hoverColor;

        #endregion

        #region Private

        private Color normalColor;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            normalColor = textComponent.color;
        }

        #endregion

        #region Event management

        public void OnEnter()
        {
            textComponent.color = hoverColor;
        }

        public void OnExit()
        {
            textComponent.color = normalColor;
        }

        #endregion
    }
}
