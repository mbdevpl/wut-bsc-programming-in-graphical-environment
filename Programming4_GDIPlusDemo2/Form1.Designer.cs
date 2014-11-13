namespace GDIPlus_Demo_2
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._selectImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new GDIPlus_Demo_2.DoubleBufferedPanel();
            this._smileyPanel = new GDIPlus_Demo_2.DoubleBufferedPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rotationTrackbar = new System.Windows.Forms.TrackBar();
            this._sizeSlider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new GDIPlus_Demo_2.DoubleBufferedPanel();
            this._transparencyPanel = new GDIPlus_Demo_2.DoubleBufferedPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trasnparencySlider = new System.Windows.Forms.TrackBar();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.panel5 = new GDIPlus_Demo_2.DoubleBufferedPanel();
            this._splinesPanel = new GDIPlus_Demo_2.DoubleBufferedPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tensionSlider = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sizeSlider)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trasnparencySlider)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tensionSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1164, 406);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // selectImageFileDialog
            // 
            this._selectImageFileDialog.Filter = "JPG Files|*.jpg|GIF Files|*.gif|BMP Files|*.pmb|PNG Files|*.png|All Files|*.*";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._smileyPanel);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(382, 400);
            this.panel1.TabIndex = 0;
            // 
            // _smileyPanel
            // 
            this._smileyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._smileyPanel.Location = new System.Drawing.Point(2, 2);
            this._smileyPanel.Name = "_smileyPanel";
            this._smileyPanel.Size = new System.Drawing.Size(376, 322);
            this._smileyPanel.TabIndex = 3;
            this._smileyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.smileyPanelPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rotationTrackbar);
            this.groupBox1.Controls.Add(this._sizeSlider);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(2, 324);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 72);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // rotationTrackbar
            // 
            this.rotationTrackbar.LargeChange = 10;
            this.rotationTrackbar.Location = new System.Drawing.Point(71, 48);
            this.rotationTrackbar.Maximum = 360;
            this.rotationTrackbar.Name = "rotationTrackbar";
            this.rotationTrackbar.Size = new System.Drawing.Size(177, 45);
            this.rotationTrackbar.SmallChange = 5;
            this.rotationTrackbar.TabIndex = 3;
            this.rotationTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rotationTrackbar.Scroll += new System.EventHandler(this.rotationTrackbar_Scroll);
            // 
            // sizeSlider
            // 
            this._sizeSlider.LargeChange = 20;
            this._sizeSlider.Location = new System.Drawing.Point(71, 24);
            this._sizeSlider.Maximum = 400;
            this._sizeSlider.Minimum = 50;
            this._sizeSlider.Name = "_sizeSlider";
            this._sizeSlider.Size = new System.Drawing.Size(177, 45);
            this._sizeSlider.SmallChange = 10;
            this._sizeSlider.TabIndex = 2;
            this._sizeSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this._sizeSlider.Value = 50;
            this._sizeSlider.Scroll += new System.EventHandler(this.sizeSlider_Scroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Size";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rotation";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this._transparencyPanel);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(391, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 400);
            this.panel2.TabIndex = 1;
            // 
            // _transparencyPanel
            // 
            this._transparencyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._transparencyPanel.Location = new System.Drawing.Point(0, 0);
            this._transparencyPanel.Name = "_transparencyPanel";
            this._transparencyPanel.Size = new System.Drawing.Size(380, 323);
            this._transparencyPanel.TabIndex = 1;
            this._transparencyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.transparencyPanelPaint);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.trasnparencySlider);
            this.groupBox2.Controls.Add(this.selectImageButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transparency";
            // 
            // trasnparencySlider
            // 
            this.trasnparencySlider.Location = new System.Drawing.Point(107, 49);
            this.trasnparencySlider.Maximum = 100;
            this.trasnparencySlider.Name = "trasnparencySlider";
            this.trasnparencySlider.Size = new System.Drawing.Size(171, 45);
            this.trasnparencySlider.TabIndex = 1;
            this.trasnparencySlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trasnparencySlider.Value = 50;
            this.trasnparencySlider.Scroll += new System.EventHandler(this.trasnparencySlider_Scroll);
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(6, 14);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(100, 23);
            this.selectImageButton.TabIndex = 0;
            this.selectImageButton.Text = "Load Image...";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this._splinesPanel);
            this.panel5.Controls.Add(this.groupBox3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(779, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(382, 400);
            this.panel5.TabIndex = 2;
            // 
            // splinesPanel
            // 
            this._splinesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._splinesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splinesPanel.Location = new System.Drawing.Point(0, 0);
            this._splinesPanel.Name = "_splinesPanel";
            this._splinesPanel.Size = new System.Drawing.Size(382, 324);
            this._splinesPanel.TabIndex = 1;
            this._splinesPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.splinesPanelPaint);
            this._splinesPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel6_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clearButton);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tensionSlider);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(382, 76);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(282, 25);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 2;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tension";
            // 
            // tensionSlider
            // 
            this.tensionSlider.Location = new System.Drawing.Point(57, 25);
            this.tensionSlider.Maximum = 100;
            this.tensionSlider.Name = "tensionSlider";
            this.tensionSlider.Size = new System.Drawing.Size(219, 45);
            this.tensionSlider.TabIndex = 0;
            this.tensionSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tensionSlider.Scroll += new System.EventHandler(this.tensionSlider_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 406);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sizeSlider)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trasnparencySlider)).EndInit();
            this.panel5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tensionSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DoubleBufferedPanel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar _sizeSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar rotationTrackbar;
        private DoubleBufferedPanel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private DoubleBufferedPanel _smileyPanel;
        private System.Windows.Forms.Button selectImageButton;
        private System.Windows.Forms.OpenFileDialog _selectImageFileDialog;
        private System.Windows.Forms.TrackBar trasnparencySlider;
        private DoubleBufferedPanel _transparencyPanel;
        private System.Windows.Forms.Label label3;
        private DoubleBufferedPanel panel5;
        private DoubleBufferedPanel _splinesPanel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tensionSlider;
    }
}

