using Pong.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Pong.TwoPlayerMode.State.Service
{
    public class ServiceState2PContext
    {
        public GameObject Ball { get; set; }

        public GameObject LeftPaddle { get; set; }

        public PlayerScoreScript LeftScoreMax { get; set; }

        public GameObject RightPaddle { get; set; }

        public PlayerScoreScript RightScoreMax { get; set; }

        public GameObject Instruction { get; set; }

        public Text Goal { get; set; }

        public int WinScore { get; set; }
    }
}
