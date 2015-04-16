namespace Prasatko
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.glControl1 = new OpenTK.GLControl();
			this.buttonAnimace = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// glControl1
			// 
			this.glControl1.BackColor = System.Drawing.Color.Black;
			this.glControl1.Location = new System.Drawing.Point(16, 16);
			this.glControl1.Name = "glControl1";
			this.glControl1.Size = new System.Drawing.Size(512, 384);
			this.glControl1.TabIndex = 0;
			this.glControl1.VSync = false;
			this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
			this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
			// 
			// buttonAnimace
			// 
			this.buttonAnimace.Location = new System.Drawing.Point(32, 416);
			this.buttonAnimace.Name = "buttonAnimace";
			this.buttonAnimace.Size = new System.Drawing.Size(128, 32);
			this.buttonAnimace.TabIndex = 2;
			this.buttonAnimace.Text = "Pomalá animace";
			this.buttonAnimace.UseVisualStyleBackColor = true;
			this.buttonAnimace.Click += new System.EventHandler(this.buttonAnimace_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(560, 474);
			this.Controls.Add(this.buttonAnimace);
			this.Controls.Add(this.glControl1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private OpenTK.GLControl glControl1;
		private System.Windows.Forms.Button buttonAnimace;
	}
}

