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
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Microsoft.Windows.Controls;
using System.Windows.Markup;
using System.IO;
using System.Xml;

namespace Programming4_Lab06_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const String strTop = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla nulla erat, "
            + "porttitor non rhoncus quis, "
            + "viverra sit amet lorem. Curabitur porttitor mattis sodales. "
            + "Vestibulum sit amet urna at dolor placerat iaculis quis a mauris. "
            + "Aliquam in sollicitudin lorem. Nunc luctus elit vel sapien feugiat mattis sed et diam. In justo.";
        private TextBlock[] topArray;

        const String strBottom = "a b c d e f g h i j k l m n o p q r s t u v w x y z";
        private Button[] bottomArray;

        private DispatcherTimer dt;

        public MainWindow()
        {
            String[] strTopArray = strTop.Split(' ');
            topArray = new TextBlock[strTopArray.Length];
            for (int i = 0; i < strTopArray.Length; i++)
            {
                topArray[i] = new TextBlock();
                topArray[i].Text = strTopArray[i];
            }

            String[] strBottomArray = strBottom.Split(' ');
            bottomArray = new Button[strBottomArray.Length];
            for (int i = 0; i < strBottomArray.Length; i++)
            {
                bottomArray[i] = new Button();
                bottomArray[i].Content = strBottomArray[i];
            }

            InitializeComponent();

            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(50);
            dt.Tick += new EventHandler(dt_Tick);
            dt.IsEnabled = true;
        }

        public void dt_Tick(object sender, EventArgs e)
        {
            bool changed = false;
            if (topPanelSize.Value < 50)
            {
                topPanelSize.Value += 1;
                changed = true;
            }
            if (bottomPanelSize.Value < 6)
            {
                bottomPanelSize.Value += 1;
                changed = true;
            }

            if (!changed) dt.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Boolean active = (Boolean)b.Tag;
            if (!active) b.Tag = true;
        }

        private void topPanelElemsCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            panelElemsCount_ValueChanged(sender, e, topPanel.Children, topArray);
        }

        private void bottomPanelElemsCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            panelElemsCount_ValueChanged(sender, e, bottomPanel.Children, bottomArray);
        }

        private void panelElemsCount_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e,
            UIElementCollection c, FrameworkElement[] objArray)
        {
            DecimalUpDown d = (DecimalUpDown)sender;

            int Count = (int)d.Value;
            if (c.Count > Count)
            {
                int delNum = c.Count - Count;
                for (int i = 0; i < delNum; i++)
                {
                    c.RemoveAt(c.Count - 1);
                }
            }
            else if (c.Count < Count)
            {
                for (int i = c.Count; i < Count; i++)
                {
                    //c.Add(objArray[i % objArray.Length]);

                    string gridXaml = XamlWriter.Save(objArray[i % objArray.Length]);
                    StringReader stringReader = new StringReader(gridXaml);
                    XmlReader xmlReader = XmlReader.Create(stringReader);
                    c.Add((FrameworkElement)XamlReader.Load(xmlReader));
                }
            }
        }

    }

    public class AnimatedGrid : Grid
    {
        public double Duration
        {
            get { return (double)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(double), typeof(AnimatedGrid), new UIPropertyMetadata(500.0));

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size s = base.ArrangeOverride(finalSize);
            Point origin = new Point(0, 0);

            foreach (FrameworkElement el in InternalChildren)
            {
                Point p = el.TranslatePoint(origin, this);
                el.Arrange(new Rect(origin, new Point(el.ActualWidth + el.Margin.Left + el.Margin.Right,
                    el.ActualHeight + el.Margin.Top + el.Margin.Bottom) /*el.DesiredSize*/));

                //Console.Out.Write("(x=" + Math.Round(p.X).ToString() + ",y=" + Math.Round(p.Y).ToString() + ")");

                if (el.RenderTransform as TranslateTransform == null)
                {
                    TranslateTransform tt = new TranslateTransform();
                    el.RenderTransform = tt;
                }

                Point fp = this.TranslatePoint(p, el);

                DoubleAnimation aniX = new DoubleAnimation();
                aniX.To = fp.X;
                aniX.Duration = TimeSpan.FromMilliseconds(Duration);

                DoubleAnimation aniY = new DoubleAnimation();
                aniY.To = fp.Y;
                aniY.Duration = TimeSpan.FromMilliseconds(Duration);

                el.RenderTransform.BeginAnimation(TranslateTransform.XProperty, aniX);
                el.RenderTransform.BeginAnimation(TranslateTransform.YProperty, aniY);
            }
            //Console.Out.WriteLine();

            return s;
        }
    }

    public class AnimatedStackPanel : StackPanel
    {
        public double Duration
        {
            get { return (double)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(double), typeof(AnimatedStackPanel), new UIPropertyMetadata(500.0));

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size s = base.ArrangeOverride(finalSize);
            Point origin = new Point(0, 0);

            foreach (FrameworkElement el in InternalChildren)
            {
                Point p = el.TranslatePoint(origin, this);
                el.Arrange(new Rect(origin, new Point(el.ActualWidth + el.Margin.Left + el.Margin.Right,
                    el.ActualHeight + el.Margin.Top + el.Margin.Bottom) /*el.DesiredSize*/));

                //Console.Out.Write("(x=" + Math.Round(p.X).ToString() + ",y=" + Math.Round(p.Y).ToString() + ")");

                if (el.RenderTransform as TranslateTransform == null)
                {
                    TranslateTransform tt = new TranslateTransform();
                    el.RenderTransform = tt;
                }

                Point fp = this.TranslatePoint(p, el);

                DoubleAnimation aniX = new DoubleAnimation();
                aniX.To = fp.X;
                aniX.Duration = TimeSpan.FromMilliseconds(Duration);

                DoubleAnimation aniY = new DoubleAnimation();
                aniY.To = fp.Y;
                aniY.Duration = TimeSpan.FromMilliseconds(Duration);

                el.RenderTransform.BeginAnimation(TranslateTransform.XProperty, aniX);
                el.RenderTransform.BeginAnimation(TranslateTransform.YProperty, aniY);
            }
            //Console.Out.WriteLine();

            return s;
        }
    }

    public class AnimatedWrapPanel : WrapPanel
    {

        public double InternalMargin
        {
            get { return (double)GetValue(InternalMarginProperty); }
            set { SetValue(InternalMarginProperty, value); }
        }

        public static readonly DependencyProperty InternalMarginProperty =
            DependencyProperty.Register("InternalMargin", typeof(double), typeof(AnimatedWrapPanel), new UIPropertyMetadata(500.0));


        public double Duration
        {
            get { return (double)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(double), typeof(AnimatedWrapPanel), new UIPropertyMetadata(500.0));

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size s = base.ArrangeOverride(new Size(finalSize.Width /*+ InternalMargin*/, finalSize.Height/* + InternalMargin*/));
            Point origin = new Point(0, 0);

            foreach (FrameworkElement el in InternalChildren)
            {
                Point p = el.TranslatePoint(origin, this);
                el.Arrange(new Rect(origin, new Point(el.ActualWidth + el.Margin.Left + el.Margin.Right/* + InternalMargin*/,
                    el.ActualHeight + el.Margin.Top + el.Margin.Bottom /*+ InternalMargin*/) /*el.DesiredSize*/));

                //Console.Out.Write("(x=" + Math.Round(p.X).ToString() + ",y=" + Math.Round(p.Y).ToString() + ")");

                if (el.RenderTransform as TranslateTransform == null)
                {
                    TranslateTransform tt = new TranslateTransform();
                    el.RenderTransform = tt;
                }

                Point fp = this.TranslatePoint(p, el);

                DoubleAnimation aniX = new DoubleAnimation();
                aniX.To = fp.X;
                aniX.Duration = TimeSpan.FromMilliseconds(Duration);

                DoubleAnimation aniY = new DoubleAnimation();
                aniY.To = fp.Y;
                aniY.Duration = TimeSpan.FromMilliseconds(Duration);

                el.RenderTransform.BeginAnimation(TranslateTransform.XProperty, aniX);
                el.RenderTransform.BeginAnimation(TranslateTransform.YProperty, aniY);
            }
            //Console.Out.WriteLine();

            return s;
        }
    }
}
