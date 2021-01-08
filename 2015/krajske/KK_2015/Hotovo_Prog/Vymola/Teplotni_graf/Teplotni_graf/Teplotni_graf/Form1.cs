using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Teplotni_graf
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Tyden> tydny = new Dictionary<int, Tyden>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.ShowDialog();

            using (StreamReader sr = new StreamReader(ofd.OpenFile()))
            {
                sr.ReadLine();

                string line = sr.ReadLine();
                string[] hodnoty = line.Split(';');

                int prvniRok = int.Parse(hodnoty[0]);
                int prvniTyden = int.Parse(hodnoty[1]);

                chart1.Series["Aktualni"].Points.AddXY(0, int.Parse(hodnoty[2]));

                //sr.ReadLine();

                while (line != null && line != "")
                {
                    hodnoty = line.Split(';');

                    int x = (int.Parse(hodnoty[0]) - prvniRok) * 52 + (int.Parse(hodnoty[1]) - prvniTyden);

                    chart1.Series["Aktualni"].Points.AddXY(x, int.Parse(hodnoty[2]));

                    if (!tydny.ContainsKey(int.Parse(hodnoty[1])))
                        tydny.Add(int.Parse(hodnoty[1]), new Tyden());
                    else
                    {
                    }

                    line = sr.ReadLine();
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
