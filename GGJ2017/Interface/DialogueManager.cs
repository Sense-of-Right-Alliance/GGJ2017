﻿using System;
using System.Collections.Generic;
using System.IO;
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

        private const string PortraitPrefix = "Portraits";

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
            _portraitPictureBox.Visible = true;

            if (type == DialogueType.Befriended)
            {
                PortraitLocation = Path.Combine(PortraitPrefix, character.BefriendedPortrait + ".png");
                Text = character.BefriendedDialogue;
            }
            else if (type == DialogueType.Offended)
            {
                PortraitLocation = Path.Combine(PortraitPrefix, character.OffendedPortrait + ".png");
                Text = character.OffendedDialogue;
            }
            else
            {
                Clear();
            }
        }

        public void Display(string text)
        {
            _portraitPictureBox.Visible = false;

            Clear();
            Text = text;
        }
    }
}
