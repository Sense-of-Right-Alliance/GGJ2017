using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017.Characters
{
    public class Character
    {
        public string Id { get; }
        public string Name { get; }

        public string PortraitLocation { get; set; }

        public string BefriendedDialogue { get; set; }
        public string OffendedDialogue { get; set; }

        public Character(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
