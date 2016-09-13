using Pong.Player;
using UnityEngine;

namespace Pong.TwoPlayerMode.State.Rally
{
    public class RallyState2PContext
    {
        public Canvas Canvas { get; set; }

        public GameObject Ball { get; set; }

        public GameObject LeftPaddle { get; set; }

        public PlayerScoreScript LeftScore { get; set; }

        public GameObject RightPaddle { get; set; }

        public PlayerScoreScript RightScore { get; set; }

        public int WinScore { get; set; }
    }
}
