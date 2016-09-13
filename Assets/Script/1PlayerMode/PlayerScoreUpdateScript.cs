using Pong.Constants;
using Pong.Player;
using UnityEngine;

namespace Pong.OnePlayerMode
{
    public class PlayerScoreUpdateScript : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private PlayerScoreScript playerScore;

        [SerializeField]
        private PlayerScoreScript highScore;

        #endregion

        #region MonoBehaviour

        private void OnCollisionEnter2D()
        {
            var newPlayerScore = playerScore.IncrementScore();
            var highScoreValue = highScore.GetScore();

            if (newPlayerScore > highScoreValue)
            {
                var newHighScore = highScore.IncrementScore();
                PlayerPrefs.SetInt(Const.PLAYER_PREFS_1PLAYER_HIGH_SCORE, newHighScore);
                PlayerPrefs.Save();
            }
        }

        #endregion
    }
}
