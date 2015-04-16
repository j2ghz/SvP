namespace Domino
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
			this.buttonNacistVstup = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonNacistVstup
			// 
			this.buttonNacistVstup.Location = new System.Drawing.Point(15, 28);
			this.buttonNacistVstup.Name = "buttonNacistVstup";
			this.buttonNacistVstup.Size = new System.Drawing.Size(156, 65);
			this.buttonNacistVstup.TabIndex = 0;
			this.buttonNacistVstup.Text = "Načist vstup";
			this.buttonNacistVstup.UseVisualStyleBackColor = true;
			this.buttonNacistVstup.Click += new System.EventHandler(this.buttonNacistVstup_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.buttonNacistVstup);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonNacistVstup;
	}
}

