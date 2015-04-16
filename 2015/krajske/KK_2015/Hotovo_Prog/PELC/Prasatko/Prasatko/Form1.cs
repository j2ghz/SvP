using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Prasatko
{
	public partial class Form1 : Form
	{
		Stopwatch _stopwatch = new Stopwatch(); // Časovač
		double _lastFrameMillis = 0;
		double _millisOffset = 0;
		//double _slowRenderStart = 0;
		bool _slowRender = false;
		int _displayLines = 0;
		float _aspectRation = 1;
		float _lineSize = 1;
		float _scale = 1;
		static Vector2 _offset = new Vector2(32, 128);
		public static int Resolution = 512;
		Eye _eye = new Eye(new Vector2(64, 32), 8, 16);
		// Natvrdo zadané prase
		public static Line[] Prase = new Line[]
		{
			new Line(0,64,80,0), 
			new Line(80,0,80,128), 
			new Line(80,128,0,64),
 			new Line(80, 0, 400, 0), 
 			new Line(400, 0, 400, 128),
 			new Line(400, 128, 80, 128),
 			new Line(80, 128, 64, 256), 
 			new Line(80, 128, 96, 256),
 			new Line(400, 128, 384, 256), 
 			new Line(400, 128, 432, 256), 
 			new Line(400, 0, 432, 32)
		};
		public Form1()
		{
			InitializeComponent();
		}

		private void glControl1_Load(object sender, EventArgs e)
		{
			SetupViewport();
			Application.Idle += Application_Idle; // Vždy když aplikace nebude nic dělat překreslí se GLControl
			_lastFrameMillis = _stopwatch.Elapsed.TotalMilliseconds;
			_stopwatch.Start();
		}

		// Když program zrovna nic nedělá, zkusí vykreslit snímek
		void Application_Idle(object sender, EventArgs e)
		{
			// Animované vykreslení
			if(_slowRender)
			{
				_lineSize = (float)Milliseconds() / 2500f;
				if(_lineSize > 1)
				{
					_lineSize = 1;
					_slowRender = false;
				}
				_lastFrameMillis = Milliseconds();
				glControl1.Invalidate(); // "glControl1.Invalidate()" překreslí glControl
				return;
			}
			// Postupné vykreslení
			if((Milliseconds() - _lastFrameMillis) / 500 >= 1)
			{
				_lastFrameMillis = Milliseconds();
				_displayLines++;
				glControl1.Invalidate();
			}
		}

		double Milliseconds() // Kolik milisekund uběhlo od resetování časovače
		{
			return _stopwatch.Elapsed.TotalMilliseconds - _millisOffset;
		}

		private void SetupViewport()
		{
			// Nastaví vykreslování v glControlu a velikost prasete
			int w = glControl1.Width;
			int h = glControl1.Height;
			_aspectRation = w / (float)h;
			if(w > h)
				_scale = (float)h / Resolution;
			else
			{
				_scale = (float)w / Resolution;
			}
			int top = 0;
			int left = 0;
			int right = w;
			int bottom = h;
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadIdentity();
			GL.Ortho(left - 0.375, right - 0.375, bottom - 0.375, top - 0.375, -1000, 1000);
			GL.Viewport(0, 0, w, h);
		}

		private void glControl1_Paint(object sender, PaintEventArgs e)
		{
			// Program využívá OpenGL pro kreslení prasete
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadIdentity();
			GL.ClearColor(Color.MidnightBlue);


			GL.Color3(Color.GreenYellow);
			int i = 0;
			// Vykreslí prase
			foreach(Line line in Prase)
			{
				if(i >= _displayLines)
					break;
				line.Render(_lineSize, _scale, _offset);
				i++;
			}
			if(i >= Prase.Length)
			{
				_eye.Render(_lineSize, _scale, _offset);
			}

			// Předá hotový snímek na obrazovku
			glControl1.SwapBuffers();
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			glControl1.Size = new Size(this.Width - 64, this.Height - 128);
			buttonAnimace.Location = new Point(32, Height - 96);
			SetupViewport();
			glControl1.Invalidate();
		}

		private void buttonAnimace_Click(object sender, EventArgs e)
		{
			_slowRender = true;
			_displayLines = 100;
			_lineSize = 0;
			_millisOffset = Milliseconds();
			_lastFrameMillis = 0;
		}
	}

	public class Line
	{
		public Vector2 StartPoint, EndPoint;

		public Line(Vector2 start, Vector2 end)
		{
			StartPoint = start;
			EndPoint = end;
		}

		public Line(int startX, int startY, int endX, int endY)
		{
			StartPoint = new Vector2(startX, startY);
			EndPoint = new Vector2(endX, endY);
		}

		// Vykreslí čáru se zadanou délkou (0 .. 1, 0 - žádná délka, 1 - plná délka)
		public void Render(float size, float scale, Vector2 offset)
		{
			float length = size;
			if(length > 1)
			{
				length = 1;
			}
			if(length < 0)
			{
				length = 0;
			}
			GL.Begin(PrimitiveType.Lines);

			GL.Vertex2((StartPoint + offset) * scale);
			GL.Vertex2((StartPoint + (EndPoint - StartPoint) * length + offset) * scale);

			GL.End();
		}
	}

	public class Eye
	{
		public Vector2 Middle;
		public readonly float Radius;
		public readonly int Vertices;
		Vector2[] _vertices; // Vrcholy kruhu oka

		public Eye(Vector2 mid, float radius, int verts)
		{
			Middle = mid;
			Radius = radius;
			Vertices = verts;
			_vertices = new Vector2[verts];
			// Vygeneruje vrcholy oka do kruhu v pravidelných odstupech
			for(int i = 0; i < verts; i++)
			{
				double angle = 360 / verts * i * (Math.PI / 180);
				Vector2 vertex = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
				_vertices[i] = vertex * Radius;
			}
		}

		// Vykreslí kruh oka
		public void Render(float size, float scale, Vector2 offset)
		{
			float length = size * Vertices; // Oko je složeno z mnoha linek, postupně se vykreslí všechny
			Line line;
			for(int i = 1; i < Vertices; i++)
			{
				line = new Line(_vertices[i - 1] + Middle, _vertices[i] + Middle);
				line.Render(length - (i - 1), scale, offset);
			}
			line = new Line(_vertices[_vertices.Length - 1] + Middle, _vertices[0] + Middle);
			line.Render(length - Vertices + 1, scale, offset);
		}
	}
}
