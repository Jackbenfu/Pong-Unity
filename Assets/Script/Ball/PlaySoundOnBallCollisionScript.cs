using UnityEngine;

namespace Pong.Ball
{
    [RequireComponent(typeof(AudioSource))]
    public class PlaySoundOnBallCollisionScript : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private GameObject ball;

        #endregion

        #region Private

        [HideInInspector]
        private AudioSource audioSource;

        #endregion

        #region MonoBehaviour

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioSource.clip;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (ball.GetInstanceID() == collision.gameObject.GetInstanceID())
            {
                audioSource.Play();
            }
        }

        #endregion
    }
}
