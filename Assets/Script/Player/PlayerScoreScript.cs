using UnityEngine;
using UnityEngine.UI;

namespace Pong.Player
{
    [RequireComponent(typeof(Text))]
    public class PlayerScoreScript : MonoBehaviour
    {
        #region Inspector

        [SerializeField]
        private Text textComponent;

        [SerializeField]
        private string format;

        #endregion

        #region Private

        private int score;

        #endregion

        #region Score management

        public int GetScore()
        {
            return score;
        }

        public int IncrementScore()
        {
            ++score;
            UpdateScoreUI();

            return score;
        }

        public void SetScore(int newScore)
        {
            score = newScore;
            UpdateScoreUI();
        }

        #endregion

        #region Utils

        private void UpdateScoreUI()
        {
            if (string.IsNullOrEmpty(format))
            {
                textComponent.text = score.ToString();
            }
            else
            {
                textComponent.text = string.Format(format, score);
            }
        }

        #endregion
    }
}
