namespace Programming4_Lab02_Forms
{
    partial class NewGameForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.checkPlayerStarts = new System.Windows.Forms.CheckBox();
            this.numericBoardWinLen = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericBoardHeight = new System.Windows.Forms.NumericUpDown();
            this.numericBoardWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoardWinLen)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoardHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoardWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Line length:";
            // 
            // checkPlayerStarts
            // 
            this.checkPlayerStarts.AutoSize = true;
            this.checkPlayerStarts.Location = new System.Drawing.Point(12, 141);
            this.checkPlayerStarts.Name = "checkPlayerStarts";
            this.checkPlayerStarts.Size = new System.Drawing.Size(82, 17);
            this.checkPlayerStarts.TabIndex = 13;
            this.checkPlayerStarts.Text = "player starts";
            this.checkPlayerStarts.UseVisualStyleBackColor = true;
            this.checkPlayerStarts.CheckedChanged += new System.EventHandler(this.checkPlayerStarts_CheckedChanged);
            // 
            // numericBoardWinLen
            // 
            this.numericBoardWinLen.Location = new System.Drawing.Point(76, 106);
            this.numericBoardWinLen.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericBoardWinLen.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBoardWinLen.Name = "numericBoardWinLen";
            this.numericBoardWinLen.Size = new System.Drawing.Size(41, 20);
            this.numericBoardWinLen.TabIndex = 12;
            this.numericBoardWinLen.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBoardWinLen.ValueChanged += new System.EventHandler(this.numericBoardWinLen_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericBoardHeight);
            this.groupBox1.Controls.Add(this.numericBoardWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 83);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Board size";
            // 
            // numericBoardHeight
            // 
            this.numericBoardHeight.Location = new System.Drawing.Point(64, 50);
            this.numericBoardHeight.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericBoardHeight.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBoardHeight.Name = "numericBoardHeight";
            this.numericBoardHeight.Size = new System.Drawing.Size(41, 20);
            this.numericBoardHeight.TabIndex = 14;
            this.numericBoardHeight.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBoardHeight.ValueChanged += new System.EventHandler(this.numericBoardHeight_ValueChanged);
            // 
            // numericBoardWidth
            // 
            this.numericBoardWidth.Location = new System.Drawing.Point(64, 19);
            this.numericBoardWidth.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericBoardWidth.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBoardWidth.Name = "numericBoardWidth";
            this.numericBoardWidth.Size = new System.Drawing.Size(41, 20);
            this.numericBoardWidth.TabIndex = 13;
            this.numericBoardWidth.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericBoardWidth.ValueChanged += new System.EventHandler(this.numericBoardWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Width:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(207, 141);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(207, 112);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 9;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "tic tac toe 3x3",
            "tic tac toe 4x4",
            "gomoku small",
            "gomoku"});
            this.comboBox1.Location = new System.Drawing.Point(151, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Predefined settings:";
            // 
            // NewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 176);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkPlayerStarts);
            this.Controls.Add(this.numericBoardWinLen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewGameForm";
            this.Text = "New game options";
            ((System.ComponentModel.ISupportInitialize)(this.numericBoardWinLen)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoardHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericBoardWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkPlayerStarts;
        private System.Windows.Forms.NumericUpDown numericBoardWinLen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.NumericUpDown numericBoardHeight;
        private System.Windows.Forms.NumericUpDown numericBoardWidth;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}