namespace Programming4_Lab03_Forms
{
    partial class FindForm
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
            this.labelWhat = new System.Windows.Forms.Label();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.collapsableGroupBox1 = new CollapsableGroupBox.CollapsableGroupBox();
            this.checkBoxRegEx = new System.Windows.Forms.CheckBox();
            this.checkBoxSensitive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelWhat
            // 
            this.labelWhat.AutoSize = true;
            this.labelWhat.Location = new System.Drawing.Point(12, 9);
            this.labelWhat.Name = "labelWhat";
            this.labelWhat.Size = new System.Drawing.Size(56, 13);
            this.labelWhat.TabIndex = 0;
            this.labelWhat.Text = "Find what:";
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuery.Location = new System.Drawing.Point(12, 25);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(351, 20);
            this.textBoxQuery.TabIndex = 1;
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFindNext.Location = new System.Drawing.Point(369, 22);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(75, 23);
            this.buttonFindNext.TabIndex = 2;
            this.buttonFindNext.Text = "Find next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // collapsableGroupBox1
            // 
            this.collapsableGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.collapsableGroupBox1.CollapsedHeight = 20;
            this.collapsableGroupBox1.GroupBoxText = "Search options";
            this.collapsableGroupBox1.IsCollapsed = false;
            this.collapsableGroupBox1.Location = new System.Drawing.Point(111, 51);
            this.collapsableGroupBox1.Name = "collapsableGroupBox1";
            this.collapsableGroupBox1.Size = new System.Drawing.Size(333, 119);
            this.collapsableGroupBox1.TabIndex = 15;
            this.collapsableGroupBox1.TabStop = false;
            this.collapsableGroupBox1.UnCollapsedHeight = 119;
            this.collapsableGroupBox1.CollapsedChanged += new CollapsableGroupBox.CollapsableGroupBox.SubmitClickedHandler(this.collapsableGroupBox1_CollapsedChanged);
            // 
            // checkBoxRegEx
            // 
            this.checkBoxRegEx.AutoSize = true;
            this.checkBoxRegEx.Location = new System.Drawing.Point(12, 87);
            this.checkBoxRegEx.Name = "checkBoxRegEx";
            this.checkBoxRegEx.Size = new System.Drawing.Size(136, 17);
            this.checkBoxRegEx.TabIndex = 17;
            this.checkBoxRegEx.Text = "use regular expressions";
            this.checkBoxRegEx.UseVisualStyleBackColor = true;
            // 
            // checkBoxSensitive
            // 
            this.checkBoxSensitive.AutoSize = true;
            this.checkBoxSensitive.Location = new System.Drawing.Point(12, 64);
            this.checkBoxSensitive.Name = "checkBoxSensitive";
            this.checkBoxSensitive.Size = new System.Drawing.Size(93, 17);
            this.checkBoxSensitive.TabIndex = 18;
            this.checkBoxSensitive.Text = "case sensitive";
            this.checkBoxSensitive.UseVisualStyleBackColor = true;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 180);
            this.Controls.Add(this.checkBoxSensitive);
            this.Controls.Add(this.checkBoxRegEx);
            this.Controls.Add(this.collapsableGroupBox1);
            this.Controls.Add(this.buttonFindNext);
            this.Controls.Add(this.textBoxQuery);
            this.Controls.Add(this.labelWhat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FindForm";
            this.Text = "Find";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWhat;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.Button buttonFindNext;
        private CollapsableGroupBox.CollapsableGroupBox collapsableGroupBox1;
        private System.Windows.Forms.CheckBox checkBoxRegEx;
        private System.Windows.Forms.CheckBox checkBoxSensitive;
    }
}