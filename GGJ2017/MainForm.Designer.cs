namespace GGJ2017
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.actionPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.TableLayoutPanel();
            this.inventoryPanel = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.dialoguePanel = new System.Windows.Forms.Panel();
            this.portraitPanel = new System.Windows.Forms.Panel();
            this.portraitPictureBox = new System.Windows.Forms.PictureBox();
            this.historyPanel = new System.Windows.Forms.Panel();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.dialogueLabel = new System.Windows.Forms.Label();
            this.actionPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.dialoguePanel.SuspendLayout();
            this.portraitPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portraitPictureBox)).BeginInit();
            this.historyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.buttonPanel);
            this.actionPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.actionPanel.Location = new System.Drawing.Point(716, 0);
            this.actionPanel.Name = "actionPanel";
            this.actionPanel.Padding = new System.Windows.Forms.Padding(10);
            this.actionPanel.Size = new System.Drawing.Size(252, 547);
            this.actionPanel.TabIndex = 2;
            // 
            // buttonPanel
            // 
            this.buttonPanel.ColumnCount = 1;
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(10, 10);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.RowCount = 1;
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 527F));
            this.buttonPanel.Size = new System.Drawing.Size(232, 527);
            this.buttonPanel.TabIndex = 0;
            // 
            // inventoryPanel
            // 
            this.inventoryPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.inventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.inventoryPanel.Name = "inventoryPanel";
            this.inventoryPanel.Padding = new System.Windows.Forms.Padding(10);
            this.inventoryPanel.Size = new System.Drawing.Size(252, 547);
            this.inventoryPanel.TabIndex = 3;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.dialoguePanel);
            this.infoPanel.Controls.Add(this.portraitPanel);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(252, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(10);
            this.infoPanel.Size = new System.Drawing.Size(464, 235);
            this.infoPanel.TabIndex = 4;
            // 
            // dialoguePanel
            // 
            this.dialoguePanel.Controls.Add(this.dialogueLabel);
            this.dialoguePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialoguePanel.Location = new System.Drawing.Point(140, 10);
            this.dialoguePanel.Name = "dialoguePanel";
            this.dialoguePanel.Size = new System.Drawing.Size(314, 215);
            this.dialoguePanel.TabIndex = 1;
            // 
            // portraitPanel
            // 
            this.portraitPanel.Controls.Add(this.portraitPictureBox);
            this.portraitPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.portraitPanel.Location = new System.Drawing.Point(10, 10);
            this.portraitPanel.Name = "portraitPanel";
            this.portraitPanel.Size = new System.Drawing.Size(130, 215);
            this.portraitPanel.TabIndex = 0;
            // 
            // portraitPictureBox
            // 
            this.portraitPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portraitPictureBox.Location = new System.Drawing.Point(0, 0);
            this.portraitPictureBox.Name = "portraitPictureBox";
            this.portraitPictureBox.Size = new System.Drawing.Size(130, 215);
            this.portraitPictureBox.TabIndex = 0;
            this.portraitPictureBox.TabStop = false;
            // 
            // historyPanel
            // 
            this.historyPanel.Controls.Add(this.historyListBox);
            this.historyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyPanel.Location = new System.Drawing.Point(252, 235);
            this.historyPanel.Name = "historyPanel";
            this.historyPanel.Padding = new System.Windows.Forms.Padding(10);
            this.historyPanel.Size = new System.Drawing.Size(464, 312);
            this.historyPanel.TabIndex = 5;
            // 
            // historyListBox
            // 
            this.historyListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyListBox.FormattingEnabled = true;
            this.historyListBox.Location = new System.Drawing.Point(10, 10);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.historyListBox.Size = new System.Drawing.Size(444, 292);
            this.historyListBox.TabIndex = 2;
            // 
            // dialogueLabel
            // 
            this.dialogueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogueLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueLabel.Location = new System.Drawing.Point(0, 0);
            this.dialogueLabel.Margin = new System.Windows.Forms.Padding(10);
            this.dialogueLabel.Name = "dialogueLabel";
            this.dialogueLabel.Size = new System.Drawing.Size(314, 215);
            this.dialogueLabel.TabIndex = 0;
            this.dialogueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 547);
            this.Controls.Add(this.historyPanel);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.actionPanel);
            this.Controls.Add(this.inventoryPanel);
            this.Name = "MainForm";
            this.Text = "That Jerk Is My Friend!";
            this.actionPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.dialoguePanel.ResumeLayout(false);
            this.portraitPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.portraitPictureBox)).EndInit();
            this.historyPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel actionPanel;
        private System.Windows.Forms.Panel inventoryPanel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Panel historyPanel;
        private System.Windows.Forms.ListBox historyListBox;
        private System.Windows.Forms.TableLayoutPanel buttonPanel;
        private System.Windows.Forms.Panel dialoguePanel;
        private System.Windows.Forms.Panel portraitPanel;
        private System.Windows.Forms.PictureBox portraitPictureBox;
        private System.Windows.Forms.Label dialogueLabel;
    }
}

