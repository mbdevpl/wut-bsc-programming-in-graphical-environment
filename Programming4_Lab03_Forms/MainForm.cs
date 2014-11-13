using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Programming4_Lab03_Forms
{
    public partial class MainForm : Form
    {
        private string[] knownColors;
        private Color[] allColors;
        private FontFamily[] allFontFamilies;
        private Font[] allFonts;

        public MainForm()
        {
            //colors
            knownColors = System.Enum.GetNames(typeof(System.Drawing.KnownColor));
            allColors = knownColors.Select(x => Color.FromName(x)).ToArray();

            //fonts
            allFontFamilies = FontFamily.Families;
            allFonts = new Font[allFontFamilies.Length];
            for(int i = 0; i < allFonts.Length; i++) {
                if (allFontFamilies[i].IsStyleAvailable(FontStyle.Regular))
                    allFonts[i] = new Font(allFontFamilies[i], 12, FontStyle.Regular);
                else if (allFontFamilies[i].IsStyleAvailable(FontStyle.Bold))
                    allFonts[i] = new Font(allFontFamilies[i], 12, FontStyle.Bold);
                else if (allFontFamilies[i].IsStyleAvailable(FontStyle.Italic))
                    allFonts[i] = new Font(allFontFamilies[i], 12, FontStyle.Italic);
                else
                    allFonts[i] = SystemFonts.DefaultFont;
            }


            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach(Color c in allColors)
                comboColors.Items.Add(c.Name);

            foreach (Font f in allFonts)
                comboFont.Items.Add(f.Name);
        }

        private void comboColors_DrawItem(object sender, DrawItemEventArgs e)
        {
            int i = e.Index;
            if (i < 0) return;

            int top = e.Bounds.Top;
            int h = e.Bounds.Height;
            Brush b = new SolidBrush(allColors[i]);
            Rectangle rect = new Rectangle(4, top + 1, 24, h - 3);

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            e.DrawBackground();
            if (e.State == DrawItemState.Focus)
                e.DrawFocusRectangle();
            e.Graphics.FillRectangle(b, rect);
            e.Graphics.DrawRectangle(Pens.Black, rect);
            e.Graphics.DrawString(allColors[i].Name, SystemFonts.DefaultFont, Brushes.Black, new PointF(30, top));
        }

        private void comboColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboColors.ForeColor = allColors[comboColors.SelectedIndex];

            textField.SelectionColor = comboColors.ForeColor;
        }

        private void comboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboFont.Font = allFonts[comboFont.SelectedIndex];

            textField.SelectionFont = comboFont.Font;
        }

        private void comboFont_DrawItem(object sender, DrawItemEventArgs e)
        {
            int i = e.Index;
            if (i < 0) return;

            int top = e.Bounds.Top;
            PointF p = new PointF(3, top);

            e.DrawBackground();
            if (e.State == DrawItemState.Focus)
                e.DrawFocusRectangle();
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            e.Graphics.DrawString(allFonts[i].Name, allFonts[i], Brushes.Black, p);
        }

        private void comboFont_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            int i = e.Index;
            if (i < 0) return;

            //Font f = allFonts[i];
            e.ItemHeight = (int)(e.Graphics.MeasureString(allFonts[i].Name, allFonts[i]).Height + 1);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                textField.SaveFile(filePath, RichTextBoxStreamType.RichText);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                textField.LoadFile(filePath, RichTextBoxStreamType.RichText);
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            FindForm ff = new FindForm(getContents, changeSelection);
            ff.Show();
        }

        public string getContents()
        {
            return textField.Text;
        }

        public void changeSelection(int beg, int length)
        {
            textField.SelectionStart = beg;
            textField.SelectionLength = length;
        }
    }
}
