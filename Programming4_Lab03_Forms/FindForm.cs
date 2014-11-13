using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Programming4_Lab03_Forms
{
    public partial class FindForm : Form
    {
        private Func<string> contentsGetter;
        private Action<int, int> selectionChanger;

        private int currSearchIndex = 0;

        public FindForm(Func<string> contentsGetter, Action<int, int> selectionChanger)
        {
            this.contentsGetter = contentsGetter;
            this.selectionChanger = selectionChanger;
            this.currSearchIndex = 0;

            //CollapsableGroupBox ec = new CollapsableGroupBox();

            //this.Controls.Add(ec);

            InitializeComponent();
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            string str = contentsGetter();
            string query = textBoxQuery.Text;
            int index = -1;
            int len = query.Length;

            if (currSearchIndex >= str.Length)
                currSearchIndex = 0;

            if (!checkBoxSensitive.Checked)
            {
                str = str.ToLower();
                query = query.ToLower();
            }

            if(!checkBoxRegEx.Checked)
                index = str.IndexOf(query, currSearchIndex);
            else
            {
                try
                {
                    string currStr = str.Substring(currSearchIndex);
                    if (Regex.IsMatch(currStr, query))
                    {
                        Match m = Regex.Match(currStr, query);
                        index = m.Index;
                        len = m.Length;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("...that your regular expression is not correct?","Did you know...", MessageBoxButtons.YesNo);
                }
            }

            if (index < 0)
            {
                currSearchIndex = 0;
                selectionChanger(0, 0);
                return;
            }
            currSearchIndex = index + 1;
            selectionChanger(index, len);
        }

        private void collapsableGroupBox1_CollapsedChanged()
        {
            int delta = collapsableGroupBox1.UnCollapsedHeight - collapsableGroupBox1.CollapsedHeight;
            if (collapsableGroupBox1.IsCollapsed)
            {
                checkBoxRegEx.Visible = false;
                checkBoxSensitive.Visible = false;
                this.Height -= delta;
            }
            else
            {
                checkBoxRegEx.Visible = true;
                checkBoxSensitive.Visible = true;
                this.Height += delta;
            }
        }
    }
}
