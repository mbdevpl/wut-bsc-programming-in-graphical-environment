using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Programming4_Lab02_Forms
{
    class Board
    {
        private int width, height, winLen;
        private PictureBox[,] data;

        public Board(PictureBox[,] src, int winLen) {
            width = src.GetLength(0);
            height = src.GetLength(1);
            this.winLen = winLen;
            data = src;
        }

        public char elementAt(int x, int y) {
            if (data[x, y].Image == null)
                return ' ';
            else if (data[x, y].Image.Equals(MainForm.xImg))
                return 'x';
            else if (data[x, y].Image.Equals(MainForm.oImg))
                return 'o';

            return '?';
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public int getWinLen()
        {
            return winLen;
        }

    }

    class Ttt
    {
        /**
	     * Determines if a given board is full.
	     * @param b a given board
	     * @return true if every field of the board is nonempty, false otherwise
	     */
        public static bool isFull(Board b)
        {
            for (int x = 0; x < b.getWidth(); x++)
                for (int y = 0; y < b.getHeight(); y++)
                {
                    if (b.elementAt(x, y) == ' ') return false;
                }
            return true;
        }

        public static bool gameOver(Board b)
        {
            if (!(winner(b) == ' ') || isFull(b))
                return true;
            return false;
        }

        public static char winner(Board b)
        {
            //checking both players, starting with 'x'
            for (int pl = 1; pl <= 2; pl++)
            {
                char currField = (pl == 1 ? 'x' : 'o');
                bool over = false; //is the game over because someone won?

                //checking vertical lines
                for (int x = 0; x < b.getWidth(); x++)
                    for (int y = 0; y < b.getHeight() - b.getWinLen() + 1; y++)
                    {
                        over = true;
                        for (int z = 0; z < b.getWinLen(); z++)
                            if (b.elementAt(x, y + z) != currField) over = false;
                        if (over) return currField;
                    }

                //checking horizontal lines
                for (int x = 0; x < b.getWidth() - b.getWinLen() + 1; x++)
                    for (int y = 0; y < b.getHeight(); y++)
                    {
                        over = true;
                        for (int z = 0; z < b.getWinLen(); z++)
                            if (b.elementAt(x + z, y) != currField) over = false;
                        if (over) return currField;
                    }

                //checking (x,x) diagonals
                for (int x = 0; x < b.getWidth() - b.getWinLen() + 1; x++)
                    for (int y = 0; y < b.getHeight() - b.getWinLen() + 1; y++)
                    {
                        over = true;
                        for (int z = 0; z < b.getWinLen(); z++)
                            if (b.elementAt(x + z, y + z) != currField) over = false;
                        if (over) return currField;
                    }


                //checking (x,-x) diagonals
                for (int x = b.getWinLen() - 1; x < b.getWidth(); x++)
                    for (int y = 0; y < b.getHeight() - b.getWinLen() + 1; y++)
                    {
                        over = true;
                        for (int z = 0; z < b.getWinLen(); z++)
                            if (b.elementAt(x - z, y + z) != currField) over = false;
                        if (over) return currField;
                    }
            }

            return ' ';
        }

        public static int[] getAiMove(Board b)
        {
            int[] returned = new int[2];

            for (int i = 1; i < 5; i++)
            {
                Random r = new Random();
                int x = r.Next() % b.getWidth(), y = r.Next() % b.getHeight();

                if (b.elementAt(x, y) == ' ')
                {
                    returned[0] = x;
                    returned[1] = y;
                    return returned;
                }
            }

            for (int x = 0; x < b.getWidth(); x++)
                for (int y = 0; y < b.getHeight(); y++)
                    if (b.elementAt(x, y) == ' ')
                    {
                        returned[0] = x;
                        returned[1] = y;
                        return returned;
                    }

            return null;
        }
    }
}
