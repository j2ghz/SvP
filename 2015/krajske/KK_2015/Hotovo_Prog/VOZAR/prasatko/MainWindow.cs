using System;
using Gtk;
using Cairo;

public partial class MainWindow: Gtk.Window
{	
	int faze = 100;
	bool kresli = false;

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
		kresli = true;
		faze = 0;
		for (int i = 0; i < 13; i++) {
			drawingarea1.QueueDraw ();
			Gdk.Window.ProcessAllUpdates ();
			System.Threading.Thread.Sleep (500);
			faze++;
		}
		kresli = false;
		drawingarea1.QueueDraw ();
	}

	protected void OnDrawingarea1ExposeEvent (object o, ExposeEventArgs args)
	{
		//velikost 
		int w, h;
		this.GetSize (out w, out h);
		drawingarea1.SetSizeRequest (w, h - 15);
		int z = Math.Min (w, h - 15) / 100;	//zvetseni

		Context cr = Gdk.CairoHelper.Create (((DrawingArea)o).GdkWindow);

		if (kresli)
			cr.SetSourceRGB(1,0,0);
		else
			cr.SetSourceRGB(1, 0.5, 0.5);

		cr.Translate (w/2 - 50 * z, (h - 15) / 2 - 50 * z);

		//tělo
		if (faze > 0) {
			cr.MoveTo (25 * z, 20 * z);
			cr.LineTo (25 * z, 60 * z);
		}
		if (faze > 1) {
			cr.LineTo (85 * z, 60 * z);
		}
		if (faze > 2) {
			cr.LineTo (85 * z, 20 * z);
		}
		if (faze > 3) {
			cr.LineTo (25 * z, 20 * z);
		}
		//hlava
		if (faze > 4) {
			cr.LineTo (5 * z, 40 * z);
		}
		if (faze > 5) {
			cr.LineTo (25 * z, 60 * z);
		}
		//přední nohy
		if (faze > 6) {
			cr.LineTo (15 * z, 90 * z);
		}
		if (faze > 7) {
			cr.MoveTo (25 * z, 60 * z);
			cr.LineTo (35 * z, 90 * z);
		}
		//zadní nohy
		if (faze > 8) {
			cr.MoveTo (85 * z, 60 * z);
			cr.LineTo (75 * z, 90 * z);
		}
		if (faze > 9) {
			cr.MoveTo (85 * z, 60 * z);
			cr.LineTo (95 * z, 90 * z);
		}
		//ocas
		if (faze > 10) {
			cr.MoveTo (85 * z, 20 * z);
			cr.LineTo (95 * z, 40 * z);
		}
		//oko
		if (faze > 11) {
			cr.MoveTo (22 * z, 35 * z);
			cr.Arc (20 * z, 35 * z, 2 * z, 0, 2 * Math.PI);
		}
		cr.Stroke ();
	}
}
