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
            this.roomLabel = new System.Windows.Forms.Label();
            this.inventoryPanel = new System.Windows.Forms.Panel();
            this.inventoryLabel = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.dialoguePanel = new System.Windows.Forms.Panel();
            this.dialogueLabel = new System.Windows.Forms.Label();
            this.portraitPictureBox = new System.Windows.Forms.PictureBox();
            this.infoLabel = new System.Windows.Forms.Label();
            this.historyPanel = new System.Windows.Forms.Panel();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.historyLabel = new System.Windows.Forms.Label();
            this.inventoryTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.actionPanel.SuspendLayout();
            this.inventoryPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.dialoguePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portraitPictureBox)).BeginInit();
            this.historyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionPanel
            // 
            this.actionPanel.Controls.Add(this.buttonPanel);
            this.actionPanel.Controls.Add(this.roomLabel);
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
            this.buttonPanel.Location = new System.Drawing.Point(10, 43);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.RowCount = 1;
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 494F));
            this.buttonPanel.Size = new System.Drawing.Size(232, 494);
            this.buttonPanel.TabIndex = 0;
            // 
            // roomLabel
            // 
            this.roomLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.roomLabel.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomLabel.Location = new System.Drawing.Point(10, 10);
            this.roomLabel.Margin = new System.Windows.Forms.Padding(10);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(232, 33);
            this.roomLabel.TabIndex = 0;
            this.roomLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // inventoryPanel
            // 
            this.inventoryPanel.Controls.Add(this.inventoryTablePanel);
            this.inventoryPanel.Controls.Add(this.inventoryLabel);
            this.inventoryPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.inventoryPanel.Location = new System.Drawing.Point(0, 0);
            this.inventoryPanel.Name = "inventoryPanel";
            this.inventoryPanel.Padding = new System.Windows.Forms.Padding(10);
            this.inventoryPanel.Size = new System.Drawing.Size(252, 547);
            this.inventoryPanel.TabIndex = 3;
            // 
            // inventoryLabel
            // 
            this.inventoryLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.inventoryLabel.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryLabel.Location = new System.Drawing.Point(10, 10);
            this.inventoryLabel.Margin = new System.Windows.Forms.Padding(10);
            this.inventoryLabel.Name = "inventoryLabel";
            this.inventoryLabel.Size = new System.Drawing.Size(232, 33);
            this.inventoryLabel.TabIndex = 2;
            this.inventoryLabel.Text = "Inventory";
            this.inventoryLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.dialoguePanel);
            this.infoPanel.Controls.Add(this.portraitPictureBox);
            this.infoPanel.Controls.Add(this.infoLabel);
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
            this.dialoguePanel.Location = new System.Drawing.Point(140, 43);
            this.dialoguePanel.Name = "dialoguePanel";
            this.dialoguePanel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dialoguePanel.Size = new System.Drawing.Size(314, 182);
            this.dialoguePanel.TabIndex = 1;
            // 
            // dialogueLabel
            // 
            this.dialogueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dialogueLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueLabel.Location = new System.Drawing.Point(5, 0);
            this.dialogueLabel.Margin = new System.Windows.Forms.Padding(10);
            this.dialogueLabel.Name = "dialogueLabel";
            this.dialogueLabel.Size = new System.Drawing.Size(304, 182);
            this.dialogueLabel.TabIndex = 0;
            this.dialogueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // portraitPictureBox
            // 
            this.portraitPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.portraitPictureBox.Location = new System.Drawing.Point(10, 43);
            this.portraitPictureBox.Name = "portraitPictureBox";
            this.portraitPictureBox.Size = new System.Drawing.Size(130, 182);
            this.portraitPictureBox.TabIndex = 0;
            this.portraitPictureBox.TabStop = false;
            // 
            // infoLabel
            // 
            this.infoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoLabel.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoLabel.Location = new System.Drawing.Point(10, 10);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(10);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(444, 33);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "Information";
            this.infoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // historyPanel
            // 
            this.historyPanel.Controls.Add(this.historyListBox);
            this.historyPanel.Controls.Add(this.historyLabel);
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
            this.historyListBox.Location = new System.Drawing.Point(10, 43);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.historyListBox.Size = new System.Drawing.Size(444, 259);
            this.historyListBox.TabIndex = 2;
            // 
            // historyLabel
            // 
            this.historyLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.historyLabel.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyLabel.Location = new System.Drawing.Point(10, 10);
            this.historyLabel.Margin = new System.Windows.Forms.Padding(10);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(444, 33);
            this.historyLabel.TabIndex = 6;
            this.historyLabel.Text = "History";
            this.historyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // inventoryTablePanel
            // 
            this.inventoryTablePanel.ColumnCount = 1;
            this.inventoryTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inventoryTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inventoryTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inventoryTablePanel.Location = new System.Drawing.Point(10, 43);
            this.inventoryTablePanel.Name = "inventoryTablePanel";
            this.inventoryTablePanel.RowCount = 1;
            this.inventoryTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inventoryTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 494F));
            this.inventoryTablePanel.Size = new System.Drawing.Size(232, 494);
            this.inventoryTablePanel.TabIndex = 3;
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
            this.inventoryPanel.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.dialoguePanel.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox portraitPictureBox;
        private System.Windows.Forms.Label dialogueLabel;
        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.Label inventoryLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.TableLayoutPanel inventoryTablePanel;
    }
}

