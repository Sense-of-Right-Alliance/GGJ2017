using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GGJ2017.Players;

namespace GGJ2017.Interface
{
    public class LogManager
    {
        private class LogEntry
        {
            public string Text;
            public int? Index;
        }

        private ListBox _listBox;

        private List<LogEntry> _jerkEntries = new List<LogEntry>();
        private List<LogEntry> _friendEntries = new List<LogEntry>();

        public int ItemCount { get { return _listBox.Items.Count; } }

        public Func<string, int, string> Formatter = (entry, index) => string.Format("{0:d2}: {1}", index + 1, entry);

        public LogManager(ListBox listBox)
        {
            _listBox = listBox;
        }

        public void Reset()
        {
            _jerkEntries.Clear();
            _friendEntries.Clear();
            Clear();
        }

        public void Clear()
        {
            _listBox.Items.Clear();
        }

        public void Refresh(PlayerType type)
        {
            Clear();

            var entries = Enumerable.Empty<LogEntry>();
            if (type == PlayerType.Friend)
            {
                entries = _friendEntries;
            }
            else if (type == PlayerType.Jerk)
            {
                entries = _jerkEntries;
            }

            foreach (var entry in entries)
            {
                _listBox.Items.Insert(0, Format(entry));
            }
        }

        public void Add(string text, PlayerType type, bool format=true)
        {
            var entry = new LogEntry() { Text = text };

            if (type == PlayerType.Jerk)
            {
                if (format)
                {
                    entry.Index = _jerkEntries.Count(e => e.Index != null);
                }
                _jerkEntries.Add(entry);
            }
            else if (type == PlayerType.Friend)
            {
                if (format)
                {
                    entry.Index = _friendEntries.Count(e => e.Index != null);
                }
                _friendEntries.Add(entry);
            }

            Refresh(type);
        }

        private string Format(LogEntry entry)
        {
            if (Formatter == null || entry.Index == null)
            {
                return entry.Text;
            }
            return Formatter(entry.Text, entry.Index.Value);
        }
    }
}
