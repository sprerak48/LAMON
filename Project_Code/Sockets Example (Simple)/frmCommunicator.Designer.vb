<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommunicator
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnStopServe = New System.Windows.Forms.Button()
        Me.txtServeSend = New System.Windows.Forms.TextBox()
        Me.rtbServer = New System.Windows.Forms.RichTextBox()
        Me.btnServe = New System.Windows.Forms.Button()
        Me.txtServePort = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstProcesses = New System.Windows.Forms.ListBox()
        Me.btnClientDisconnect = New System.Windows.Forms.Button()
        Me.btnClientConnect = New System.Windows.Forms.Button()
        Me.txtClientName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtClientIP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtClientPort = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClientSend = New System.Windows.Forms.TextBox()
        Me.rtbClient = New System.Windows.Forms.RichTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtProcessList = New System.Windows.Forms.RichTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Full = New System.Windows.Forms.RadioButton()
        Me.Write = New System.Windows.Forms.RadioButton()
        Me.Read = New System.Windows.Forms.RadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComputerManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Give = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.LogOff = New System.Windows.Forms.RadioButton()
        Me.Restart = New System.Windows.Forms.RadioButton()
        Me.Shutdown = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cmbIpList = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GetIpList = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnStopServe)
        Me.GroupBox1.Controls.Add(Me.txtServeSend)
        Me.GroupBox1.Controls.Add(Me.rtbServer)
        Me.GroupBox1.Controls.Add(Me.btnServe)
        Me.GroupBox1.Controls.Add(Me.txtServePort)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(568, 438)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Server Side"
        '
        'btnStopServe
        '
        Me.btnStopServe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStopServe.Location = New System.Drawing.Point(480, 40)
        Me.btnStopServe.Name = "btnStopServe"
        Me.btnStopServe.Size = New System.Drawing.Size(75, 23)
        Me.btnStopServe.TabIndex = 7
        Me.btnStopServe.Text = "Stop"
        Me.btnStopServe.UseVisualStyleBackColor = True
        '
        'txtServeSend
        '
        Me.txtServeSend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServeSend.Location = New System.Drawing.Point(8, 406)
        Me.txtServeSend.Name = "txtServeSend"
        Me.txtServeSend.Size = New System.Drawing.Size(552, 20)
        Me.txtServeSend.TabIndex = 6
        '
        'rtbServer
        '
        Me.rtbServer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbServer.Enabled = False
        Me.rtbServer.Location = New System.Drawing.Point(8, 64)
        Me.rtbServer.Name = "rtbServer"
        Me.rtbServer.Size = New System.Drawing.Size(552, 334)
        Me.rtbServer.TabIndex = 5
        Me.rtbServer.Text = ""
        '
        'btnServe
        '
        Me.btnServe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnServe.Location = New System.Drawing.Point(480, 16)
        Me.btnServe.Name = "btnServe"
        Me.btnServe.Size = New System.Drawing.Size(75, 23)
        Me.btnServe.TabIndex = 4
        Me.btnServe.Text = "Serve"
        Me.btnServe.UseVisualStyleBackColor = True
        '
        'txtServePort
        '
        Me.txtServePort.Location = New System.Drawing.Point(40, 16)
        Me.txtServePort.Name = "txtServePort"
        Me.txtServePort.Size = New System.Drawing.Size(40, 20)
        Me.txtServePort.TabIndex = 3
        Me.txtServePort.Text = "22170"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Port:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(90, 23)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(175, 20)
        Me.TextBox1.TabIndex = 9
        Me.TextBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(271, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Get ProcessList"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lstProcesses)
        Me.GroupBox2.Controls.Add(Me.btnClientDisconnect)
        Me.GroupBox2.Controls.Add(Me.btnClientConnect)
        Me.GroupBox2.Controls.Add(Me.txtClientName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtClientIP)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtClientPort)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtClientSend)
        Me.GroupBox2.Controls.Add(Me.rtbClient)
        Me.GroupBox2.Location = New System.Drawing.Point(574, 401)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(308, 384)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Client Side"
        '
        'lstProcesses
        '
        Me.lstProcesses.FormattingEnabled = True
        Me.lstProcesses.Location = New System.Drawing.Point(203, 64)
        Me.lstProcesses.Name = "lstProcesses"
        Me.lstProcesses.Size = New System.Drawing.Size(141, 277)
        Me.lstProcesses.TabIndex = 17
        '
        'btnClientDisconnect
        '
        Me.btnClientDisconnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClientDisconnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientDisconnect.Location = New System.Drawing.Point(236, 40)
        Me.btnClientDisconnect.Name = "btnClientDisconnect"
        Me.btnClientDisconnect.Size = New System.Drawing.Size(64, 23)
        Me.btnClientDisconnect.TabIndex = 16
        Me.btnClientDisconnect.Text = "Disconnect"
        Me.btnClientDisconnect.UseVisualStyleBackColor = True
        '
        'btnClientConnect
        '
        Me.btnClientConnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClientConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClientConnect.Location = New System.Drawing.Point(180, 40)
        Me.btnClientConnect.Name = "btnClientConnect"
        Me.btnClientConnect.Size = New System.Drawing.Size(56, 23)
        Me.btnClientConnect.TabIndex = 15
        Me.btnClientConnect.Text = "Connect"
        Me.btnClientConnect.UseVisualStyleBackColor = True
        '
        'txtClientName
        '
        Me.txtClientName.Location = New System.Drawing.Point(48, 40)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(128, 20)
        Me.txtClientName.TabIndex = 14
        Me.txtClientName.Text = "A User"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClientIP
        '
        Me.txtClientIP.Location = New System.Drawing.Point(48, 16)
        Me.txtClientIP.Name = "txtClientIP"
        Me.txtClientIP.Size = New System.Drawing.Size(128, 20)
        Me.txtClientIP.TabIndex = 12
        Me.txtClientIP.Text = "127.0.0.1"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "IP:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClientPort
        '
        Me.txtClientPort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClientPort.Location = New System.Drawing.Point(260, 16)
        Me.txtClientPort.Name = "txtClientPort"
        Me.txtClientPort.Size = New System.Drawing.Size(40, 20)
        Me.txtClientPort.TabIndex = 10
        Me.txtClientPort.Text = "22170"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(228, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Port:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClientSend
        '
        Me.txtClientSend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClientSend.Location = New System.Drawing.Point(8, 352)
        Me.txtClientSend.Name = "txtClientSend"
        Me.txtClientSend.Size = New System.Drawing.Size(292, 20)
        Me.txtClientSend.TabIndex = 8
        '
        'rtbClient
        '
        Me.rtbClient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbClient.Location = New System.Drawing.Point(8, 64)
        Me.rtbClient.Name = "rtbClient"
        Me.rtbClient.Size = New System.Drawing.Size(81, 280)
        Me.rtbClient.TabIndex = 7
        Me.rtbClient.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtProcessList)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(569, 437)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Get Processlist"
        Me.GroupBox3.Visible = False
        '
        'txtProcessList
        '
        Me.txtProcessList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProcessList.Location = New System.Drawing.Point(9, 21)
        Me.txtProcessList.Name = "txtProcessList"
        Me.txtProcessList.Size = New System.Drawing.Size(551, 381)
        Me.txtProcessList.TabIndex = 8
        Me.txtProcessList.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 413)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Process Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "IP Address"
        Me.Label5.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New System.Drawing.Point(82, 410)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(371, 20)
        Me.TextBox2.TabIndex = 10
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(459, 407)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(96, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Kill Process"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(148, 25)
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
        Me.Full.Location = New System.Drawing.Point(99, 69)
        Me.Full.Name = "Full"
        Me.Full.Size = New System.Drawing.Size(41, 17)
        Me.Full.TabIndex = 15
        Me.Full.TabStop = True
        Me.Full.Text = "Full"
        Me.Full.UseVisualStyleBackColor = True
        Me.Full.UseWaitCursor = True
        '
        'Write
        '
        Me.Write.AutoSize = True
        Me.Write.Location = New System.Drawing.Point(99, 46)
        Me.Write.Name = "Write"
        Me.Write.Size = New System.Drawing.Size(50, 17)
        Me.Write.TabIndex = 14
        Me.Write.TabStop = True
        Me.Write.Text = "Write"
        Me.Write.UseVisualStyleBackColor = True
        Me.Write.UseWaitCursor = True
        '
        'Read
        '
        Me.Read.AutoSize = True
        Me.Read.Location = New System.Drawing.Point(99, 26)
        Me.Read.Name = "Read"
        Me.Read.Size = New System.Drawing.Size(51, 17)
        Me.Read.TabIndex = 13
        Me.Read.TabStop = True
        Me.Read.Text = "Read"
        Me.Read.UseVisualStyleBackColor = True
        Me.Read.UseWaitCursor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(447, 27)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Log"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MessagesToolStripMenuItem, Me.ProcessListToolStripMenuItem, Me.ComputerManagementToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(582, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MessagesToolStripMenuItem
        '
        Me.MessagesToolStripMenuItem.Name = "MessagesToolStripMenuItem"
        Me.MessagesToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.MessagesToolStripMenuItem.Text = "Messages"
        '
        'ProcessListToolStripMenuItem
        '
        Me.ProcessListToolStripMenuItem.Name = "ProcessListToolStripMenuItem"
        Me.ProcessListToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.ProcessListToolStripMenuItem.Text = "Process List"
        '
        'ComputerManagementToolStripMenuItem
        '
        Me.ComputerManagementToolStripMenuItem.Name = "ComputerManagementToolStripMenuItem"
        Me.ComputerManagementToolStripMenuItem.Size = New System.Drawing.Size(147, 20)
        Me.ComputerManagementToolStripMenuItem.Text = "Computer Management"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Give)
        Me.GroupBox4.Controls.Add(Me.btnSubmit)
        Me.GroupBox4.Controls.Add(Me.RadioButton1)
        Me.GroupBox4.Controls.Add(Me.LogOff)
        Me.GroupBox4.Controls.Add(Me.Full)
        Me.GroupBox4.Controls.Add(Me.Restart)
        Me.GroupBox4.Controls.Add(Me.Shutdown)
        Me.GroupBox4.Controls.Add(Me.Write)
        Me.GroupBox4.Controls.Add(Me.Read)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 51)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(211, 129)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Computer Management"
        Me.GroupBox4.Visible = False
        '
        'Give
        '
        Me.Give.Location = New System.Drawing.Point(99, 94)
        Me.Give.Name = "Give"
        Me.Give.Size = New System.Drawing.Size(63, 23)
        Me.Give.TabIndex = 12
        Me.Give.Text = "Give"
        Me.Give.UseVisualStyleBackColor = True
        Me.Give.UseWaitCursor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Location = New System.Drawing.Point(6, 94)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(73, 22)
        Me.btnSubmit.TabIndex = 11
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'LogOff
        '
        Me.LogOff.AutoSize = True
        Me.LogOff.Location = New System.Drawing.Point(20, 69)
        Me.LogOff.Name = "LogOff"
        Me.LogOff.Size = New System.Drawing.Size(57, 17)
        Me.LogOff.TabIndex = 8
        Me.LogOff.TabStop = True
        Me.LogOff.Text = "LogOff"
        Me.LogOff.UseVisualStyleBackColor = True
        '
        'Restart
        '
        Me.Restart.AutoSize = True
        Me.Restart.Location = New System.Drawing.Point(20, 46)
        Me.Restart.Name = "Restart"
        Me.Restart.Size = New System.Drawing.Size(59, 17)
        Me.Restart.TabIndex = 7
        Me.Restart.TabStop = True
        Me.Restart.Text = "Restart"
        Me.Restart.UseVisualStyleBackColor = True
        '
        'Shutdown
        '
        Me.Shutdown.AutoSize = True
        Me.Shutdown.Location = New System.Drawing.Point(20, 24)
        Me.Shutdown.Name = "Shutdown"
        Me.Shutdown.Size = New System.Drawing.Size(73, 17)
        Me.Shutdown.TabIndex = 6
        Me.Shutdown.TabStop = True
        Me.Shutdown.Text = "Shutdown"
        Me.Shutdown.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 15000
        '
        'cmbIpList
        '
        Me.cmbIpList.FormattingEnabled = True
        Me.cmbIpList.Location = New System.Drawing.Point(48, 27)
        Me.cmbIpList.Name = "cmbIpList"
        Me.cmbIpList.Size = New System.Drawing.Size(131, 21)
        Me.cmbIpList.TabIndex = 5
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(185, 27)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(125, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Get - User"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GetIpList
        '
        Me.GetIpList.Location = New System.Drawing.Point(316, 27)
        Me.GetIpList.Name = "GetIpList"
        Me.GetIpList.Size = New System.Drawing.Size(125, 23)
        Me.GetIpList.TabIndex = 13
        Me.GetIpList.Text = "Get Process List"
        Me.GetIpList.UseVisualStyleBackColor = True
        Me.GetIpList.Visible = False
        '
        'frmCommunicator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 497)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.GetIpList)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cmbIpList)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmCommunicator"
        Me.Text = "Server"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnServe As System.Windows.Forms.Button
    Friend WithEvents txtServePort As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtServeSend As System.Windows.Forms.TextBox
    Friend WithEvents rtbServer As System.Windows.Forms.RichTextBox
    Friend WithEvents txtClientIP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtClientPort As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClientSend As System.Windows.Forms.TextBox
    Friend WithEvents rtbClient As System.Windows.Forms.RichTextBox
    Friend WithEvents btnClientConnect As System.Windows.Forms.Button
    Friend WithEvents txtClientName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnClientDisconnect As System.Windows.Forms.Button
    Friend WithEvents btnStopServe As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lstProcesses As System.Windows.Forms.ListBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtProcessList As System.Windows.Forms.RichTextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MessagesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProcessListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComputerManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents LogOff As System.Windows.Forms.RadioButton
    Friend WithEvents Restart As System.Windows.Forms.RadioButton
    Friend WithEvents Shutdown As System.Windows.Forms.RadioButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmbIpList As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GetIpList As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Full As System.Windows.Forms.RadioButton
    Friend WithEvents Write As System.Windows.Forms.RadioButton
    Friend WithEvents Read As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Give As System.Windows.Forms.Button

End Class
