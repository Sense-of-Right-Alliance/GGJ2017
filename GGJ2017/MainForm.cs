using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GGJ2017
{
    public partial class MainForm : Form
    {
        public ListBox HistoryListBox { get { return this.historyListBox; } }
        public TableLayoutPanel ButtonTablePanel { get { return this.buttonPanel; } }
        public TableLayoutPanel InventoryTablePanel { get { return this.inventoryTablePanel; } }
        public Label DialogueLabel { get { return this.dialogueLabel; } }
        public PictureBox PortraitPictureBox { get { return this.portraitPictureBox; } }
        public Label RoomLabel { get { return this.roomLabel; } }

        private GameManager _gameManager;

        public MainForm()
        {
            InitializeComponent();

            // disallow selecting items from listbox by preventing it from receiving focus
            historyListBox.GotFocus += (sender, e) => this.Focus();

            _gameManager = new GameManager(this);
        }
    }
}
