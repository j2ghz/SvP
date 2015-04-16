using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Domino
{
    public partial class Form1 : Form
    {
        private List<Kostka> Kostky = new List<Kostka>();
        private List<Kostka> NejvicKostek = new List<Kostka>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Title = "Open";
            ofd.ShowDialog();

            Kostky.Clear();
            listBox1.Items.Clear();

            try
            {
                using (StreamReader sr = new StreamReader(ofd.OpenFile()))
                {
                    string line = sr.ReadLine();

                    //Z jednotlivych radku nacte do listu kostky
                    while (line != "" && line != null)
                    {
                        string[] kostkyInfo = line.Split(']');

                        foreach (string s in kostkyInfo)
                        {
                            if (s != "" && s != null)
                            {
                                string[] cisla = s.Split('[')[1].Split(':');

                                int prvni = int.Parse(cisla[0]);
                                int druhe = int.Parse(cisla[1]);

                                Kostky.Add(new Kostka(prvni, druhe));
                            }
                        }

                        line = sr.ReadLine();
                    }

                    //Vzdy vybere jednu pocatecni
                    for (int i = 0; i < Kostky.Count; i++)
                    {
                        int delka = 0;
                        Kostka posledni = Kostky[i];

                        List<Kostka> zbyvajici = Kostky;
                        List<Kostka> rada = new List<Kostka>();
                        rada.Add(Kostky[i]);

                        //Postupne projde list a hleda navazujici kostky
                        for (int x = 0; x < zbyvajici.Count; x++)
                        {
                            if (zbyvajici[x] != Kostky[i])
                            {
                                if (rada.Last().Prava == zbyvajici[x].Leva)
                                {
                                    rada.Add(new Kostka(zbyvajici[x].Leva, zbyvajici[x].Prava));
                                    delka++;
                                }

                                else if (rada.Last().Prava == zbyvajici[x].Prava)
                                {
                                    rada.Add(new Kostka(zbyvajici[x].Prava, zbyvajici[x].Leva));
                                    delka++;
                                }
                            }
                        }

                        if (rada.Count > NejvicKostek.Count)
                            NejvicKostek = rada;

                        //Vypise vysledky do listboxu
                        string doListboxu = "";
                        foreach (Kostka k in rada)
                        {
                            doListboxu += "[" + k.Leva.ToString() + ":" + k.Prava.ToString() + "]";
                        }

                        listBox1.Items.Add(doListboxu);
                    }

                    //K vypsanym vysledkum prida jeste nejdelsi radu
                    string nejdelsi = "";
                    foreach (Kostka k in NejvicKostek)
                    {
                        nejdelsi += "[" + k.Leva.ToString() + ":" + k.Prava.ToString() + "]";
                    }

                    listBox1.Items.Add(nejdelsi);
                    listBox1.Items.Add("Nejdelsi rada: " + nejdelsi);
                }
            }
            catch
            {
                MessageBox.Show("Spatny vstup");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Vypise vysledky do souboru
            using (StreamWriter sw = new StreamWriter("vystup.txt"))
            {
                foreach (var v in listBox1.Items)
                {
                    sw.WriteLine(v.ToString());
                }
            }
        }
    }
}
