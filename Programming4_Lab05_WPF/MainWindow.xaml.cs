using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Threading;
using System.Windows.Threading;

namespace Programming4_Lab05_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private int size = 5;
        public int BoardSize
        {
            get { return size; }
            set
            {
                if (size == value)
                    return;
                size = value;

                this.resetBoard();
                this.LifeEnabled = false;
            }
        }

        private Boolean life = false;
        public Boolean LifeEnabled
        {
            get { return life; }
            set
            {
                if (life == value)
                    return;
                life = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("LifeEnabled"));
                if (life) this.startLife();
            }
        }

        private ObservableCollection<Rectangle> r = new ObservableCollection<Rectangle>();
        public ObservableCollection<Rectangle> Rectangles
        { get { return r; } }

        private Thread t = null;
        private const int MaxCellLevel = 17;
        private int sleep = 100;

        public delegate void MethodInvoker();
        public delegate void rectanglesSetter(ObservableCollection<Rectangle> re);
        public delegate ObservableCollection<Rectangle> rectanglesGetter();

        private void startLife()
        {
            t = new Thread(gameOfLife);
            t.Start();
        }

        private bool arraysDiffer(int[,] a, int[,] b, int size)
        {
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    if ((a[x, y] == 0 && b[x, y] != 0) || (b[x, y] == 0 && a[x, y] != 0)) return true;
            return false;
        }

        private int countAliveNeighbours(int[,] board, int x, int y, int size)
        {
            int counter = 0;
            if (x > 0)
            {
                if (board[x - 1, y] > 0) counter++;
                if (y > 0 && board[x - 1, y - 1] > 0) counter++;
                if (y < size - 1 && board[x - 1, y + 1] > 0) counter++;
            }
            if (x < size - 1)
            {
                if (board[x + 1, y] > 0) counter++;
                if (y > 0 && board[x + 1, y - 1] > 0) counter++;
                if (y < size - 1 && board[x + 1, y + 1] > 0) counter++;
            }
            if (y > 0 && board[x, y - 1] > 0) counter++;
            if (y < size - 1 && board[x, y + 1] > 0) counter++;
            return counter;
        }

        private void gameOfLife()
        {
            Boolean changes = true; // were there any changes in the last lifecycle?
            int[,] newBoard = null, board = null, oldBoard = null;
            int size = 0;

            while (changes)
            {
                if (BoardSize != size)
                {
                    // first loop
                    size = BoardSize;
                    oldBoard = new int[size, size];
                    board = new int[size, size];
                    newBoard = new int[size, size];
                }
                else
                {
                    // other loops
                    for (int y = 0; y < size; y++)
                        for (int x = 0; x < size; x++)
                            oldBoard[x, y] = board[x, y];
                }

                // copy the data
                bool done1 = false;
                this.Dispatcher.BeginInvoke(DispatcherPriority.Send,
                    (Action)(() =>
                    {
                        //Rectangle[] rects = this.r.ToArray();
                        int i = 0;
                        for (int y = 0; y < size; y++)
                            for (int x = 0; x < size; x++)
                            {
                                if (!LifeEnabled) break;
                                board[x, y] = (int)Rectangles.ElementAt(i).Tag;
                                i++;
                            }
                        done1 = true;
                    }));
                Thread.Sleep(10);
                while (!done1)
                    Thread.Sleep(10);

                // who's gonna live, who's gonna die?
                for (int y = 0; y < size; y++)
                    for (int x = 0; x < size; x++)
                    {
                        if (!LifeEnabled) break;
                        int aliveNeighbours = countAliveNeighbours(board, x, y, size);

                        if ((board[x, y] > 0 && (aliveNeighbours == 2 || aliveNeighbours == 3))
                                || (board[x, y] == 0 && aliveNeighbours == 3))
                            newBoard[x, y] = board[x, y] + (board[x, y] == MaxCellLevel ? 0 : 1);
                        else
                            newBoard[x, y] = 0;
                    }

                bool done2 = false;
                this.Dispatcher.BeginInvoke(DispatcherPriority.Send,
                    (Action)(() =>
                    {
                        int i = 0;
                        for (int y = 0; y < size; y++)
                            for (int x = 0; x < size; x++)
                            {
                                if (!LifeEnabled) break;
                                Rectangles.ElementAt(i).Tag = (Int32)newBoard[x, y];
                                i++;
                            }
                        done2 = true;
                    }));

                Thread.Sleep(10);
                while (!done2)
                    Thread.Sleep(10);

                //standing still equals death
                if (!LifeEnabled || !arraysDiffer(board, newBoard, size))
                    changes = false;
            }
            LifeEnabled = false;
        }

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            this.resetBoard();
        }

        public void resetBoard()
        {
            LifeEnabled = false;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("LifeEnabled"));

            if (Rectangles.Count > 0)
                Rectangles.Clear();

            int size = BoardSize, size2 = size * size;
            for (int i = 0; i < size2; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Tag = (Int32)0;
                rect.MouseDown += new MouseButtonEventHandler(rectangleClicked);
                Rectangles.Add(rect);
            }

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Rectangles"));
        }

        private void rectangleClicked(object sender, EventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            if ((Int32)r.Tag == 0)
                r.Tag = (Int32)1;
            else
                r.Tag = (Int32)0;
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }


}
