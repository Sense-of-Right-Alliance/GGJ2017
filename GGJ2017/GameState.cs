using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017
{
    public enum GameState
    {
        NotStarted,
        JerkSwappingIn,
        JerkTurn,
        JerkSwappingOut,
        FriendSwappingIn,
        FriendTurn,
        FriendSwappingOut,
        Ended,
    }
}
