using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017.Players
{
    public class PlayerManager
    {
        public const int JerkMoves = 3;
        public const int FriendMoves = 3;

        public PlayerType CurrentPlayer { get; private set; } = PlayerType.Jerk;

        public int MovesRemaining { get; set; } = JerkMoves;

        public void SwapPlayers()
        {
            if (CurrentPlayer == PlayerType.Jerk)
            {
                CurrentPlayer = PlayerType.Friend;
                MovesRemaining = FriendMoves;
            }
            else if (CurrentPlayer == PlayerType.Friend)
            {
                CurrentPlayer = PlayerType.Jerk;
                MovesRemaining = JerkMoves;
            }
        }
    }
}
