namespace Programming4_Lab03pl_Forms
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.folderListView = new System.Windows.Forms.ListView();
            this.folderTreeView = new System.Windows.Forms.TreeView();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonShowParts = new System.Windows.Forms.Button();
            this.buttonCollapse = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.folderButton = new System.Windows.Forms.Button();
            this.folderLabel = new System.Windows.Forms.Label();
            this.folderBox = new System.Windows.Forms.TextBox();
            this.folderSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.pluginsToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(634, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 24);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.folderListView);
            this.mainSplit.Panel1.Controls.Add(this.folderTreeView);
            this.mainSplit.Panel1.Controls.Add(this.buttonAdd);
            this.mainSplit.Panel1.Controls.Add(this.buttonShowParts);
            this.mainSplit.Panel1.Controls.Add(this.buttonCollapse);
            this.mainSplit.Panel1.Controls.Add(this.buttonClear);
            this.mainSplit.Panel1.Controls.Add(this.folderButton);
            this.mainSplit.Panel1.Controls.Add(this.folderLabel);
            this.mainSplit.Panel1.Controls.Add(this.folderBox);
            this.mainSplit.Panel1MinSize = 240;
            this.mainSplit.Panel2MinSize = 300;
            this.mainSplit.Size = new System.Drawing.Size(634, 346);
            this.mainSplit.SplitterDistance = 240;
            this.mainSplit.TabIndex = 1;
            // 
            // folderListView
            // 
            this.folderListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.folderListView.Location = new System.Drawing.Point(12, 265);
            this.folderListView.Name = "folderListView";
            this.folderListView.Size = new System.Drawing.Size(222, 69);
            this.folderListView.TabIndex = 8;
            this.folderListView.UseCompatibleStateImageBehavior = false;
            // 
            // folderTreeView
            // 
            this.folderTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTreeView.Location = new System.Drawing.Point(12, 93);
            this.folderTreeView.Name = "folderTreeView";
            this.folderTreeView.Size = new System.Drawing.Size(223, 137);
            this.folderTreeView.TabIndex = 7;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(12, 236);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(89, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Add to selected";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonShowParts
            // 
            this.buttonShowParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowParts.Location = new System.Drawing.Point(147, 63);
            this.buttonShowParts.Name = "buttonShowParts";
            this.buttonShowParts.Size = new System.Drawing.Size(88, 23);
            this.buttonShowParts.TabIndex = 5;
            this.buttonShowParts.Text = "Show partitions";
            this.buttonShowParts.UseVisualStyleBackColor = true;
            // 
            // buttonCollapse
            // 
            this.buttonCollapse.Location = new System.Drawing.Point(58, 63);
            this.buttonCollapse.Name = "buttonCollapse";
            this.buttonCollapse.Size = new System.Drawing.Size(68, 23);
            this.buttonCollapse.TabIndex = 4;
            this.buttonCollapse.Text = "Collapse all";
            this.buttonCollapse.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(12, 63);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(40, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // folderButton
            // 
            this.folderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderButton.Location = new System.Drawing.Point(187, 25);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(48, 23);
            this.folderButton.TabIndex = 2;
            this.folderButton.Text = "Select";
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // folderLabel
            // 
            this.folderLabel.AutoSize = true;
            this.folderLabel.Location = new System.Drawing.Point(12, 11);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Size = new System.Drawing.Size(49, 13);
            this.folderLabel.TabIndex = 1;
            this.folderLabel.Text = "Directory";
            // 
            // folderBox
            // 
            this.folderBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.folderBox.Location = new System.Drawing.Point(12, 27);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(169, 20);
            this.folderBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 370);
            this.Controls.Add(this.mainSplit);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "MainForm";
            this.Text = "File Walker";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.TextBox folderBox;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonShowParts;
        private System.Windows.Forms.Button buttonCollapse;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.ListView folderListView;
        private System.Windows.Forms.TreeView folderTreeView;
        private System.Windows.Forms.FolderBrowserDialog folderSelector;
    }
}

