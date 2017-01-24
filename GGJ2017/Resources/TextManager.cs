using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017.Resources
{
    public class TextManager
    {
        public static Dictionary<GameState, string> GameStateText = new Dictionary<GameState, string>()
        {
            { GameState.NotStarted, "This is a game for two players.  One player controls the actions of the jerk, and the other controls the actions of the friend.  It is important that each player hides their actions from each other, so make sure not to peek when it's not your turn.  When the first player is ready to start, press the button on the right."},
            { GameState.JerkSwappingOut, "Your turn has ended.  Please clear your confidential information, then swap places with the friend and look away while they take their turn." },
            { GameState.FriendSwappingOut, "Your turn has ended.  Please clear your confidential information, then swap places with the jerk and look away while they take their turn." },
            { GameState.JerkSwappingIn, "Welcome back, jerk.  Please press the button on the right to start your turn." },
            { GameState.FriendSwappingIn, "Welcome back, friend.  Please press the button on the right to start your turn." },
            { GameState.Ended, "The game is over.  Thanks for playing!" },
            // todo: add unique endings to game state
        };
    }
}
