using System;
using Gtk;
using System.IO;
using Cairo;

public partial class MainWindow: Gtk.Window
{
	int[] teploty = new int[52*40];

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		//načíst teploty
		StreamReader reader = new StreamReader (entry1.Text);
		reader.ReadLine ();
		string line;
		int i = 0;
		while ((line = reader.ReadLine()) != null) {
			teploty [i] = Convert.ToInt32 (line.Split(';')[2]);
		}
		reader.Close ();
		button2.Visible = true;
	}

	protected void OnButton2Clicked (object sender, EventArgs e)
	{
		drawingarea1.QueueDraw ();
	}

	protected void OnDrawingarea1ExposeEvent (object o, ExposeEventArgs args)
	{
		Context cr = Gdk.CairoHelper.Create (((DrawingArea)o).GdkWindow);
		cr.Translate (10, 110);

		//osy
		cr.SetSourceRGB(0,0,0);
		cr.MoveTo (-10, 0);
		cr.LineTo (250, 0);
		cr.MoveTo (0, 100);
		cr.LineTo (0, -100);
		cr.Stroke ();

		//naměřená teplota
		cr.SetSourceRGB(1,1,0);
		cr.MoveTo (0, 0);
		for (int i = 0; i < 52; i++) {
			cr.LineTo (i * 10, teploty[i]);
		}
		cr.Stroke ();
	}
}
