using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017.Items
{
    public class Item
    {
        public string Name { get; }
        public ItemType ItemType { get; }

        public Item(string name, ItemType itemType)
        {
            Name = name;
            ItemType = itemType;
        }
    }
}
