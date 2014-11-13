using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CollapsableGroupBox
{
    public partial class CollapsableGroupBox : GroupBox
    {
        private string prefix = "";
        //private int prevH = 0;

        private bool collapsed = false;
        private int hExpanded = 98;
        private int hCollapsed = 20;

        [Category("Appearance")]
        [Description("This frackin' box needs a name")]
        public string GroupBoxText
        {
            get { return groupBox.Text.Substring(6); }
            set { groupBox.Text = prefix + value; }
        }

        [Category("Layout")]
        [Description("I don't even wanna look at this shiee")]
        public bool IsCollapsed
        {
            get { return collapsed; }
            set { collapsed = !value;
                collapsaeButton_Click(null, null); }
        }

        [Category("Layout")]
        [Description("Height when collapsed")]
        public int CollapsedHeight
        {
            get { return hCollapsed; }
            set {
                hCollapsed = value;
                if (collapsed) Height = value;
            }
        }

        [Category("Layout")]
        [Description("Height when expanded")]
        public int UnCollapsedHeight
        {
            get { return hExpanded; }
            set
            {
                hExpanded = value;
                if (!collapsed) Height = value;
            }
        }

        public delegate void SubmitClickedHandler();

        [Category("Action")]
        [Description("Fires when the Submit button is clicked.")]
        public event SubmitClickedHandler CollapsedChanged;

        public CollapsableGroupBox()
        {
            prefix = "      ";
            //if(IsCollapsed)
            //    hCollapsed = this.Height;
            //else
            //    hExpanded = this.Height;

            InitializeComponent();
        }

        private void collapsaeButton_Click(object sender, EventArgs e)
        {
            if (collapsed)
            {
                collapsed = false;
                collapseButton.Text = "-";
                this.Height = hExpanded;
            }
            else
            {
                collapsed = true;
                hExpanded = this.Height;
                this.Height = hCollapsed;
                collapseButton.Text = "+";
            }

            if (CollapsedChanged != null)
            {
                CollapsedChanged();
            }
        }
    }
}
