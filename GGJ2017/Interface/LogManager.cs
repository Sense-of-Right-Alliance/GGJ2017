using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGJ2017.Interface
{
    public class LogManager
    {
        private ListBox _listBox;
        private List<string> entries = new List<string>();

        public int ItemCount { get { return _listBox.Items.Count; } }

        public Func<string, int, string> Formatter = (entry, index) => string.Format("{0:d2}: {1}", index + 1, entry);

        public LogManager(ListBox listBox)
        {
            _listBox = listBox;
        }

        public void Clear(bool permanent = true)
        {
            if (permanent)
            {
                entries.Clear();
            }
            
            _listBox.Items.Clear();
        }

        public void Refresh()
        {
            _listBox.Items.Clear();
            foreach (var entry in entries)
            {
                _listBox.Items.Insert(0, Format(entry));
            }
        }

        public void Add(string entry)
        {
            entries.Add(entry);
            _listBox.Items.Insert(0, Format(entry));
        }

        private string Format(string entry)
        {
            if (Formatter == null)
            {
                return entry;
            }
            return Formatter(entry, ItemCount);
        }
    }
}
