using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Zlomky
{
    public partial class Form1 : Form
    {
        private List<string> vystup = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Zbrazi soubory pro nacteni
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Title = "Open";
            ofd.ShowDialog();

            listBox1.Items.Clear();

            try
            {
                using (StreamReader sr = new StreamReader(ofd.OpenFile()))
                {
                    string line = sr.ReadLine();

                    while (line != "" && line != null)
                    {
                        string[] sCisla = line.Split(' ');

                        //Nacte jednotlive prvky ve zlomcich
                        long a = long.Parse(sCisla[0]);
                        long b = long.Parse(sCisla[1]);
                        long c = long.Parse(sCisla[2]);
                        long d = long.Parse(sCisla[3]);

                        if (b == 0 || d == 0)
                        {
                            vystup.Add("Nula ve jmenovateli");
                            break;
                        }

                        //Pomoci nejmensiho spolecneho nasobku a nejvetsiho spolecnoho delitele
                        //vypocita vysledek
                        long nejmensiSpolecnyNasobek = NSN(b, d);

                        a *= nejmensiSpolecnyNasobek / b;
                        c *= nejmensiSpolecnyNasobek / d;

                        long mezivysledek = a + c;

                        long x = mezivysledek / nejmensiSpolecnyNasobek;
                        long zbytek = mezivysledek - (x * nejmensiSpolecnyNasobek);

                        if (zbytek == 0)
                            nejmensiSpolecnyNasobek = 0;

                        long nejmensiSpolecnyDelitel = NSD(nejmensiSpolecnyNasobek, zbytek);

                        //Pripravi text pro vlozeni do lisboxu
                        string vystupniRadek = x.ToString() + " " +
                            (zbytek / nejmensiSpolecnyDelitel).ToString() + " " +
                            (nejmensiSpolecnyNasobek / nejmensiSpolecnyDelitel).ToString();

                        vystup.Add(vystupniRadek);
                        listBox1.Items.Add(vystupniRadek);

                        line = sr.ReadLine();
                    }
                }
            }
            catch
            {
               MessageBox.Show("Spatny vstup");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Vypise vystup do souboru
            using (StreamWriter sw = new StreamWriter("vystup.txt"))
            {
                foreach (string s in vystup)
                {
                    sw.WriteLine(s); 
                }
                vystup.Clear();
            }
        }

        private long NSD(long a, long b)
        {
            //Nejvetsi spolecny delitel
            long r = 0;

            while (b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            if (a > 0)
                return a;
            else
                return 1;
        }

        private long NSN(long a, long b)
        {
            //Nejmensi spolecny nasobek
            return (a * b) / NSD(a, b);
        }

    }
}
