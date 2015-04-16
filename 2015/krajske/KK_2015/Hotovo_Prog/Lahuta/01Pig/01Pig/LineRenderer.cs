using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace _01Pig
{
    public class LineRenderer : System.Windows.Forms.Panel
    {
        public LineRenderer()
        {
            // double-buffering aby se animace plynule prekreslovala
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint | 
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | 
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);

            // výchozí černé pozadí
            BackColor = Color.Black;

            // výchozí bílé pero
            Pen = Pens.White;

            // vytvorit casovac
            timer = new Timer()
            {
                Enabled = true
            };
            timer.Tick += OnTimerTick;
        }

        /// <summary>
        /// Zakáže nebo povolí animaci
        /// </summary>
        public bool IsAnimationEnabled
        {
            get { return isAnimationEnabled; }
            set { isAnimationEnabled = value; }
        }
        bool isAnimationEnabled = false;

        /// <summary>
        /// Doba trvani animace
        /// </summary>
        public TimeSpan AnimationDuration
        {
            get { return animationDuration; }
            set { animationDuration = value; }
        }
        TimeSpan animationDuration = new TimeSpan(0, 0, 16);

        /// <summary>
        /// Trvání jednoho animačního snímku
        /// </summary>
        public TimeSpan FrameDuration
        {
            get { return animationDuration; }
            set { animationDuration = value; }
        }
        // výchozí 25ms trvání snímku (=40 fps)
        TimeSpan frameDuration = new TimeSpan(250000);

        /// <summary>
        /// Seznam čar k vykreslení
        /// </summary>
        public List<Line> Lines
        {
            get { return lines; }
        }
        private readonly List<Line> lines = new List<Line>();

        /// <summary>
        /// Pero k vyrkeslení čar
        /// </summary>
        public Pen Pen
        {
            get;
            set;
        }


        // animace a její obsluha
        DateTime startTime;

        Timer timer;

        public void Start()
        {
            startTime = DateTime.Now;
            timer.Interval = (int)frameDuration.TotalMilliseconds;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();

            if (AnimationEnded != null)
            {
                AnimationEnded(this, EventArgs.Empty);
            }

            Invalidate();
        }

        public event EventHandler AnimationEnded;

        void OnTimerTick(object sender, EventArgs e)
        {
            // overit pozici animace
            if ((DateTime.Now - startTime).Ticks >= animationDuration.Ticks)
            {
                Stop();
                return;
            }

            // donutit system k prekresleni
            Invalidate();
        }


        // Zděděná metoda vykreslování
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // zjistit rozmery plochy
            float size = Math.Min(e.Graphics.VisibleClipBounds.Width, e.Graphics.VisibleClipBounds.Height);

            if (isAnimationEnabled)
            {
                Line line;

                // zjistit pozici v animaci
                double
                    fromStart = (DateTime.Now - startTime).Ticks,
                    frame = animationDuration.Ticks,
                    position = (fromStart / frame) % 1.0;

                // zjistit ktere cary se maji vykreslit
                int index,
                    to = (int)Math.Floor((double)lines.Count * position);

                // vykreslit jiz nakreslene cary
                for (index = 0; index < to; index++)
                {
                    line = lines[index];

                    e.Graphics.DrawLine(Pen,
                        line.Point1.X * size,
                        line.Point1.Y * size,
                        line.Point2.X * size,
                        line.Point2.Y * size);
                }

                // vykreslit animovanou caru
                position %= 1.0 / (double)(lines.Count);
                position *= lines.Count;
                line = lines[index];

                float
                    diffX = (line.Point2.X - line.Point1.X) * size,
                    diffY = (line.Point2.Y - line.Point1.Y) * size;

                e.Graphics.DrawLine(Pen,
                    line.Point1.X * size,
                    line.Point1.Y * size,
                    line.Point1.X * size + (float)(diffX * position),
                    line.Point1.Y * size + (float)(diffY * position));
            }
            else
            {
                foreach (Line line in lines)
                {
                    e.Graphics.DrawLine(Pen,
                        line.Point1.X * size,
                        line.Point1.Y * size,
                        line.Point2.X * size,
                        line.Point2.Y * size);
                }
            }
        }
    }
}