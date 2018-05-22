<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccessRights
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
        Me.Give = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Full = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Write = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.access = New System.Windows.Forms.GroupBox()
        Me.Read = New System.Windows.Forms.RadioButton()
        Me.access.SuspendLayout()
        Me.SuspendLayout()
        '
        'Give
        '
        Me.Give.Location = New System.Drawing.Point(37, 89)
        Me.Give.Name = "Give"
        Me.Give.Size = New System.Drawing.Size(211, 23)
        Me.Give.TabIndex = 12
        Me.Give.Text = "Give"
        Me.Give.UseVisualStyleBackColor = True
        Me.Give.UseWaitCursor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(197, 66)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(51, 17)
        Me.RadioButton1.TabIndex = 16
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "None"
        Me.RadioButton1.UseVisualStyleBackColor = True
        Me.RadioButton1.UseWaitCursor = True
        '
        'Full
        '
        Me.Full.AutoSize = True
        Me.Full.Location = New System.Drawing.Point(150, 66)
        Me.Full.Name = "Full"
        Me.Full.Size = New System.Drawing.Size(41, 17)
        Me.Full.TabIndex = 15
        Me.Full.TabStop = True
        Me.Full.Text = "Full"
        Me.Full.UseVisualStyleBackColor = True
        Me.Full.UseWaitCursor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(19, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Select Folder"
        Me.Label7.UseWaitCursor = True
        '
        'Write
        '
        Me.Write.AutoSize = True
        Me.Write.Location = New System.Drawing.Point(94, 66)
        Me.Write.Name = "Write"
        Me.Write.Size = New System.Drawing.Size(50, 17)
        Me.Write.TabIndex = 14
        Me.Write.TabStop = True
        Me.Write.Text = "Write"
        Me.Write.UseVisualStyleBackColor = True
        Me.Write.UseWaitCursor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(94, 23)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(213, 21)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.UseWaitCursor = True
        '
        'access
        '
        Me.access.AutoSize = True
        Me.access.Controls.Add(Me.Give)
        Me.access.Controls.Add(Me.RadioButton1)
        Me.access.Controls.Add(Me.Full)
        Me.access.Controls.Add(Me.Label7)
        Me.access.Controls.Add(Me.Write)
        Me.access.Controls.Add(Me.ComboBox1)
        Me.access.Controls.Add(Me.Read)
        Me.access.Location = New System.Drawing.Point(46, 66)
        Me.access.Name = "access"
        Me.access.Size = New System.Drawing.Size(355, 134)
        Me.access.TabIndex = 16
        Me.access.TabStop = False
        Me.access.Text = "Access Rights"
        Me.access.UseCompatibleTextRendering = True
        Me.access.UseWaitCursor = True
        '
        'Read
        '
        Me.Read.AutoSize = True
        Me.Read.Location = New System.Drawing.Point(37, 64)
        Me.Read.Name = "Read"
        Me.Read.Size = New System.Drawing.Size(51, 17)
        Me.Read.TabIndex = 13
        Me.Read.TabStop = True
        Me.Read.Text = "Read"
        Me.Read.UseVisualStyleBackColor = True
        Me.Read.UseWaitCursor = True
        '
        'AccessRights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 262)
        Me.Controls.Add(Me.access)
        Me.Name = "AccessRights"
        Me.Text = "AccessRights"
        Me.access.ResumeLayout(False)
        Me.access.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Give As System.Windows.Forms.Button
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Full As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Write As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents access As System.Windows.Forms.GroupBox
    Friend WithEvents Read As System.Windows.Forms.RadioButton
End Class
