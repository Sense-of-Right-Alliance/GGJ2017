using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GGJ2017.Characters;

namespace GGJ2017.Interface
{
    public class DialogueManager
    {
        private PictureBox _portraitPictureBox;
        private Label _dialogueLabel;

        private string Text { set { _dialogueLabel.Text = value; } }
        private string PortraitLocation { set { _portraitPictureBox.ImageLocation = value; } }

        public DialogueManager(PictureBox portraitPictureBox, Label dialogueLabel)
        {
            _portraitPictureBox = portraitPictureBox;
            _dialogueLabel = dialogueLabel;
        }

        public void Clear()
        {
            Text = string.Empty;
            PortraitLocation = string.Empty;
        }

        public void Display(Character character, DialogueType type)
        {
            if (type == DialogueType.Befriended)
            {
                PortraitLocation = character.PortraitLocation;
                Text = character.BefriendedDialogue;
            }
            else if (type == DialogueType.Offended)
            {
                PortraitLocation = character.PortraitLocation;
                Text = character.OffendedDialogue;
            }
            else
            {
                Clear();
            }
        }

        public void Display(string text)
        {
            Clear();
            Text = text;
        }
    }
}
