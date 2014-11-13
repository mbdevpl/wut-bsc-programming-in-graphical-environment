using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Programming4_Lab03pl_Forms
{
    public partial class MainForm : Form
    {
        public int recDepth = 1;
        public string fileTypes = "txt;pdf;bmp;jpg;png";

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderSelector.ShowDialog() == DialogResult.OK)
            {
                folderBox.Text = folderSelector.SelectedPath;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm(recDepth, fileTypes);

            if (settings.ShowDialog() == DialogResult.OK)
            {
                this.recDepth = settings.recDepth;
                this.fileTypes = settings.fileTypes;
            }
        }
    }
}
