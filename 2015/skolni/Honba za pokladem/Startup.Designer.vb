<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Startup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.NumericUpDownX = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownY = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.NumericUpDownX,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.NumericUpDownY,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.FlowLayoutPanel1.SuspendLayout
        Me.GroupBox3.SuspendLayout
        CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'NumericUpDownX
        '
        Me.NumericUpDownX.Location = New System.Drawing.Point(4, 17)
        Me.NumericUpDownX.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDownX.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDownX.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericUpDownX.Name = "NumericUpDownX"
        Me.NumericUpDownX.Size = New System.Drawing.Size(52, 20)
        Me.NumericUpDownX.TabIndex = 0
        Me.NumericUpDownX.Value = New Decimal(New Integer() {63, 0, 0, 0})
        '
        'NumericUpDownY
        '
        Me.NumericUpDownY.Location = New System.Drawing.Point(61, 18)
        Me.NumericUpDownY.Margin = New System.Windows.Forms.Padding(2)
        Me.NumericUpDownY.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDownY.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericUpDownY.Name = "NumericUpDownY"
        Me.NumericUpDownY.Size = New System.Drawing.Size(52, 20)
        Me.NumericUpDownY.TabIndex = 1
        Me.NumericUpDownY.Value = New Decimal(New Integer() {33, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.NumericUpDownX)
        Me.GroupBox1.Controls.Add(Me.NumericUpDownY)
        Me.GroupBox1.Location = New System.Drawing.Point(194, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(123, 45)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Velikost hracího pole"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Size = New System.Drawing.Size(188, 302)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Počet hráčů (zaškrtnuté ovládá AI)"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(95, 40)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Odebrat"
        Me.Button3.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(7, 40)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Přidat"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(7, 17)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(177, 20)
        Me.TextBox1.TabIndex = 6
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.FormattingEnabled = true
        Me.CheckedListBox1.Items.AddRange(New Object() {"Hráč1", "Hráč2"})
        Me.CheckedListBox1.Location = New System.Drawing.Point(7, 67)
        Me.CheckedListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(177, 229)
        Me.CheckedListBox1.TabIndex = 5
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox2)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox1)
        Me.FlowLayoutPanel1.Controls.Add(Me.GroupBox3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(799, 557)
        Me.FlowLayoutPanel1.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox3.Location = New System.Drawing.Point(322, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(111, 44)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Velikost políčka"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(3, 16)
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(100, 20)
        Me.NumericUpDown1.TabIndex = 0
        Me.NumericUpDown1.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(438, 2)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 36)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "OK!"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'Startup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = true
        Me.ClientSize = New System.Drawing.Size(799, 557)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Startup"
        Me.Text = "Startup"
        CType(Me.NumericUpDownX,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.NumericUpDownY,System.ComponentModel.ISupportInitialize).EndInit
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.FlowLayoutPanel1.ResumeLayout(false)
        Me.GroupBox3.ResumeLayout(false)
        CType(Me.NumericUpDown1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents NumericUpDownX As NumericUpDown
    Friend WithEvents NumericUpDownY As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents NumericUpDown1 As NumericUpDown
End Class
