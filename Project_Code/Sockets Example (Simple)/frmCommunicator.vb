Imports System.Diagnostics 'Old
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.IO.Ports
Imports Sockets_Example_Simple.SMSapplication
Imports System.Threading
Imports System.Net.Mail
Imports System.Net.Mail.SmtpClient
Imports System.Windows.Forms.TreeView

Public Class frmCommunicator
    Private port As New SerialPort()
    Private objclsSMS As New clsSMS()
    Private objShortMessageCollection As New ShortMessageCollection()

    Dim strMobileNo As String
    Dim strarray(10000) As String
    Dim a As Integer
    Dim blForProcessList As Boolean
    Dim intCommandTypeID As Integer
    Dim intConnectionNumber As Integer
    ' intCommandTypeID = 1 then TaskList
    ' intCommandTypeID = 2 then KillTask
#Region "Server Code"
    Private Server As socketServer
    Private ServerOn As Boolean = False
    Private InUse() As Boolean
    Private IPAdd(10) As String
    Private IPDisConnet(10) As String
    Private IPConnectionName(10) As String
    Private IPUserName(10) As String

    Private Sub serverLogMessage(ByVal Message As String)
        Delegates.RichTextBoxes.appendText(Me, rtbServer, vbCrLf & Message)
    End Sub

    Private Sub serverLogMessagePL(ByVal Message As String)
        Delegates.RichTextBoxes.appendText(Me, txtProcessList, vbCrLf & Message)
    End Sub

    Private Sub serverLogMessageLST(ByVal Message As String)
        Delegates1.ListBoxes.appendText(Me, lstProcesses, vbCrLf & Message)
    End Sub
    Private Sub serverSendToAllConnected(ByVal User As String, ByVal Message As String, Optional ByVal ExceptSock As Integer = -1)
        'If isArraySafe(InUse) Then
        '    For i As Integer = 0 To InUse.Length - 1
        '        If Not (i = ExceptSock) Then
        '            If InUse(i) Then
        '                Server.Send(i, "Server:  " & Message)
        '            End If
        '        End If
        '    Next
        'End If
        '
        If isArraySafe(InUse) Then
            For i As Integer = 0 To InUse.Length - 1
                If (i = ExceptSock) Or ExceptSock = -1 Then
                    If InUse(i) Then
                        Server.Send(i, "Server:  " & Message)
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub txtServeSend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServeSend.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Server IsNot Nothing Then
                serverSendToAllConnected("Server", txtServeSend.Text, cmbIpList.SelectedIndex)
                serverLogMessage("Server:  " & txtServeSend.Text)
                txtServeSend.Text = ""
            End If
        End If
    End Sub

    Private Sub btnStopServe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopServe.Click
        If Server Is Nothing Then
            Exit Sub
        Else
            If ServerOn = False Then
                Exit Sub
            Else
                Server.stopListen(True)
                serverLogMessage("Server stopped.")
                ServerOn = False
            End If
        End If
    End Sub

    Private Sub btnServe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServe.Click
        If Server Is Nothing Then
            Server = New socketServer()
        Else
            If ServerOn = False Then
                Server = New socketServer()
            Else
                Exit Sub
            End If
        End If

        ServerOn = True

        AddHandler Server.IncomingData, AddressOf handleServerIncomingData
        AddHandler Server.Connected, AddressOf handleServerConnected
        AddHandler Server.ConnectionError, AddressOf handleServerConnectionError
        AddHandler Server.ConnectionRefused, AddressOf handleServerConnectionRefused
        AddHandler Server.Disconnected, AddressOf handleServerDisconnected
        AddHandler Server.DisconnectError, AddressOf handleServerDisconnectError
        AddHandler Server.IncomingDataError, AddressOf handleServerIncomingDataError
        AddHandler Server.ListenError, AddressOf handleServerListenError
        AddHandler Server.SendDataError, AddressOf handleServerSendDataError

        ReDim InUse(63)

        Server.Listen(64, txtServePort.Text)

        serverLogMessage("Server Started")

        'Dim ports As String() = SerialPort.GetPortNames()
        'Me.port = objclsSMS.OpenPort("COM3", 9600, 8, 300, 300)

        'Dim t As Thread
        't = New Thread(AddressOf Me.BackgroundProcess)
        't.Start()
    End Sub

    '************************************************************
    'Primary Socket Functionality
    '************************************************************
    Private Sub handleServerIncomingData(ByVal Sock As Integer, ByRef Data As String)
        '
        If Data.Length > 0 Then
            '
            If Data.Length > 20 Then
                If Data.Substring(0, 20) = "Server: SendTaskList" Then
                    Dim strMsg As String
                    strMsg = Data.Substring(20, (Len(Data) - 20))
                    objclsSMS.sendMsg(Me.port, strMobileNo, strMsg)
                    Exit Sub
                End If
            End If
            '
            If Data.Length > 16 Then
                If Data.Substring(0, 16) = "Server: TaskList" Then
                    serverLogMessagePL(Data)
                    Exit Sub
                End If
            End If
            '
            '    If Data.Substring(0, 10) = "ClientName" Then
            '        Dim StringArray() As String = Split(Data)
            '        If StringArray(0) <> "" Then
            '            For i As Integer = 0 To 11
            '                If IPAdd(i) = Nothing Then
            '                    Exit For
            '                End If
            '                If IPConnectionName(i) = StringArray(1) Then
            '                    serverSendToAllConnected("Server", "Ctl", i)
            '                    IPAdd(i) = StringArray(2)
            '                End If
            '            Next
            '        End If
            '    End If
            '    Exit Sub
            'End If
            If Data.Substring(0, 2) = "IP" Then
                Dim strDisConnectedClient As String
                strDisConnectedClient = Data.Substring(2, Len(Data) - 2)
                For i As Integer = 0 To 11
                    If IPAdd(i) = Nothing Then
                        Exit Sub
                    End If
                    If IPConnectionName(i) = strDisConnectedClient Then
                        IPDisConnet(i) = IPAdd(i)
                    End If
                    'If IPUserName(i) = strDisConnectedClient Then
                    '    IPDisConnet(i) = IPAdd(i)
                    'End If
                Next
                Exit Sub
            End If
            '
            serverLogMessage(Data)
            '
        End If
    End Sub

    Private Sub handleServerConnected(ByVal Sock As Integer, ByVal RemoteAddress As String)
        Dim strConnectionName As String
        Dim StringArray() As String = Split(RemoteAddress, ":")
        serverLogMessage("Connection from " & RemoteAddress & " to socket space " & Sock & ".")
        InUse(Sock) = True
        IPAdd(Sock) = StringArray(0)
        strConnectionName = "Connection" + intConnectionNumber.ToString()
        intConnectionNumber = intConnectionNumber + 1
        IPConnectionName(Sock) = strConnectionName
        serverSendToAllConnected("Server", "Connection" + strConnectionName, Sock)
    End Sub

    Private Sub handleServerConnectionRefused(ByVal Message As String)
        serverLogMessage(Message)
    End Sub

    Private Sub handleServerDisconnected(ByVal Sock As Integer)
        InUse(Sock) = False
        IPDisConnet(Sock) = IPAdd(Sock)
    End Sub

    '************************************************************
    'Functional Error Reporting (Below)
    '************************************************************
    Private Sub handleServerConnectionError(ByVal Sock As Integer, ByVal Message As String)
        serverLogMessage("Socket " & Sock & ":  " & Message)
    End Sub

    Private Sub handleServerDisconnectError(ByVal Sock As Integer, ByVal Message As String)
        serverLogMessage("Socket " & Sock & ":  " & Message)
    End Sub

    Private Sub handleServerIncomingDataError(ByVal Sock As Integer, ByVal Message As String)
        serverLogMessage("Socket " & Sock & ":  " & Message)
    End Sub

    Private Sub handleServerListenError(ByVal Message As String)
        serverLogMessage("Error:  " & Message)
        ServerOn = False
    End Sub

    Private Sub handleServerSendDataError(ByVal Sock As Integer, ByVal Message As String)
        serverLogMessage("Socket " & Sock & ":  " & Message)
    End Sub
#End Region

#Region "Client Code"
    Private Client As socketClient

    Private Sub clientLogMessage(ByVal Message As String)
        Delegates.RichTextBoxes.appendText(Me, rtbClient, vbCrLf & Message)
    End Sub

    Private Sub btnClientConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientConnect.Click
        Client = New socketClient()
        AddHandler Client.Connected, AddressOf handleClientConnected
        AddHandler Client.ConnectionError, AddressOf handleClientConnectionError
        AddHandler Client.Disconnected, AddressOf handleClientDisconnected
        AddHandler Client.DisconnectError, AddressOf handleClientDisconnectError
        AddHandler Client.IncomingData, AddressOf handleClientIncomingData
        AddHandler Client.IncomingDataError, AddressOf handleClientIncomingDataError
        AddHandler Client.SendDataError, AddressOf handleClientSendDataError

        Client.Connect(txtClientIP.Text, txtClientPort.Text)
    End Sub

    Private Sub txtClientSend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClientSend.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            If Client IsNot Nothing Then
                If Client.isConnected Then
                    Client.Send(txtClientName.Text & ":  " & txtClientSend.Text)
                    clientLogMessage(txtClientName.Text & ":  " & txtClientSend.Text)
                    txtClientSend.Text = ""
                End If
            End If
        End If
    End Sub

    '************************************************************
    'Primary Socket Functionality
    '************************************************************
    Private Sub handleClientConnected()
        clientLogMessage("Connected!")
    End Sub

    Private Sub handleClientDisconnected()
        clientLogMessage("Disconnected!")
    End Sub

    Private Sub handleClientIncomingData(ByRef Data As String)
        Dim str As String
        str = "Server:  "
        If Data = "Server:  TaskList" Then
            Dim process As New Process()
            Dim FileName As String = "tasklist"
            process.StartInfo.UseShellExecute = False
            process.StartInfo.RedirectStandardOutput = True
            process.StartInfo.RedirectStandardError = True
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.FileName = FileName
            process.Start()
            Dim output As String = process.StandardOutput.ReadToEnd()
            blForProcessList = True
            Client.Send("Server: TaskList" + output)
            Exit Sub
        End If

        If Data.Substring(0, 17) = "Server: KillTask" Then
            Dim pr_name As String
            Dim p As Process

            pr_name = lstProcesses.GetItemText(Data.Substring(18, (Len(Data))))

            For Each p In System.Diagnostics.Process.GetProcessesByName(pr_name)
                p.Kill()
                p.WaitForExit()
            Next
            Exit Sub
        End If
        If Data.Length > 0 Then
            'Shell(Data.Remove(0, str.Length))
            clientLogMessage(Data)
        End If
        ' anand
    End Sub


    '************************************************************
    'Functional Error Reporting (Below)
    '************************************************************
    Private Sub handleClientConnectionError(ByVal Message As String)
        clientLogMessage(Message)
    End Sub

    Private Sub handleClientDisconnectError(ByVal Message As String)
        clientLogMessage(Message)
    End Sub

    Private Sub handleClientIncomingDataError(ByVal Message As String)
        clientLogMessage(Message)
    End Sub

    Private Sub handleClientSendDataError(ByVal Message As String)
        clientLogMessage(Message)
    End Sub
#End Region

    Private Sub frmCommunicator_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub btnClientDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClientDisconnect.Click
        Client.Disconnect()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    txtProcessList.Text = ""
    '    serverSendToAllConnected("Server", "TaskList", cmbIpList.SelectedIndex)
    'End Sub

    Public Sub ShowfrmComunitor(ByVal strModuleName As String)
        If strModuleName = "ManageProcessList" Then
            GroupBox1.Visible = False
            GroupBox2.Visible = False
            GroupBox3.Visible = True
        ElseIf strModuleName = "Communicator" Then
            GroupBox1.Visible = True
            GroupBox2.Visible = False
            GroupBox3.Visible = False
        ElseIf strModuleName = "KillProcess" Then
            GroupBox1.Visible = False
            GroupBox2.Visible = False
            GroupBox3.Visible = True
        ElseIf strModuleName = "AccessRights" Then
            GroupBox1.Visible = False
            GroupBox2.Visible = False
        End If
        Me.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        serverSendToAllConnected("Server:", "KillTask " + TextBox2.Text, cmbIpList.SelectedIndex)

        'http://vb.net-informations.com/communications/vb.net_smtp_mail.htm
        'https://social.msdn.microsoft.com/Forums/en-US/85bcab1f-4faa-41f4-9fc7-654f1ab08735/a-problem-with-sending-email?forum=vblanguage
        Try
            Dim SMTPServer As New SmtpClient("smtp.gmail.com")
            Dim mail As New MailMessage()
            Dim a As String
            Dim dd As Date = DateTime.Now.ToString("hh:mm dddd, dd MMMM yyyy")
            a = ("the process killed on" & dd & TextBox2.Text)
            SMTPServer.Port = 587
            SMTPServer.Host = "smtp.gmail.com"
            SMTPServer.EnableSsl = True
            SMTPServer.Credentials = New System.Net.NetworkCredential("project.tpo@gmail.com", "AB1234cd@")
            mail = New MailMessage()
            mail.From = New MailAddress("project.tpo@gmail.com")
            mail.To.Add("sprerak789@gmail.com")
            mail.Subject = "kill process"
            mail.Body = a
            SMTPServer.Send(mail)
            MsgBox("mail send")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        '   Dim CDOSYS As Object
        '  Const cdoSendUsingPickup = 1
        ' Const strPickup = "c:\inetpub\ftproot"
        '  CDOSYS = CreateObject("CDO.Message")

        '  CDOSYS.Configuration.Fields.item() _
        '("http://schemas.microsoft.com/cdo/configuration/sendusing") _
        '= cdoSendUsingPickup

        '  CDOSYS.Configuration.Fields.item _
        '("http://schemas.microsoft.com/cdo/configuration" & _
        '/smtpserverpickupdirectory")  _
        '= strPickup

        ' CDOSYS.Configuration.Fields.Update()
        ' CDOSYS.To = "sprerak789@gmail.com"
        ' CDOSYS.From = "vrutikshah123@gmail.com"
        ' CDOSYS.Subject = "CDO Test"
        ' CDOSYS.TextBody = "Send Email from vb.net using CDOSYS"
        ' CDOSYS.Send()
        ' CDOSYS = Nothing
        '  MsgBox("mail send")

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IPList()
    End Sub

    Private Sub frmCommunicator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Visible = False
    End Sub
    Private Sub IPList()
        'txtProcessList.Visible = False
        cmbIpList.Text = ""
        cmbIpList.Items.Clear()
        If isArraySafe(IPAdd) Then
            For i As Integer = 0 To IPAdd.Length - 1
                If IPAdd(i) = Nothing Then
                    Exit Sub
                End If
                If IPAdd(i) <> IPDisConnet(i) Then
                    cmbIpList.Items.Add(IPAdd(i))
                    cmbIpList.ValueMember = i
                End If
            Next
        End If
    End Sub

    Private Sub MessagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessagesToolStripMenuItem.Click
        GroupBox1.Visible = True
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GroupBox4.Visible = False
        GetIpList.Visible = False
        Button3.Visible = False
        Me.Height = 550
        Me.Width = 594
    End Sub

    Private Sub ProcessListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessListToolStripMenuItem.Click
        GroupBox3.Visible = True
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox4.Visible = False
        GetIpList.Visible = True
        Button3.Visible = True
        Me.Height = 550
        Me.Width = 594
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Shutdown.Checked = True Then
            serverSendToAllConnected("Server", "ShutDown", cmbIpList.SelectedIndex)
        ElseIf Restart.Checked = True Then
            serverSendToAllConnected("Server", "ReStart", cmbIpList.SelectedIndex)
        ElseIf LogOff.Checked = True Then
            serverSendToAllConnected("Server", "LogOff", cmbIpList.SelectedIndex)
        End If
    End Sub

    Private Sub ComputerManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComputerManagementToolStripMenuItem.Click
        GroupBox4.Visible = True
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GetIpList.Visible = False
        Button3.Visible = False
        Me.Height = 400
        Me.Width = 600
    End Sub
    Private Sub AccessRightsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        GroupBox4.Visible = False
        GroupBox1.Visible = False
        GroupBox2.Visible = False
        GroupBox3.Visible = False
        GetIpList.Visible = False
        Me.Height = 400
        Me.Width = 400
    End Sub
    Private Sub BackgroundProcess()
        '
        Do While True
            Dim uReadCountSMS As Integer = objclsSMS.CountSMSmessages(Me.port)
            If uReadCountSMS > 0 Then
                Dim strCommand As String = "AT+CMGDA=""DEL READ"""
                objclsSMS.DeleteMsg(Me.port, strCommand)
            End If
            '
            Thread.Sleep(10000)
            '
            Dim uCountSMS As Integer = objclsSMS.CountSMSmessages(Me.port)
            If uCountSMS > 0 Then
                Dim strCommand As String = "AT+CMGL=""ALL"""
                'Dim strCommand As String = "AT+CMGL=""REC UNREAD"""
                'If Me.rbReadAll.Checked Then
                '    strCommand = "AT+CMGL=""ALL"""
                'ElseIf Me.rbReadUnRead.Checked Then
                '    strCommand = "AT+CMGL=""REC UNREAD"""
                'ElseIf Me.rbReadStoreSent.Checked Then
                '    strCommand = "AT+CMGL=""STO SENT"""
                'ElseIf Me.rbReadStoreUnSent.Checked Then
                '    strCommand = "AT+CMGL=""STO UNSENT"""
                'End If
                objShortMessageCollection = objclsSMS.ReadSMS(Me.port, strCommand)
                For Each msg As ShortMessage In objShortMessageCollection

                    Dim item As New ListViewItem(New String() {msg.Index, msg.Sent, msg.Sender, msg.Message})
                    item.Tag = msg

                    'lvwMessages1.Items.Add(item)
                    Dim strMsg As String
                    strMsg = msg.Message
                    Dim strSender As String
                    strSender = msg.Sender
                    '
                    If strSender = "+91" + strMobileNo Then
                        Dim StringArray() As String = Split(strMsg)

                        If (StringArray(0) <> "ip" And StringArray(0) <> "msg" And StringArray(0) <> "ctl" And _
                        StringArray(0) <> "logoff" And StringArray(0) <> "restart" And StringArray(0) <> "shutdown" And StringArray(0) <> "kill") Then
                            objclsSMS.sendMsg(Me.port, strMobileNo, "Your message is invalid. Please send correct message.")
                            Exit For
                        End If

                        If StringArray.Length = 1 Then
                            If (StringArray(0) = "ip") Then
                                '
                                Dim strIpList As String
                                For i As Integer = 0 To IPAdd.Length - 1
                                    If IPAdd(i) = Nothing Then
                                        Exit For
                                    End If
                                    strIpList = strIpList + IPAdd(i) + ","
                                    objclsSMS.sendMsg(Me.port, strMobileNo, strIpList)
                                    Thread.Sleep(30000)
                                Next
                            End If
                        End If

                        If StringArray.Length = 2 Then
                            If StringArray(0) <> "" Then
                                For i As Integer = 0 To 11
                                    If IPAdd(i) = Nothing Then
                                        Exit For
                                    End If
                                    '
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "ctl") Then
                                        serverSendToAllConnected("Server", "SendTaskList", i)
                                    End If
                                    '
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "logoff") Then
                                        serverSendToAllConnected("Server", "LogOff", i)
                                    End If
                                    '
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "restart") Then
                                        serverSendToAllConnected("Server", "ReStart", i)
                                    End If
                                    '
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "shutdown") Then
                                        serverSendToAllConnected("Server", "ShutDown", i)
                                    End If
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "Read") Then
                                        serverSendToAllConnected("Server", "Read", i)
                                    End If
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "Write") Then
                                        serverSendToAllConnected("Server", "Write", i)
                                    End If
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "Full") Then
                                        serverSendToAllConnected("Server", "Full", i)
                                    End If
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "None") Then
                                        serverSendToAllConnected("Server", "None", i)
                                    End If
                                    '
                                Next
                            End If
                        End If
                        If StringArray.Length = 3 Then
                            If StringArray(0) <> "" Then
                                For i As Integer = 0 To 11
                                    If IPAdd(i) = Nothing Then
                                        Exit For
                                    End If
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "kill") Then
                                        serverSendToAllConnected("Server:", "KillTask " + StringArray(2), i)
                                    End If
                                    '
                                Next
                            End If
                        End If
                        If StringArray.Length > 3 Then
                            If StringArray(0) <> "" Then
                                For i As Integer = 0 To 11
                                    If IPAdd(i) = Nothing Then
                                        Exit For
                                    End If
                                    '
                                    Dim a As String
                                    a = strMsg.Substring(4 + Len(StringArray(1)), Len(strMsg) - (4 + Len(StringArray(1))))
                                    If IPAdd(i) = StringArray(1) And (StringArray(0) = "msg") Then
                                        serverSendToAllConnected("Server:", a, i)
                                    End If
                                Next
                            End If
                        End If

                        'If strMsg = "LogOff" Then
                        '    serverSendToAllConnected("Server", strMsg, 1)
                        'End If

                        'If strMsg = "ReStart" Then
                        '    serverSendToAllConnected("Server", strMsg, 1)
                        'End If

                        'If strMsg = "ShutDown" Then
                        '    serverSendToAllConnected("Server", strMsg, 1)
                        'End If

                        'If strMsg = "Ctl" Then
                        '    serverSendToAllConnected("Server", "SendTaskList", 0)
                        'End If
                        '
                    End If
                Next
            End If
            '
            Thread.Sleep(1000)
            '
        Loop
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        IPList()
    End Sub

    Private Sub GetIpList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetIpList.Click
        txtProcessList.Text = ""
        serverSendToAllConnected("Server", "TaskList", cmbIpList.SelectedIndex)
    End Sub

    Public Sub frmCommShow(ByVal stroutMobileNo As String)
        strMobileNo = stroutMobileNo
        Me.Show()
    End Sub

    ' Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Dim log As String = txtProcessList.Text
    '  My.Computer.FileSystem.WriteAllText(
    '"C:\Documents and Settings\Admin\My Documents\LAMON\dateus.docx", log, True)
    ' End Sub

    Public Sub Button3_Click_2(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim dd As Date = DateTime.Now.ToString("hh:mm dddd, dd MMMM yyyy")
        Dim log As String = txtProcessList.Text
        My.Computer.FileSystem.WriteAllText("D:\Final edited\log.rtf", log, True)

        Try
            Dim SMTPServer As New SmtpClient("smtp.gmail.com")
            Dim mail As New MailMessage()
            Dim a As String
            Dim d As Date = DateTime.Now.ToString("hh:mm dddd, dd MMMM yyyy")
            a = ("The following mail also contains log file attached to it ...ON.." & d)
            Dim attachment As System.Net.Mail.Attachment
            attachment = New System.Net.Mail.Attachment("D:\Final edited\log.rtf")

            SMTPServer.Port = 587
            SMTPServer.Host = "smtp.gmail.com"
            SMTPServer.EnableSsl = True
            SMTPServer.Credentials = New System.Net.NetworkCredential("project.tpo@gmail.com", "AB1234cd@")
            mail = New MailMessage()
            mail.From = New MailAddress("project.tpo@gmail.com")
            mail.To.Add("sprerak789@gmail.com")
            mail.Subject = "Log file"
            mail.Body = a
            mail.Attachments.Add(attachment)
            SMTPServer.Send(mail)
            'MsgBox("mail send")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Give.Click
        If Read.Checked = True Then
            serverSendToAllConnected("Server", "Read", cmbIpList.SelectedIndex)
        ElseIf Write.Checked = True Then
            serverSendToAllConnected("Server", "Write", cmbIpList.SelectedIndex)
        ElseIf Full.Checked = True Then
            serverSendToAllConnected("Server", "Full", cmbIpList.SelectedIndex)
        ElseIf RadioButton1.Checked = True Then
            serverSendToAllConnected("Server", "None", cmbIpList.SelectedIndex)
        End If
    End Sub

    Private Sub access_Enter(sender As System.Object, e As System.EventArgs)
        Read.Visible = True
        Write.Visible = True
        RadioButton1.Visible = True
        Full.Visible = True
        Give.Visible = True
    End Sub
 
End Class

