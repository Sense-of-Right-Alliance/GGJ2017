using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GGJ2017.Items;

namespace GGJ2017.Characters
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ItemType BefriendedItem { get; set; }
        public ItemType OffendedItem { get; set; }

        public string BefriendedPortrait { get; set; }
        public string OffendedPortrait { get; set; }

        public string BefriendedDialogue { get; set; }
        public string OffendedDialogue { get; set; }
    }
}
