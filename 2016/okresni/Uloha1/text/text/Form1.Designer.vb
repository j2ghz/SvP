<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.NačístToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UložitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpravitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ŠifrovatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ŠifrujToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OdšifrujToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NačístToolStripMenuItem, Me.UložitToolStripMenuItem, Me.OpravitToolStripMenuItem, Me.ŠifrovatToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(626, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NačístToolStripMenuItem
        '
        Me.NačístToolStripMenuItem.Name = "NačístToolStripMenuItem"
        Me.NačístToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.NačístToolStripMenuItem.Text = "Načíst"
        '
        'UložitToolStripMenuItem
        '
        Me.UložitToolStripMenuItem.Name = "UložitToolStripMenuItem"
        Me.UložitToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.UložitToolStripMenuItem.Text = "Uložit"
        '
        'OpravitToolStripMenuItem
        '
        Me.OpravitToolStripMenuItem.Name = "OpravitToolStripMenuItem"
        Me.OpravitToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.OpravitToolStripMenuItem.Text = "Opravit"
        '
        'ŠifrovatToolStripMenuItem
        '
        Me.ŠifrovatToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.ŠifrujToolStripMenuItem, Me.OdšifrujToolStripMenuItem})
        Me.ŠifrovatToolStripMenuItem.Name = "ŠifrovatToolStripMenuItem"
        Me.ŠifrovatToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ŠifrovatToolStripMenuItem.Text = " Šifrovat"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripTextBox1.Text = "5"
        '
        'ŠifrujToolStripMenuItem
        '
        Me.ŠifrujToolStripMenuItem.Name = "ŠifrujToolStripMenuItem"
        Me.ŠifrujToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ŠifrujToolStripMenuItem.Text = "Šifruj"
        '
        'OdšifrujToolStripMenuItem
        '
        Me.OdšifrujToolStripMenuItem.Name = "OdšifrujToolStripMenuItem"
        Me.OdšifrujToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.OdšifrujToolStripMenuItem.Text = "Odšifruj"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(0, 24)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(626, 365)
        Me.TextBox1.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 392)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(626, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel1.Text = "0"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel2.Text = "0"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(13, 17)
        Me.ToolStripStatusLabel3.Text = "0"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "C:\PROG2016\Uloha1\text.txt"
        Me.OpenFileDialog1.InitialDirectory = "C:\PROG2016\Uloha1\"
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "C:\PROG2016\Uloha1\out.txt"
        Me.SaveFileDialog1.InitialDirectory = "C:\PROG2016\Uloha1\"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 414)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Oprava textu"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents NačístToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UložitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpravitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ŠifrovatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ŠifrujToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OdšifrujToolStripMenuItem As ToolStripMenuItem
End Class
