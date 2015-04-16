using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Prasatko
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();



        }
        //Odezva
        static void Delay(int ms, EventHandler action)
        {
            var tmp = new Timer { Interval = ms };
            tmp.Tick += new EventHandler((o, e) => tmp.Enabled = false);
            tmp.Tick += action;
            tmp.Enabled = true;
        }

        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 2F);
        
       

       

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Vykresleni
            System.Drawing.Graphics graphics = this.CreateGraphics();
            

            g = pictureBox1.CreateGraphics();

            Delay(500, (o, a) => g.DrawLine(pen1, 50, 150, 120, 80));
            Delay(1000, (o, a) => g.DrawLine(pen1, 50, 150, 120, 220));
            Delay(1500, (o, a) => g.DrawLine(pen1, 120, 80, 120, 220));
            Delay(2000, (o, a) => g.DrawLine(pen1, 120, 80, 350, 80));
            Delay(2500, (o, a) => g.DrawLine(pen1, 350, 80, 350, 220));
            Delay(3000, (o, a) => g.DrawLine(pen1, 350, 220, 120, 220));
            Delay(3500, (o, a) => g.DrawLine(pen1, 120, 220, 80, 330));
            Delay(4000, (o, a) => g.DrawLine(pen1, 120, 220, 160, 330));
            Delay(4500, (o, a) => g.DrawLine(pen1, 350, 220, 310, 330));
            Delay(5000, (o, a) => g.DrawLine(pen1, 350, 220, 390, 330));
            Delay(5500, (o, a) => g.DrawLine(pen1, 350, 80, 380, 160));
            Delay(6000, (o, a) => g.DrawLine(pen1,95,120,102,120));
            Delay(6500, (o, a) => g.DrawLine(pen1, 102, 120, 105, 125));
            Delay(7000, (o, a) => g.DrawLine(pen1, 105, 125, 102, 130));
            Delay(7500, (o, a) => g.DrawLine(pen1, 102, 130, 95, 130));
            Delay(8000, (o, a) => g.DrawLine(pen1, 95, 130, 92, 125));
            Delay(8500, (o, a) => g.DrawLine(pen1, 92, 125, 95, 120));
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}

