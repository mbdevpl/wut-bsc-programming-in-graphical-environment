using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Programming4_Lab02_Forms
{
    public partial class NewGameForm : Form
    {
        public bool playerStarts;
        public int boardWidth, boardHeight, boardWinLen;

        public NewGameForm(bool playerStarts, int boardWidth, int boardHeight, int boardWinLen)
        {
            this.playerStarts = playerStarts;
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            this.boardWinLen = boardWinLen;

            InitializeComponent();

            checkPlayerStarts.Checked = playerStarts;
            numericBoardWidth.Value = (Decimal)boardWidth;
            numericBoardHeight.Value = (Decimal)boardHeight;
            numericBoardWinLen.Value = (Decimal)boardWinLen;
        }

        private void checkPlayerStarts_CheckedChanged(object sender, EventArgs e)
        {
            playerStarts = checkPlayerStarts.Checked;
        }

        private void numericBoardWidth_ValueChanged(object sender, EventArgs e)
        {
            boardWidth = (int)numericBoardWidth.Value;
        }

        private void numericBoardHeight_ValueChanged(object sender, EventArgs e)
        {
            boardHeight = (int)numericBoardHeight.Value;
        }

        private void numericBoardWinLen_ValueChanged(object sender, EventArgs e)
        {
            boardWinLen = (int)numericBoardWinLen.Value;
        }

        private void allValuesChanged(object sender, EventArgs e)
        {
            checkPlayerStarts_CheckedChanged(sender, e);
            numericBoardWidth_ValueChanged(sender, e);
            numericBoardWinLen_ValueChanged(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                numericBoardWidth.Value = 3;
                numericBoardHeight.Value = 3;
                numericBoardWinLen.Value = 3;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                numericBoardWidth.Value = 4;
                numericBoardHeight.Value = 4;
                numericBoardWinLen.Value = 4;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                numericBoardWidth.Value = 6;
                numericBoardHeight.Value = 6;
                numericBoardWinLen.Value = 4;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                numericBoardWidth.Value = 10;
                numericBoardHeight.Value = 10;
                numericBoardWinLen.Value = 4;
            }

            allValuesChanged(sender, e);
        }
    }
}
