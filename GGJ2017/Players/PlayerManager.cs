using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GGJ2017.Characters;
using GGJ2017.Items;

namespace GGJ2017.Players
{
    public class PlayerManager
    {
        public const int JerkMoves = 3;
        public const int FriendMoves = 3;

        public Character JerkTargetCharacter { get; private set; }
        public Character FriendTargetCharacter { get; private set; }
        public Character CurrentTargetCharacter { get { return CurrentPlayer == PlayerType.Jerk ? JerkTargetCharacter : FriendTargetCharacter; } }

        public Item FriendTargetItem { get { return ItemManager.Items[FriendTargetCharacter.BefriendedItem]; } }
        public Item JerkTargetItem { get { return ItemManager.Items[JerkTargetCharacter.OffendedItem]; } }
        public Item CurrentTargetItem { get { return CurrentPlayer == PlayerType.Jerk ? JerkTargetItem : FriendTargetItem; } }
        
        public bool CanSeeInventory { get; set; }

        public PlayerType CurrentPlayer { get; private set; }

        public int MovesRemaining { get; set; }

        public PlayerManager()
        {
            Reset();
        }

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
            CanSeeInventory = false;
        }

        public void Reset()
        {
            CurrentPlayer = PlayerType.Jerk;
            MovesRemaining = JerkMoves;
            
            var characters = CharacterManager.Characters.Values.OrderBy(c => Guid.NewGuid()).Take(2);
            JerkTargetCharacter = characters.ElementAt(0);
            FriendTargetCharacter = characters.ElementAt(1);
        }
    }
}
