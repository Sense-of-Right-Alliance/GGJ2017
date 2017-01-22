using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017.Items
{
    public class InventoryManager
    {
        private List<Item> _items = new List<Item>();
        
        public IEnumerable<Item> Items { get { return _items; } }

        public void ClearInventory()
        {
            _items.Clear();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public bool RemoveItem(Item item)
        {
            return _items.Remove(item);
        }
    }
}
