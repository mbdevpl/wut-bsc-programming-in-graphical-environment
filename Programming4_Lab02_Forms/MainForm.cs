using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Collections;
using System.Reflection;
using System.IO;

namespace Programming4_Lab02_Forms
{
    public partial class MainForm : Form
    {
        public bool crossFirst = false;

        public static Image xImg = null;
        public static Image oImg = null;

        private PictureBox[,] board;
        private bool playerStarts = true;
        private int boardWidth = 3, boardHeight = 3, boardWinLen = 3;

        private volatile bool playersTurn = false;
        private volatile int counter = 0;
        private volatile int currAiTimeout = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            xImg = new Bitmap(Properties.Resources.x);
            oImg = new Bitmap(Properties.Resources.o);
            gameTimerLabel.Text = "";
            
            initBoard();
        }

        private void initBoard()
        {
            board = new PictureBox[boardWidth, boardHeight];
            boardPanel.Controls.Clear();

            boardPanel.ColumnCount = boardWidth;
            boardPanel.RowCount = boardHeight;

            int colWidth = (boardPanel.Width - boardWidth * (boardPanel.Margin.Left
                + boardPanel.Margin.Right + 2)) / boardWidth;
            int rowHeight = (boardPanel.Height - boardHeight * (boardPanel.Margin.Top
                + boardPanel.Margin.Bottom + 2)) / boardHeight;
            float colPerc = colWidth / boardPanel.Width;
            float rowPerc = rowHeight / boardPanel.Height;

            foreach (ColumnStyle style in boardPanel.ColumnStyles)
            {
                style.SizeType = SizeType.Percent;
                style.Width = colPerc;
                //style.SizeType = SizeType.Absolute;
                //style.Width = 50;
            }

            foreach (RowStyle style in boardPanel.RowStyles)
            {
                style.SizeType = SizeType.Percent;
                style.Height = rowPerc;
                //style.SizeType = SizeType.Absolute;
                //style.Height = 50;
            }

            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    board[x, y] = new PictureBox();
                    //board[x, y].Anchor = (AnchorStyles.Left | AnchorStyles.Top
                    //    | AnchorStyles.Right | AnchorStyles.Bottom);
                    board[x, y].Width = colWidth;
                    board[x, y].Height = rowHeight;
                    board[x, y].SizeMode = PictureBoxSizeMode.StretchImage;

                    board[x, y].BackColor = Color.White;
                    board[x, y].Image = null;
                    //board[x, y].Click += new EventHandler(box_Click);

                    boardPanel.Controls.Add(board[x, y], x, y);
                }
            }
        }

        private bool performEndOfTurnChecks(Board b)
        {
            if (b == null || Ttt.gameOver(b))
            {
                char winner = ' ';
                if (b != null)
                    winner = Ttt.winner(b);
                else
                {
                    if ((crossFirst && playerStarts) || (!crossFirst && !playerStarts))
                        winner = 'o';
                    else
                        winner = 'x';
                }
                string msg, shortmsg;

                if (winner == ' ')
                {
                    msg = "What a duel! However, it ended with a draw.";
                    shortmsg = "draw";
                }
                else if ((crossFirst && (winner == 'x' && playerStarts || winner == 'o' && !playerStarts))
                       || (!crossFirst && (winner == 'x' && !playerStarts || winner == 'o' && playerStarts)))
                {
                    msg = "Congratz to the true mastermind, you've beaten the pseudo-random number generator"
                        + " implemented by Microsoft! Awesome indeed!";
                    if ((crossFirst && playerStarts) || (!crossFirst && !playerStarts))
                        shortmsg = "x (player) won";
                    else
                        shortmsg = "o (player) won";
                }
                else
                {
                    msg = "It seems that you have lost.";
                    if ((crossFirst && playerStarts) || (!crossFirst && !playerStarts))
                        shortmsg = "o (AI) won";
                    else
                        shortmsg = "x (AI) won";
                }

                statusLabel.Text = "Game over, " + shortmsg + ".";

                TreeNode n = gameHistoryTree.Nodes[0];
                TreeNode node = n.Nodes[n.Nodes.Count - 1];
                n.Expand();
                node.Nodes.Add(shortmsg);
                node.Expand();

                MessageBox.Show(this, msg, "Game over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                playersTurn = false;
                return false;
            }
            else
            {
                //staying alive...
                statusLabel.Text = "Your move!";
                playersTurn = true;
                return true;
            }
        }

        private void performAiActions()
        {
            playersTurn = false;
            statusLabel.Text = "Do not disturb...";
            currAiTimeout = new Random().Next() % 3 + 1;
            startTimer();
        }

        private void updatePictureBox(PictureBox box, char symbol)
        {
            bool broken = false;
            TreeNode node;
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                    if (board[x, y] == box)
                    {
                        TreeNode n = gameHistoryTree.Nodes[0];
                        node = n.Nodes[n.Nodes.Count - 1];

                        n.Expand();
                        node.Nodes.Add(symbol + " - (" + x + "," + y + ")");
                        node.Expand();

                        broken = true;
                        break;
                    }
                if (broken) break;
            }

            if (symbol == 'x')
                box.Image = xImg;
            else
                box.Image = oImg;
        }

        private void box_Click(object sender, EventArgs e)
        {
            if (playersTurn)
            {
                PictureBox box = (PictureBox)sender;
                if (box.Image == null)
                {
                    playersTurn = false;
                    stopTimer();

                    char symbol = ' ';
                    if ((crossFirst && playerStarts) || (!crossFirst && !playerStarts))
                        symbol = 'x';
                    else
                        symbol = 'o';

                    updatePictureBox(box, symbol);

                    Board b = new Board(board, this.boardWinLen);
                    if(performEndOfTurnChecks(b))
                        performAiActions();
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGameForm options = new NewGameForm(playerStarts, boardWidth, boardHeight, boardWinLen);

            if (options.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                playerStarts = options.playerStarts;
                boardWidth = options.boardWidth;
                boardHeight = options.boardHeight;
                boardWinLen = options.boardWinLen;

                this.playAgainToolStripMenuItem.Enabled = true;
                playAgainToolStripMenuItem_Click(sender, e);
            }
        }

        private void playAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initBoard();

            for (int x = 0; x < boardWidth; x++)
                for (int y = 0; y < boardHeight; y++)
                    board[x, y].Click += new EventHandler(box_Click);

            playersTurn = playerStarts;

            //expand current tree node
            TreeNode n = gameHistoryTree.Nodes[0];
            n.Nodes.Add(this.ToString());
            n.Expand();
            n.Nodes[n.Nodes.Count - 1].Expand();

            //initial ai if player doesn't start
            if (!playersTurn)
                performAiActions();
            else
            {
                startTimer();
                statusLabel.Text = "Your move!";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCollapse_Click(object sender, EventArgs e)
        {
            foreach(TreeNode n in gameHistoryTree.Nodes[0].Nodes) {
                n.Collapse();
            }
        }

        override public string ToString()
        {
            return "game [board " + this.boardWidth + "x" + boardHeight + ", line " + boardWinLen + "] - "
                + DateTime.Now.ToShortTimeString();
        }

        private void startTimer()
        {
            counter = 0;
            gameTimer.Start();
            gameTimerLabel.Text = "10 seconds remaining...";
        }

        private void stopTimer()
        {
            counter = 0;
            gameTimer.Stop();
            gameTimerLabel.Text = "";
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            gameTimerLabel.Text = (10 - counter) + " seconds remaining...";

            if (!playersTurn && counter >= currAiTimeout)
            {
                stopTimer();

                Board b = new Board(board, boardWinLen);
                //Hi, I'm a tic-tac-ro-bot
                int[] ai = Ttt.getAiMove(b);
                //robot dies, what a pity
                if (ai != null)
                {
                    if ((crossFirst && playerStarts) || (!crossFirst && !playerStarts))
                        updatePictureBox(board[ai[0], ai[1]], 'o');
                    else
                        updatePictureBox(board[ai[0], ai[1]], 'x');
                }
                //warning, this funny game may soon end!
                if (performEndOfTurnChecks(b))
                {
                    startTimer();
                    playersTurn = true;
                }
            }
            else if (playersTurn && counter >= 10)
            {
                stopTimer();
                playersTurn = false;
                performEndOfTurnChecks(null);
            }

        }
    }
}
