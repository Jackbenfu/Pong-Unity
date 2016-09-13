using Pong.Player;
using UnityEngine;

namespace Pong.TwoPlayerMode.State.GameOver
{
    public class GameOverState2PContext
    {
        public GameObject GameOver { get; set; }

        public PlayerScoreScript LeftScore { get; set; }

        public PlayerResultScript LeftResult { get; set; }

        public PlayerScoreScript RightScore { get; set; }

        public PlayerResultScript RightResult { get; set; }
    }
}
