using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Zlomky
{
    public partial class Form1 : Form
    {
        public List<string> vysledky;

        public Form1()
        {
            InitializeComponent();
            vysledky = new List<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream zdroj = null;
            OpenFileDialog oteviraciDialog = new OpenFileDialog();

            if (oteviraciDialog.ShowDialog() == DialogResult.OK)
            {

                    if ((zdroj = oteviraciDialog.OpenFile()) != null)
                    {
                        StreamReader reader = new StreamReader(zdroj);
                        while (reader.Peek() > -1)
                        {
                            int vyslednyCitatel = 0;
                            int vyslednyJmenovatel = 0;
                            int vysledneCeleCislo = 0;

                            string[] rozdelene = reader.ReadLine().Split(' ');
                            int prvniCitatel = Int32.Parse(rozdelene[0]);
                            int prvniJmenovatel = Int32.Parse(rozdelene[1]);
                            int druhyCitatel = Int32.Parse(rozdelene[2]);
                            int druhyJmenovatel = Int32.Parse(rozdelene[3]);

                            vyslednyJmenovatel = nejmensiSpolecnyNasobek(prvniJmenovatel, druhyJmenovatel);

                            prvniCitatel *= vyslednyJmenovatel / prvniJmenovatel;
                            druhyCitatel *= vyslednyJmenovatel / druhyJmenovatel;
                            vyslednyCitatel = prvniCitatel + druhyCitatel;

                            int delitel = nejvetsiSpolecnyDelitel(vyslednyCitatel, vyslednyJmenovatel);
                            vyslednyCitatel = vyslednyCitatel / delitel;
                            vyslednyJmenovatel = vyslednyJmenovatel / delitel;

                            if (vyslednyCitatel > vyslednyJmenovatel)
                            {
                                int a;
                                int citatel;
                                a = vyslednyCitatel / vyslednyJmenovatel;
                                citatel = vyslednyCitatel - (a * vyslednyJmenovatel);
                                //citatel -= a * vyslednyJmenovatel;
                                MessageBox.Show(a.ToString() + " " + citatel.ToString() + "/" + vyslednyJmenovatel.ToString());
                            }
                            else MessageBox.Show(vyslednyCitatel.ToString() + "/" + vyslednyJmenovatel.ToString());
                        }
                    }
            }
        }
        public int nejmensiSpolecnyNasobek(int a, int b)
        {
            int num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }
        public int nejvetsiSpolecnyDelitel(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }
    }
}
