using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Prasatko
{
    public partial class Form1 : Form
    {
        private Graphics g;
        public Form1()
        {
            InitializeComponent(); 
            g = this.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //vycisteni okna
            g.Clear(SystemColors.Control);

            //volba barvy
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            Color barva = cd.Color;
            
            //trup
            VykreslitCaru(barva, 0.2f, 0.1f, 0.8f, 0.1f);
            Thread.Sleep((int)numericUpDown1.Value);
            VykreslitCaru(barva, 0.8f, 0.1f, 0.8f, 0.5f);
            Thread.Sleep((int)numericUpDown1.Value);
            VykreslitCaru(barva, 0.8f, 0.5f, 0.2f, 0.5f);
            Thread.Sleep((int)numericUpDown1.Value);
            VykreslitCaru(barva, 0.2f, 0.5f, 0.2f, 0.1f);
            Thread.Sleep((int)numericUpDown1.Value);
            //hlava
            VykreslitCaru(barva, 0.2f, 0.1f, 0.05f, 0.3f);
            Thread.Sleep((int)numericUpDown1.Value);
            VykreslitCaru(barva, 0.05f, 0.3f, 0.2f, 0.5f);
            Thread.Sleep((int)numericUpDown1.Value);
            //oko
            g.DrawEllipse(new Pen(barva, 5f),
                (int)(this.Width * 0.15f),
                (int)(this.Height * 0.19f),
                (int)(this.Width * 0.03f),
                (int)(this.Height * 0.03f));
            Thread.Sleep((int)numericUpDown1.Value);
            //predni nohy
            VykreslitCaru(barva, 0.2f, 0.5f, 0.15f, 0.8f);
            Thread.Sleep((int)numericUpDown1.Value);
            VykreslitCaru(barva, 0.2f, 0.5f, 0.25f, 0.8f);
            Thread.Sleep((int)numericUpDown1.Value);
            //zadni nohy
            VykreslitCaru(barva, 0.8f, 0.5f, 0.75f, 0.8f);
            Thread.Sleep((int)numericUpDown1.Value);
            VykreslitCaru(barva, 0.8f, 0.5f, 0.85f, 0.8f);
            Thread.Sleep((int)numericUpDown1.Value);

            //ocas
            VykreslitCaru(barva, 0.8f, 0.1f, 0.85f, 0.2f);
            
        }

        private void VykreslitCaru(Color c, float x1, float y1, float x2,float y2)
        {
            Pen p = new Pen(c, 5);

            //Destetinne cislo nasobene velikosti obrazu zajistuje spravnou velikost nezavisle na 
            //velikosti okna
            g.DrawLine(p, new Point((int)(x1 * this.Width), (int)(y1 * this.Height)), new Point((int)(x2 * this.Width), (int)(y2 * this.Height)));
        }

        private void button1_Resize(object sender, EventArgs e)
        {
            
        }
    }
}
