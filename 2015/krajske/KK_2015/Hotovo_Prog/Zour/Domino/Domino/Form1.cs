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

namespace Domino
{
    public partial class Form1 : Form
    {
        public List<KeyValuePair<int, int>> kostky;
        public List<KeyValuePair<int, int>> vysledek;
        public string[] rozdelene;
        public int length;

        public Form1()
        {
            InitializeComponent();
            kostky = new List<KeyValuePair<int, int>>();
            vysledek = new List<KeyValuePair<int, int>>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog nahravaciDialog = new OpenFileDialog();
            Stream zdroj = null;

            if (nahravaciDialog.ShowDialog() == DialogResult.OK)
            {
                if ((zdroj = nahravaciDialog.OpenFile()) != null)
                {
                    StreamReader reader = new StreamReader(zdroj);
                    string s = reader.ReadToEnd().Trim();
                    string[] rozdelene = s.Split(new char[] {'[', ':', ']', ' ' });
                    rozdelene = rozdelene.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    for (int i = 0; i < rozdelene.Length; i+=2)
                    {
                        kostky.Add(new KeyValuePair<int, int>(Int32.Parse(rozdelene[i]), Int32.Parse(rozdelene[i+1])));
                    }
                    reader.Dispose();
                    zobraz();
                    spocitej();
                }
            }
        }

        private void spocitej()
        {
            /*length = 0;

            for (int i = 0; i < kostky.Count; i++)
            {
                if (!(kostky[i + 1].Key == null))
                {
                    for (int j = i + 1; i < kostky.Count; j++)
                    {
                        if (kostky[i].Key == kostky[j].Value ||
                            kostky[i].Key == kostky[j].Key ||
                            kostky[i].Value == kostky[j].Value ||
                            kostky[i].Value == kostky[j].Key)
                        {
                            vysledek.Add(kostky[i]);
                            vysledek.Add(kostky[j]);
                            length++;
                        }
                    }
                }
            }
            MessageBox.Show(length.ToString());*/
        }

        private void zobraz()
        {
            /* DEBUG
            for (int i = 0; i < pulKostky.Count; i+=2)
            {
                richTextBox1.Text += "[" + pulKostky[i].ToString() + ":" + pulKostky[i+1].ToString() + "]" + Environment.NewLine;
            }*/
            for (int i = 0; i < kostky.Count; i++)
            {
                richTextBox1.Text += "[" + kostky[i].Key.ToString() + ":" + kostky[i].Value.ToString() + "]" + Environment.NewLine;
            }

        }
    }
}
