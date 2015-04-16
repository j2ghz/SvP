using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Zlomky
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonNacistVstup_Click(object sender, EventArgs e)
		{
			List<string> vystup = new List<string>();
			var dialog = new OpenFileDialog
			{
				Filter = "Textové soubory|*.txt"
			};
			if(dialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			using(StreamReader sr = new StreamReader(dialog.FileName))
			{
				string line = sr.ReadLine();
				while(!string.IsNullOrEmpty(line))
				{
					long x, y, z;
					var s = line.Split(' ');
					Process(long.Parse(s[0]), long.Parse(s[1]), long.Parse(s[2]), long.Parse(s[3]), out x, out y, out z);
					string vysledek = (x.ToString() + ' ' + y.ToString() + ' ' + z.ToString());
					vystup.Add(vysledek);
					if(checkBox1.Checked)
					{
						listBox1.Items.Add(s[0] + '/' + s[1] + " + " + s[2] + '/' + s[3] + " = " + x.ToString() + " + " + y.ToString() + '/' + z.ToString());
					}
					line = sr.ReadLine();
				}
			}

			var saveDialog = new SaveFileDialog
			{
				Filter = "Textové soubory|*.txt"
			};

			if(saveDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			using(StreamWriter sw = new StreamWriter(saveDialog.FileName))
			{
				foreach(string s in vystup)
				{
					sw.WriteLine(s);
				}
			}
		}

		void Process(long a, long b, long c, long d, out long x, out long y, out long z)
		{
			z = NsnEuklid(b, d); // nsn jmenovatelů
			a *= z / b; // Převení a,c na společný jmenovatel
			c *= z / d; //
			a += c; // Do "a" se zapíše součet čitatelů
			x = (long)Math.Floor(a / (double)z); // Do "x" se zapíše celá část zlomku
			y = a - x * z; // Do y se zapíše zbytek
			// Zkrácení zbytku
			long nsdZbytku = NsdEuklid(y, z);
			y /= nsdZbytku;
			z /= nsdZbytku;
			if(y == 0)
				z = 0;
		}

		// Euklidův algoritmus upravený pro nejmenší společný násobek
		// a * b = nsn * nsd
		// nsn = a * b / nsd
		static long NsnEuklid(long u, long w)
		{
			// nsn = a * b / nsd
			return u * w / NsdEuklid(u, w);
		}

		// Euklidův algoritmus na největší společný dělitel
		static long NsdEuklid(long u, long w)
		{
			long ab = u * w;
			long r = w;
			while(w > 0)
			{
				r = u % w;
				u = w;
				w = r;
			}
			return u;
		}
	}
}
