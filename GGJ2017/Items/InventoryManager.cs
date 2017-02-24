using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGJ2017.Items
{
    public class InventoryManager
    {
        private List<Item> _items = new List<Item>();
        
        public IEnumerable<Item> Items { get { return _items; } }

        private TableLayoutPanel _inventoryPanel;

        public InventoryManager(TableLayoutPanel inventoryPanel)
        {
            _inventoryPanel = inventoryPanel;
        }

        public void Reset()
        {
            _items.Clear();
        }

        public void AddItem(Item item, bool updateInterface)
        {
            _items.Add(item);

            if (updateInterface)
            {
                ShowInventory(true);
            }
        }

        public bool RemoveItem(Item item)
        {
            return _items.Remove(item);
        }

        public bool HasItem(ItemType type)
        {
            return Items.Any(i => i.ItemType == type);
        }

        private void ClearPanel()
        {
            // remove and dispose of all items
            for (int i = _inventoryPanel.Controls.Count; i > 0; i--)
            {
                Control c = _inventoryPanel.Controls[i - 1];
                _inventoryPanel.Controls.Remove(c);
                c.Dispose();
            }

            // clear rowstyles
            _inventoryPanel.RowStyles.Clear();

            // keep one row that fills the unused space
            _inventoryPanel.RowCount = 1;
            _inventoryPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        }

        public void ShowInventory(bool show)
        {
            ClearPanel();

            if (show)
            {
                foreach (var item in Items)
                {
                    AddInventoryRow(item.Name);
                }
                if (Items.Count() == 0)
                {
                    AddInventoryRow("Empty");
                }
            }
        }

        private void AddInventoryRow(string text)
        {
            _inventoryPanel.RowStyles.Insert(_inventoryPanel.RowCount - 1, new RowStyle(SizeType.Absolute, 40F));
            _inventoryPanel.RowCount += 1;
            _inventoryPanel.Controls.Add(new Label { Text = text, AutoSize = false, Dock = DockStyle.Fill, TextAlign = System.Drawing.ContentAlignment.MiddleCenter });
        }
    }
}
