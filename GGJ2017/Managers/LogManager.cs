using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGJ2017.Managers
{
    public class LogManager
    {
        private ListBox _listBox;

        public int ItemCount { get { return _listBox.Items.Count; } }

        public LogManager(ListBox listBox)
        {
            _listBox = listBox;
        }

        public void Clear()
        {
            _listBox.Items.Clear();
        }

        public void Log(string entry)
        {
            _listBox.Items.Insert(0, FormatEntry(entry));
        }

        private string FormatEntry(string entry)
        {
            return $"{ItemCount + 1:d2}: {entry}";
        }
    }
}
