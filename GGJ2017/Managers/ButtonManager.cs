using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGJ2017.Managers
{
    public class ButtonManager
    {
        private TableLayoutPanel _buttonPanel;

        public ButtonManager(TableLayoutPanel buttonPanel)
        {
            _buttonPanel = buttonPanel;
        }

        public void ClearButtons()
        {
            // remove and dispose of all buttons
            for (int i = _buttonPanel.Controls.Count; i > 0; i--)
            {
                Control c = _buttonPanel.Controls[i - 1];
                _buttonPanel.Controls.Remove(c);
                c.Dispose();
            }

            // clear rowstyles
            _buttonPanel.RowStyles.Clear();

            // keep one row that fills the unused space
            _buttonPanel.RowCount = 1;
            _buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        }

        public void AddButton(string text, Action action)
        {
            // add row
            _buttonPanel.RowStyles.Insert(_buttonPanel.RowCount - 1, new RowStyle(SizeType.Absolute, 40F));
            _buttonPanel.RowCount += 1;

            // create button and assign action to its click event
            var button = new Button { Text = text, Dock = DockStyle.Fill };
            button.Click += (sender, e) => action();

            // add button to panel
            _buttonPanel.Controls.Add(button);
        }
    }
}
