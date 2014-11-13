using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GDIPlus_Demo_2
{
    public partial class Form1 : Form
    {
        readonly TextureBrush _smileBrush = new TextureBrush(Image.FromFile("../../smile.jpg"));
        Image _transparentImage;
        readonly List<Point> _points = new List<Point>();

        private int Diameter
        {
            get { return _sizeSlider.Value; }
        }

        
        public Form1()
        {
            InitializeComponent();
            _smileBrush.WrapMode = WrapMode.Clamp;
        }

        private void smileyPanelPaint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;
            Point center = new Point(p.Width / 2, p.Height / 2);

            using (Matrix trMatrix = new Matrix())
            {
                trMatrix.Scale((float)Diameter / _smileBrush.Image.Width,
                   (float)Diameter / _smileBrush.Image.Height, MatrixOrder.Append);
                trMatrix.Translate(center.X - Diameter/2, center.Y - Diameter/2, MatrixOrder.Append);
                trMatrix.RotateAt(rotationTrackbar.Value, center, MatrixOrder.Append);
                _smileBrush.Transform = trMatrix;

                g.FillEllipse(_smileBrush, center.X - Diameter/2, center.Y - Diameter/2, Diameter, Diameter);
            }
        }

        private void sizeSlider_Scroll(object sender, EventArgs e)
        {
            _smileyPanel.Refresh();
        }

        private void rotationTrackbar_Scroll(object sender, EventArgs e)
        {
            _smileyPanel.Refresh();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            _smileyPanel.Refresh();
        }

        private void selectImageButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = _selectImageFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = _selectImageFileDialog.FileName;
                try
                {
                    _transparentImage = Image.FromFile(path);
                }
                catch
                {
                    MessageBox.Show("Not a valid image file");
                    return;
                }
                _transparencyPanel.Refresh();
            }
        }

        private void transparencyPanelPaint(object sender, PaintEventArgs e)
        {
            if (_transparentImage == null)
            {
                return;
            }
            Graphics g = e.Graphics;
            Panel p = sender as Panel;
            ImageAttributes attr = new ImageAttributes();
            ColorMatrix cm = new ColorMatrix();
            float alpha = (float)(100-trasnparencySlider.Value) / 100;
            cm.Matrix33 = alpha;
            attr.SetColorMatrix(cm);
            g.DrawImage(_transparentImage, _transparencyPanel.ClientRectangle, 0, 0, _transparentImage.Width, _transparentImage.Height, GraphicsUnit.Pixel, attr);
        }

        private void trasnparencySlider_Scroll(object sender, EventArgs e)
        {
            _transparencyPanel.Refresh();
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            _points.Add(new Point(e.X, e.Y));
            _splinesPanel.Refresh();
        }

        private void splinesPanelPaint(object sender, PaintEventArgs e)
        {
           using (Brush b = new SolidBrush(Color.Red))
           {
              using (Pen p = new Pen(Color.Green, 3))
              {
                 if (_points.Count >= 3)
                 {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawCurve(p, _points.ToArray(), tensionSlider.Value/20f);
                 }
                 foreach (Point pt in _points)
                 {
                    e.Graphics.FillEllipse(b, pt.X - 2, pt.Y - 2, 4, 4);
                 }
              }
           }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            _points.Clear();
            _splinesPanel.Refresh();
        }

        private void tensionSlider_Scroll(object sender, EventArgs e)
        {
            _splinesPanel.Refresh();
        }

    }
}
