using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Windows.Markup;

namespace Programming4_Lab04pl_WPF
{
	public sealed class TttField : Button
	{
		public TttField(Boolean black)
		{
			if (black)
				this.Background = Brushes.Black;
			else
				this.Background = Brushes.White;
		}
	}

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//private Ellipse redEllipse, blueEllipse;
		//private Rectangle blackRect, whiteRect;
		private TttField[,] handlers = null;
		private Rectangle[,] rects = null;
		private Ellipse[,] pieces = null;

		private int index;
		private int[] sizes;
		private int turn;
		private bool redStarted;

		//private FrameworkElement Clone(FrameworkElement e)
		//{
		//    XmlDocument document = new XmlDocument();
		//    document.LoadXml(XamlWriter.Save(e));

		//    return (FrameworkElement)XamlReader.Load(new XmlNodeReader(document));
		//}

		public MainWindow()
		{
			//redEllipse = new Ellipse();
			//blueEllipse = new Ellipse();
			
			//blackRect = new Rectangle();
			//blackRect.Fill = Brushes.Black;
			//whiteRect = new Rectangle();
			//blackRect.Fill = Brushes.White;

			index = -1;
			sizes = new int[3]; //{3, 5, 9};
			sizes[0] = 3;
			sizes[1] = 5;
			sizes[2] = 9;
			turn = -1;
			redStarted = false;

			InitializeComponent();
		}

		private void optionNew_Click(object sender, RoutedEventArgs e)
		{
			radio3x3.IsChecked = true;
			buttonConfirm_Click(sender, e);
		}

		private void optionExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void Rect_MouseDown(Object sender, MouseButtonEventArgs e)
		{
			if (turn < 0) return;
			if (sender.GetType() == typeof(Ellipse))
			{
				MessageBox.Show("You can't place a piece on another piece.", "Sorry, pal...");
				return;
			}
			Rectangle rect = (Rectangle)sender;
			int x = Grid.GetColumn(rect);
			int y = Grid.GetRow(rect);
			if (pieces[x, y] != null)
			{
				MessageBox.Show("There is a piece on this field already.", "Sorry, pal...");
				return;
			}

			pieces[x, y] = new Ellipse();
			pieces[x, y].Fill = (turn == 0 ? Brushes.Red : Brushes.Blue);
			gridBoard.Children.Add(pieces[x, y]);
			Grid.SetColumn(pieces[x, y], x);
			Grid.SetRow(pieces[x, y], y);
			//I don't need no handlers, it's a kind of magic!
			//pieces[x, y].MouseDown += Rect_MouseDown;
			//pieces[x, y].MouseEnter += Ellipse_MouseEnter;
			//pieces[x, y].MouseLeave += Ellipse_MouseLeave;

			turn = (turn + 1) % 2;
		}

		//private void Ellipse_MouseEnter(Object sender, MouseEventArgs e)
		//{
		//    //Ellipse el = (Ellipse)sender;
		//    ////el.Style = (Style)this.Resources.FindName("transparent");
		//    //el.Style = new Style(typeof(Ellipse), (Style)this.Resources.FindName("transparent"));
		//    ////Ellipse el = (Ellipse)sender;
		//    ////Color c = new Color();
		//    ////c = ((SolidColorBrush)el.Fill).Color;
		//    ////c.A = 128;
		//    ////el.Fill = new SolidColorBrush(c);
		//    //el.op
		//}

		//private void Ellipse_MouseLeave(Object sender, MouseEventArgs e)
		//{
		//    //Ellipse el = (Ellipse)sender;
		//    //Color c = new Color();
		//    //c = ((SolidColorBrush)el.Fill).Color;
		//    //c.A = 255;
		//    //el.Fill = new SolidColorBrush(c);
		//}

		private void buttonConfirm_Click(object sender, RoutedEventArgs e)
		{
			if ((bool)radio3x3.IsChecked) index = 0;
			if ((bool)radio5x5.IsChecked) index = 1;
			if ((bool)radio9x9.IsChecked) index = 2;

			if(index < 0) return;
			int newsize = sizes[index];
			turn = (redStarted ? 1 : 0);
			if (redStarted) redStarted = false;
			else redStarted = true;

			gridBoard.ColumnDefinitions.Clear();
			gridBoard.RowDefinitions.Clear();
			for (int i = 0; i < newsize; i++)
			{
				gridBoard.ColumnDefinitions.Add(new ColumnDefinition());
				gridBoard.RowDefinitions.Add(new RowDefinition());
			}

			rects = null;
			rects = new Rectangle[newsize, newsize];
			pieces = null;
			pieces = new Ellipse[newsize, newsize];
			handlers = null;
			handlers = new TttField[newsize, newsize];
			for (int x = 0; x < newsize; x++)
			{
				for (int y = 0; y < newsize; y++)
				{
					rects[x, y] = new Rectangle();
					rects[x, y].Fill = ((x + y) % 2 == 0 ? Brushes.White.Clone() : Brushes.Black.Clone());

					handlers[x, y] = new TttField((x + y) % 2 == 0);
					handlers[x, y].MouseDown += Rect_MouseDown;

					gridBoard.Children.Add(handlers[x, y]);
					Grid.SetColumn(handlers[x, y], x);
					Grid.SetRow(handlers[x, y], y);

					handlers[x, y].Content = rects[x, y];

					//MessageBox.Show(rects[x, y].Fill.ToString(), "My coat of many colours...");
				}
			}
		}

		private void buttonChangeNames_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
