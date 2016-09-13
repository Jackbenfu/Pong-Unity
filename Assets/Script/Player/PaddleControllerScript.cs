using UnityEngine;

namespace Pong.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PaddleControllerScript : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        [Range(300, 1000)]
        private int Speed;

        [SerializeField]
        private KeyCode upKeyCode;

        [SerializeField]
        private KeyCode downKeyCode;

        #endregion

        #region Private

        private Rigidbody2D rigidBody;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            var up = Input.GetKey(upKeyCode);
            var down = Input.GetKey(downKeyCode);

            if (up ^ down)
            {
                rigidBody.velocity = new Vector2(0f, up ? Speed : -Speed);
            }
            else
            {
                rigidBody.velocity = Vector2.zero;
            }
        }

        #endregion
    }
}
