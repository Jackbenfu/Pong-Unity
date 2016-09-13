using Pong.Constants;
using UnityEngine;

namespace Pong.Ball
{
    public class BallScript : MonoBehaviour
    {
        #region Public properties

        [SerializeField]
        [Range(Const.BALL_SPEED_MIN, Const.BALL_SPEED_MAX)]
        private int speed;

        [SerializeField]
        [Range(Const.BALL_SPEED_INCREMENT_STEP_MIN, Const.BALL_SPEED_INCREMENT_STEP_MAX)]
        private int speedIncrementStep;

        [SerializeField]
        [Range(Const.BALL_HIT_ANGLE_FACTOR_MIN, Const.BALL_HIT_ANGLE_FACTOR_MAX)]
        private int hitAngleFactor;

        #endregion

        public int GetSpeed()
        {
            return speed;
        }

        public void IncrementSpeed()
        {
            if (speed + speedIncrementStep > Const.BALL_SPEED_MAX)
            {
                speed = Const.BALL_SPEED_MAX;
            }
            else
            {
                speed += speedIncrementStep;
            }
        }

        public void ResetSpeed()
        {
            speed = Const.BALL_SPEED_MIN;
        }

        public int GetHitAngleFactor()
        {
            return hitAngleFactor;
        }
    }
}
