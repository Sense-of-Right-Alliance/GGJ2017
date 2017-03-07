using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017.Items
{
    public static class ItemManager
    {
        public static Dictionary<ItemType, Item> Items { get; } = new Dictionary<ItemType, Item>()
        {
            { ItemType.Wine, new Item("Some Wine", ItemType.Wine) },
            { ItemType.Hat, new Item("A Hat", ItemType.Hat) },
            { ItemType.ModernArt, new Item("Some Modern Art", ItemType.ModernArt) },
            { ItemType.Toy, new Item("A Toy", ItemType.Toy) },
        };
    }
}
