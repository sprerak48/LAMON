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
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewProcessListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KillProcessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComputerManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccessRightsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoginToolStripMenuItem, Me.ProcessManagementToolStripMenuItem, Me.ViewUsersToolStripMenuItem, Me.MessageToolStripMenuItem, Me.ComputerManagementToolStripMenuItem, Me.AccessRightsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(586, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(49, 20)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'ProcessManagementToolStripMenuItem
        '
        Me.ProcessManagementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewProcessListToolStripMenuItem, Me.KillProcessToolStripMenuItem})
        Me.ProcessManagementToolStripMenuItem.Name = "ProcessManagementToolStripMenuItem"
        Me.ProcessManagementToolStripMenuItem.Size = New System.Drawing.Size(133, 20)
        Me.ProcessManagementToolStripMenuItem.Text = "Process Management"
        '
        'ViewProcessListToolStripMenuItem
        '
        Me.ViewProcessListToolStripMenuItem.Name = "ViewProcessListToolStripMenuItem"
        Me.ViewProcessListToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ViewProcessListToolStripMenuItem.Text = "View Process List"
        '
        'KillProcessToolStripMenuItem
        '
        Me.KillProcessToolStripMenuItem.Name = "KillProcessToolStripMenuItem"
        Me.KillProcessToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.KillProcessToolStripMenuItem.Text = "Kill Process"
        '
        'ViewUsersToolStripMenuItem
        '
        Me.ViewUsersToolStripMenuItem.Name = "ViewUsersToolStripMenuItem"
        Me.ViewUsersToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.ViewUsersToolStripMenuItem.Text = "View Users"
        '
        'MessageToolStripMenuItem
        '
        Me.MessageToolStripMenuItem.Name = "MessageToolStripMenuItem"
        Me.MessageToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.MessageToolStripMenuItem.Text = "Message"
        '
        'ComputerManagementToolStripMenuItem
        '
        Me.ComputerManagementToolStripMenuItem.Name = "ComputerManagementToolStripMenuItem"
        Me.ComputerManagementToolStripMenuItem.Size = New System.Drawing.Size(147, 20)
        Me.ComputerManagementToolStripMenuItem.Text = "Computer Management"
        '
        'AccessRightsToolStripMenuItem
        '
        Me.AccessRightsToolStripMenuItem.Name = "AccessRightsToolStripMenuItem"
        Me.AccessRightsToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.AccessRightsToolStripMenuItem.Text = "Access Rights"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 266)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Main Form"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewProcessListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KillProcessToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComputerManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccessRightsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
