namespace Zlomky
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.SuspendLayout();
			// 
			// buttonNacistVstup
			// 
			this.buttonNacistVstup.Location = new System.Drawing.Point(12, 12);
			this.buttonNacistVstup.Name = "buttonNacistVstup";
			this.buttonNacistVstup.Size = new System.Drawing.Size(98, 43);
			this.buttonNacistVstup.TabIndex = 0;
			this.buttonNacistVstup.Text = "Načíst vstup";
			this.buttonNacistVstup.UseVisualStyleBackColor = true;
			this.buttonNacistVstup.Click += new System.EventHandler(this.buttonNacistVstup_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(30, 106);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(454, 147);
			this.listBox1.TabIndex = 1;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Location = new System.Drawing.Point(12, 61);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(284, 17);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Zapsat výsledky do listboxu (vypnout pro velké vstupy)";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// printDialog1
			// 
			this.printDialog1.UseEXDialog = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(510, 262);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.buttonNacistVstup);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonNacistVstup;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.PrintDialog printDialog1;
	}
}

