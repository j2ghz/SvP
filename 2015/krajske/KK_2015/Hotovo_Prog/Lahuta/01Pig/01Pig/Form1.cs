using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _01Pig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // úsečky prasete
            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.3f, 0.5f),
                Point2 = new PointF(0.1f, 0.3f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.1f, 0.3f),
                Point2 = new PointF(0.3f, 0.1f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.3f, 0.1f),
                Point2 = new PointF(0.8f, 0.1f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.8f, 0.1f),
                Point2 = new PointF(0.8f, 0.5f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.8f, 0.5f),
                Point2 = new PointF(0.3f, 0.5f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.3f, 0.5f),
                Point2 = new PointF(0.3f, 0.1f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.8f, 0.1f),
                Point2 = new PointF(0.9f, 0.2f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.3f, 0.5f),
                Point2 = new PointF(0.2f, 0.9f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.3f, 0.5f),
                Point2 = new PointF(0.4f, 0.9f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.8f, 0.5f),
                Point2 = new PointF(0.7f, 0.9f)
            });

            renderer.Lines.Add(new Line()
            {
                Point1 = new PointF(0.8f, 0.5f),
                Point2 = new PointF(0.9f, 0.9f)
            });

            for (double q = 0, step = Math.PI / 3.0; q < Math.PI + Math.PI; q += step)
            {
                renderer.Lines.Add(new Line()
                {
                    Point1 = new PointF(
                        (float)(0.25 + Math.Cos(q) * 0.01), 
                        (float)(0.2 - Math.Sin(q) * 0.01)),
                    Point2 = new PointF(
                        (float)(0.25 + Math.Cos(q + step) * 0.01), 
                        (float)(0.2 - Math.Sin(q + step) * 0.01))
                });
            }

            // spustit animaci
            renderer.AnimationEnded += OnFastRenderClick;
            renderer.Start();
        }

        // prekreslit prase pri zmene velikosti okna
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            renderer.Invalidate();
        }

        void OnSlowRenderClick(object sender, EventArgs e)
        {
            renderer.Pen = Pens.Yellow;
            renderer.IsAnimationEnabled = true;
            renderer.Start();
        }

        void OnFastRenderClick(object sender, EventArgs e)
        {
            renderer.Pen = Pens.White;
            renderer.IsAnimationEnabled = false;
            renderer.Invalidate();
        }

        void OnCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
