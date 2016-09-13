using Pong.Player;
using UnityEngine;

namespace Pong.OnePlayerMode.State.Service
{
    public class ServiceState1PContext
    {
        public GameObject Ball { get; set; }

        public GameObject Instruction { get; set; }

        public PlayerScoreScript HighScore { get; set; }
    }
}
