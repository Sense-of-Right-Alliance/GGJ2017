using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GGJ2017.Items;

namespace GGJ2017.Characters
{
    public static class CharacterManager
    {
        public static Dictionary<CharacterType, Character> Characters { get; } = new Dictionary<CharacterType, Character>()
        {
            {
                CharacterType.Critic,
                new Character()
                {
                    Id = "critic",
                    Name = "Critic",
                    BefriendedItem = ItemType.ModernArt,
                    OffendedItem = ItemType.Hat,
                    BefriendedPortrait = "CriticHappy",
                    OffendedPortrait = "CriticSad",
                    BefriendedDialogue = "Finally, an island in an ocean of triteness! I will treasure this masterpiece forever!",
                    OffendedDialogue = "This is the most atrocious thing I've yet seen. Its banality offends all of my refined senses!",
                }
            },
            {
                CharacterType.Politician,
                new Character()
                {
                    Id = "politician",
                    Name = "Politician",
                    BefriendedItem = ItemType.Wine,
                    OffendedItem = ItemType.Toy,
                    BefriendedPortrait = "PoliticianHappy",
                    OffendedPortrait = "PoliticianSad",
                    BefriendedDialogue = "It's happy hour already? Well, I'm not complaining!",
                    OffendedDialogue = "What?! This is awful! I can't be photographed holding a kid's toy! What will my constituents think?!",
                }
            },
            {
                CharacterType.Trendsetter,
                new Character()
                {
                    Id = "trendsetter",
                    Name = "Trendsetter",
                    BefriendedItem = ItemType.Hat,
                    OffendedItem = ItemType.Wine,
                    BefriendedPortrait = "TrendHappy",
                    OffendedPortrait = "TrendSad",
                    BefriendedDialogue = "This hat... it will be the begining of a new trend.",
                    OffendedDialogue = "Why did you spill all this wine on my wonderful sweater? I deem that a most un-trendy thing to do.",
                }
            },
            {
                CharacterType.Tycoon,
                new Character()
                {
                    Id = "tycoon",
                    Name = "Tycoon",
                    BefriendedItem = ItemType.Toy,
                    OffendedItem = ItemType.ModernArt,
                    BefriendedPortrait = "TycoonHappy",
                    OffendedPortrait = "TycoonSad",
                    BefriendedDialogue = "What a fantastic toy! I'll make sure every family has five!",
                    OffendedDialogue = "What is this nonsense? None of the colours make sense and the shapes are all wrong. This has given me a great headache!",
                }
            },
        };
    }
}
