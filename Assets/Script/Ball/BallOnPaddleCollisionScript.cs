using UnityEngine;

namespace Pong.Ball
{
    public class BallOnPaddleCollisionScript : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private GameObject ball;

        #endregion

        #region MonoBehaviour

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetInstanceID() != ball.GetInstanceID())
            {
                return;
            }

            var ballTransform = ball.transform;
            var ballVelocity = ball.GetComponent<Rigidbody2D>();
            var ballScript = ball.GetComponent<BallScript>();
            var paddleTransform = gameObject.GetComponent<RectTransform>();

            var hitFactor = (ballTransform.position.y - paddleTransform.position.y) / paddleTransform.sizeDelta.y;
            var direction = new Vector2(ballVelocity.velocity.x > 0 ? 1f : -1f, hitFactor * ballScript.GetHitAngleFactor()).normalized;

            ballScript.IncrementSpeed();
            ballVelocity.velocity = direction * ballScript.GetSpeed();
        }

        #endregion
    }
}
