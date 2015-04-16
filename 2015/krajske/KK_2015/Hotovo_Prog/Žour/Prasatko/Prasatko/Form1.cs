using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Prasatko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = panel2.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen krida = new Pen(Color.White, 5);

            //obdelnik tela - ZACATEK
            g.DrawLine(
                krida, 
                new Point(panel2.Width / 4, panel2.Height / 3*2), 
                new Point(panel2.Width / 4 * 3, panel2.Height / 3*2
                ));
            Thread.Sleep(500);
            g.DrawLine(
                krida, 
                new Point(panel2.Width / 4, panel2.Height / 3*2 + panel2.Height/60), 
                new Point(panel2.Width/4, panel2.Height/3*2-panel2.Height/4)
                );
            Thread.Sleep(500);
            g.DrawLine(
                krida,
                new Point(panel2.Width / 4 * 3, panel2.Height / 3 * 2 + panel2.Height / 60),
                new Point(panel2.Width / 4 * 3, panel2.Height / 3 * 2 - panel2.Height / 4)
                );
            Thread.Sleep(500);
            g.DrawLine(
                krida,
                new Point(panel2.Width / 4 - panel2.Width/160, panel2.Height / 3 * 2 - panel2.Height / 4),
                new Point(panel2.Width / 4 * 3 + panel2.Width / 140, panel2.Height / 3 * 2 - panel2.Height / 4)
                );
            Thread.Sleep(500);
            //obdelnik tela - KONEC
            //trojuhelnik hlava - ZACATEK
            g.DrawLine(
                krida,
                new Point(panel2.Width / 6, panel2.Height / 3 + panel2.Height / 5),
                new Point(panel2.Width / 4 - panel2.Width / 160, panel2.Height / 3 * 2 - panel2.Height / 4)
                );
            Thread.Sleep(500);
            g.DrawLine(
                krida,
                new Point(panel2.Width / 6, panel2.Height / 3 + panel2.Height / 5 - panel2.Height/60),
                new Point(panel2.Width / 4, panel2.Height / 3 * 2 + panel2.Height / 120)
            );
            Thread.Sleep(500);
            //trojuhelnik hlava - KONEC
            //usecky nohy - ZACATEK
            g.DrawLine(
                krida,
                new Point(panel2.Width / 4, panel2.Height / 3 * 2),
                new Point(panel2.Width / 10*2, panel2.Height / 8 * 7)
            );
            Thread.Sleep(500);
            g.DrawLine(
                krida,
                new Point(panel2.Width / 4, panel2.Height / 3 * 2),
                new Point(panel2.Width / 10*3, panel2.Height / 8 * 7)
            );
            Thread.Sleep(500);
            g.DrawLine(
                krida,
                new Point(panel2.Width / 4 * 3, panel2.Height / 3*2),
                new Point(panel2.Width / 10 * 7, panel2.Height / 8 * 7)
            );
            Thread.Sleep(500);
            g.DrawLine(
                krida,
                new Point(panel2.Width / 4 * 3, panel2.Height / 3*2),
                new Point(panel2.Width / 10 * 8, panel2.Height / 8 * 7)
            );
            Thread.Sleep(500);
            //usecky nohy - KONEC
            //usecka ocas - ZACATEK
            g.DrawLine(
                krida,
                new Point(panel2.Width / 4 * 3, panel2.Height / 3 * 2 - panel2.Height / 4),
                new Point(panel2.Width / 5*4, panel2.Height / 2)
            );
            Thread.Sleep(500);
            //usecka ocas - KONEC
            //elipsa oko - ZACATEK
            g.DrawEllipse(krida, new Rectangle(new Point(panel2.Width / 40*9 , panel2.Height / 13 * 6), new Size(10, 10)));

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Graphics g = panel2.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(new Point(0, 0), panel2.Size));
        }
        private void namalujPomalu(Pen pero, Point souX, Point souY, int delay, Panel tabule)
        {
            Graphics g = tabule.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            double vzdalenost = Math.Pow(souX.X - souY.X, 2) + Math.Pow(souX.Y - souY.Y, 2);
            int zlomek = (int)vzdalenost/30;
            MessageBox.Show(vzdalenost.ToString() + " " + zlomek.ToString());
            for (int i = 1; i < 31; i++)
            {
                g.DrawLine(pero, souX, new Point(souY.X - zlomek*(30-i), souY.Y - zlomek*(30-i)));
                Thread.Sleep(500);
            }
            Pen zvyraznovac = new Pen(Color.Green, 20);
            //g.DrawLine(zvyraznovac, souX, souY);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Pen marker = new Pen(Color.Red);
            namalujPomalu(marker, new Point(50, 50), new Point(100, 100), 30, panel2);
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            button6_Click(sender, e);
            button2_Click(sender, e);
        }

    }
}
