using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGJ2017.Items
{
    public class Container
    {
        public string Name { get; set; }
        public string Action { get; set; } = "in the";

        private List<Item> _items = new List<Item>();
        
        public IEnumerable<Item> Items { get { return _items; } }

        public void Reset()
        {
            _items.Clear();
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public IEnumerable<Item> RemoveItems()
        {
            var items = new List<Item>(_items);
            _items.Clear();
            return items;
        }
    }
}
