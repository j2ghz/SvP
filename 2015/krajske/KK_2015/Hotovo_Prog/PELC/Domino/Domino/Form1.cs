using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Domino
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonNacistVstup_Click(object sender, EventArgs e)
		{
			List<Domino> dominaList = new List<Domino>();
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
				var split = line.Split('[');
				foreach(string s in split)
				{
					if(string.IsNullOrEmpty(s))
						continue;
					var vs = s.Remove(3);
					var domino = vs.Split(':');
					dominaList.Add(new Domino(byte.Parse(domino[0]), byte.Parse(domino[1])));
				}
			}

			var domina = Domino.Order(dominaList.ToArray());

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
				int count = domina.Count;
				string vystup = "";
				bool flipped = false;
				if(count < 1)
				{
					return;
				}
				if(count < 2)
				{
					vystup = domina[0].GetText(flipped);
					return;
				}
				for(int i = 1; i < count; i++)
				{
					if(domina[i - 1].B == domina[i].B)
						flipped = !flipped;
					vystup += domina[i].GetText(flipped);
				}
				sw.WriteLine(vystup);
			}

		}
	}

	public class Domino
	{
		public readonly byte A, B;
		public bool AUsed, BUsed;
		public Domino(byte a, byte b)
		{
			A = a;
			B = b;
			AUsed = false;
			BUsed = false;
		}

		public override bool Equals(object obj)
		{
			Domino domino = (Domino)obj;
			return (A == domino.A && B == domino.B) || (A == domino.B && B == domino.A);
		}

		public bool IsEqual(Domino domino)
		{
			return (A == domino.A && B == domino.B) || (A == domino.B && B == domino.A);
		}

		public string GetText(bool flipped)
		{
			if(flipped)
				return '[' + B.ToString() + ':' + A.ToString() + ']';
			return '[' + A.ToString() + ':' + B.ToString() + ']';
		}

		public static List<Domino> Order(Domino[] domina)
		{
			int[,] pocty = new int[7,7];
			List<Domino> vystup = new List<Domino>();
			foreach(Domino domino in domina)
			{
				pocty[Math.Min(domino.A, domino.B), Math.Max(domino.A, domino.B)]++;
			}
			int maxcount = 0;
			int mx = 0;
			bool[,] navs = new bool[7,7];
			for(byte y = 0; y < 7; y++)
			{
				for(byte x = (byte)(6 - y); x < 7; x++)
				{
					var l = Domino.GetLongestLine(pocty, navs, x, y, out mx);
					if(mx > maxcount)
					{
						maxcount = mx;
						vystup = l;
					}
				}
			}
			return vystup;
		}

		static List<Domino> GetLongestLine(int[,] pocty, bool[,] nav, byte a, byte b, out int length)
		{
			List<Domino> domina = new List<Domino>();
			bool[,] navstivene = new bool[7,7];
			for(int x = 0; x < 7; x++)
			{
				for(int y = 0; y < 7; y++)
				{
					navstivene[x, y] = nav[x, y];
				}
			}
			navstivene[a, b] = true;
			int pocet = pocty[a, b];
			int nejvetsi = 0;
			List<Domino> nejvetsiDom = new List<Domino>();
			int njv = 0;
			if(pocet % 2 == 0)
			{
				for(byte i = b; i < 7; i++)
				{
					if(!navstivene[a,i])
					{
						 var l = GetLongestLine(pocty, navstivene, a, i, out njv);
						if(njv > nejvetsi)
						{
							nejvetsiDom = l;
							nejvetsi = njv;
						}
					}
				}
			}
			if(pocet % 2 == 1)
			{
				for(byte i = b; i < 7; i++)
				{
					if(!navstivene[b, i])
					{
						var l = GetLongestLine(pocty, navstivene, b, i, out njv);
						if(njv > nejvetsi)
						{
							nejvetsiDom = l;
							nejvetsi = njv;
						}
					}
				}
			}

			length = nejvetsi + pocet;
			foreach(Domino domino in nejvetsiDom)
			{
				domina.Add(domino);
			}
			return domina;
		}

		static Domino[] GetAllDominos()
		{
			int i = 0;
			byte zacatecniB = 0;
			List<Domino> vystup = new List<Domino>();
			for(byte a = 0; a < 7; a++)
			{
				for(byte b = zacatecniB; b < 7; b++)
				{
					vystup.Add(new Domino(a,b));
					i++;
				}
				zacatecniB++;
			}
			return vystup.ToArray();
		}



		public override int GetHashCode()
		{
			if(A > B)
			{
				return B.GetHashCode() ^ A.GetHashCode(); 
			}
			return A.GetHashCode() ^ B.GetHashCode(); 
		}
	}
}
