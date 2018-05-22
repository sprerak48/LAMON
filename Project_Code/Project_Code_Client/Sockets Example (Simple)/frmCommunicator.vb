Imports System.Diagnostics 'Old
Imports System.Net.Dns
'Imports System.Net.Dns.GetHostName
Imports System.Net
Imports System.Xml

Imports System.IO
Imports System.IO.Path
Imports System.Web
Imports System.Runtime.Remoting.Activation
Imports System.Web.AspNetHostingPermissionAttribute
Imports System.Collections
Imports System.ComponentModel
Imports System.Data

'Imports System.Xml.Linq
Imports System.Drawing
Imports System.Text
Imports System.Threading


Public Class frmCommunicator
    Public xmlDoc1, xmlDoc2 As String
    Public responsee As String
    Dim strarray(10000) As String
    Dim a As Integer
    Dim blForProcessList As Boolean
    Dim intCommandTypeID As Integer
    Dim strConnectionName As String
    ' intCommandTypeID = 1 then TaskList
    ' intCommandTypeID = 2 then KillTask
#Region "Server Code"
    Private Server As socketServer
    Private ServerOn As Boolean = False
    Private InUse() As Boolean
    Private IPAdd(10) As String

    Private Sub serverLogMessage(ByVal Message As String)
        Delegates.RichTextBoxes.appendText(Me, rtbServer, vbCrLf & Message)
    End Sub

    Private Sub serverLogMessagePL(ByVal Message As String)
        Delegates.RichTextBoxes.appendText(Me, txtProcessList, vbCrLf & Message)
    End Sub

    Private Sub serverSendToAllConnected(ByVal User As String, ByVal Message As String, Optional ByVal ExceptSock As Integer = -1)
        If isArraySafe(InUse) Then
            For i As Integer = 0 To InUse.Length - 1
                If Not (i = ExceptSock) Then
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
                serverSendToAllConnected("Server", txtServeSend.Text, 1)
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
                serverLogMessage("No longer serving.")
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

        serverLogMessage("Now serving.")
    End Sub

    '************************************************************
    'Primary Socket Functionality
    '************************************************************
    Private Sub handleServerIncomingData(ByVal Sock As Integer, ByRef Data As String)
        If Data.Length > 0 Then
            If Data.Substring(0, 16) = "Server: TaskList" Then
                serverLogMessagePL(Data)
            Else
                serverLogMessage(Data)
            End If
        End If
    End Sub

    Private Sub handleServerConnected(ByVal Sock As Integer, ByVal RemoteAddress As String)
        serverLogMessage("Connection from " & RemoteAddress & " to socket space " & Sock & ".")
        InUse(Sock) = True
        IPAdd(Sock) = RemoteAddress
    End Sub

    Private Sub handleServerConnectionRefused(ByVal Message As String)
        serverLogMessage(Message)
    End Sub

    Private Sub handleServerDisconnected(ByVal Sock As Integer)
        serverLogMessage("Socket " & Sock & ":  Disconnected.")
        InUse(Sock) = False
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
        Dim t As Thread
        t = New Thread(AddressOf Me.backgroundprocess)
        t.Start()
        'Client.Send("ClientName" + strConnectionName + txtClientName.Text)
    End Sub

    Public Sub backgroundprocess()
        Dim strHostName As String = System.Windows.Forms.SystemInformation.ComputerName
        Dim strIPAddress As String
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        Do While True
            handleClientIncomingData("Server:  TaskList")
            Thread.Sleep(50000)
            xmlDoc1 = "<Processlist><getlist>" & strIPAddress & "</getlist></Processlist>"
            Dim request1 As HttpWebRequest = DirectCast(WebRequest.Create("http://my-demo.in/lan_monitoring_service/Service1.svc/Get_process"), HttpWebRequest) 'create a new HttpwebRequest for Service URL
            Dim doc As New XmlDocument                     'Create new XML
            doc.LoadXml(xmlDoc1)                             'Write that xmlDoc1 string in XML
            request1.Method = "POST"                        'Set method of request
            request1.ContentType = "text/xml;charset=utf-8" 'set content type of request
            request1.ContentLength = xmlDoc1.Length         'set length pf request
            request1.KeepAlive = False
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(xmlDoc1) 'encodes xmldoc1 string in bytes & assign it to byte array
            Dim resp As Stream = request1.GetRequestStream() 'here request stream is assign to new stream variable
            resp.Write(bytes, 0, bytes.Length)               'writes each byte of bytes array & request sends to service
            resp.Close()                                     'stream closed here

            resp = DirectCast(request1.GetResponse(), HttpWebResponse).GetResponseStream() 'here get response from web service
            Dim rdr As New StreamReader(resp)
            responsee = rdr.ReadToEnd()
            Dim ds As New DataSet()
            ds.ReadXml(New StringReader(responsee))
            Dim IPaddress As String = ds.Tables(0).Rows(0)("IPAddress").ToString()
            Dim name As String = ds.Tables(0).Rows(0)("name").ToString()
            Dim p As Process
            For Each p In System.Diagnostics.Process.GetProcessesByName(name)
                p.Kill()
                p.WaitForExit()
            Next
            Thread.Sleep(10000)
            'Dim strHostName As String = System.Windows.Forms.SystemInformation.ComputerName
            'Dim strIPAddress As String
            'strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
            'Threading.Thread.Sleep(10000)
            'Exit Do

        Loop
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
        Dim strHostName As String = System.Windows.Forms.SystemInformation.ComputerName
        Dim strIPAddress As String
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()


        Dim str As String
        Dim command As String

        str = "Server:  "
        '
        If Len(Data) > 22 Then
            If Data.Substring(0, 19) = "Server:  Connection" Then '-- FOR PROCESS LIST
                strConnectionName = Data.Substring(19, Len(Data) - 19)
            End If
        End If
        '
        If Data = "Server:  LogOff" Then '--FOR LOGOFF
            command = "Shutdown -l"
            Shell(command)
            Exit Sub
        End If
        '
        If Data = "Server:  ShutDown" Then '--FOR SHUTDOWN
            command = "Shutdown -s"
            Shell(command)
            Exit Sub
        End If
        '
        If Data = "Server:  ReStart" Then '--FOR RESTART
            command = "Shutdown -r"
            Shell(command)
            Exit Sub
        End If
        '
        If Data = "Server:  SendTaskList" Then
            Dim strdata As String
            Dim p As Process
            For Each p In Process.GetProcesses()
                If p.ProcessName = "notepad" Or p.ProcessName = "calc" Or p.ProcessName = "wmplayer" Or p.ProcessName = "winword" Then
                    strdata = strdata + p.ProcessName + ","
                End If
            Next
            Client.Send("Server: SendTaskList" + strdata)
        End If
        '
        If Data = "Server:  TaskList" Then '-- FOR PROCESS LIST
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

            For Each process In process.GetProcesses()
                If process.ProcessName = "notepad" Then
                    xmlDoc2 = "<insert_process><IPAddress>" & strIPAddress & "</IPAddress><Name>" & process.ProcessName & "</Name></insert_process>"
                    Dim request1 As HttpWebRequest = DirectCast(WebRequest.Create("http://my-demo.in/lan_monitoring_service/Service1.svc/insert_process"), HttpWebRequest) 'create a new HttpwebRequest for Service URL
                    Dim doc As New XmlDocument                     'Create new XML
                    doc.LoadXml(xmlDoc2)                             'Write that xmlDoc1 string in XML
                    request1.Method = "POST"                        'Set method of request
                    request1.ContentType = "text/xml;charset=utf-8" 'set content type of request
                    request1.ContentLength = xmlDoc2.Length         'set length pf request
                    request1.KeepAlive = False
                    Dim bytes As Byte() = Encoding.UTF8.GetBytes(xmlDoc2) 'encodes xmldoc1 string in bytes & assign it to byte array
                    Dim resp As Stream = request1.GetRequestStream() 'here request stream is assign to new stream variable
                    resp.Write(bytes, 0, bytes.Length)               'writes each byte of bytes array & request sends to service
                    resp.Close()                                     'stream closed here

                    resp = DirectCast(request1.GetResponse(), HttpWebResponse).GetResponseStream() 'here get response from web service
                    Dim rdr As New StreamReader(resp)
                    responsee = rdr.ReadToEnd()
                    Dim ds As New DataSet()
                End If
                If process.ProcessName = "calc" Then
                    xmlDoc2 = "<insert_process><IPAddress>" & strIPAddress & "</IPAddress><Name>" & process.ProcessName & "</Name></insert_process>"
                    Dim request1 As HttpWebRequest = DirectCast(WebRequest.Create("http://my-demo.in/lan_monitoring_service/Service1.svc/insert_process"), HttpWebRequest) 'create a new HttpwebRequest for Service URL
                    Dim doc As New XmlDocument                     'Create new XML
                    doc.LoadXml(xmlDoc2)                             'Write that xmlDoc1 string in XML
                    request1.Method = "POST"                        'Set method of request
                    request1.ContentType = "text/xml;charset=utf-8" 'set content type of request
                    request1.ContentLength = xmlDoc2.Length         'set length pf request
                    request1.KeepAlive = False
                    Dim bytes As Byte() = Encoding.UTF8.GetBytes(xmlDoc2) 'encodes xmldoc1 string in bytes & assign it to byte array
                    Dim resp As Stream = request1.GetRequestStream() 'here request stream is assign to new stream variable
                    resp.Write(bytes, 0, bytes.Length)               'writes each byte of bytes array & request sends to service
                    resp.Close()                                     'stream closed here

                    resp = DirectCast(request1.GetResponse(), HttpWebResponse).GetResponseStream() 'here get response from web service
                    Dim rdr As New StreamReader(resp)
                    responsee = rdr.ReadToEnd()
                    Dim ds As New DataSet()
                End If
                If process.ProcessName = "winword" Then
                    xmlDoc2 = "<insert_process><IPAddress>" & strIPAddress & "</IPAddress><Name>" & process.ProcessName & "</Name></insert_process>"
                    Dim request1 As HttpWebRequest = DirectCast(WebRequest.Create("http://my-demo.in/lan_monitoring_service/Service1.svc/insert_process"), HttpWebRequest) 'create a new HttpwebRequest for Service URL
                    Dim doc As New XmlDocument                     'Create new XML
                    doc.LoadXml(xmlDoc2)                             'Write that xmlDoc1 string in XML
                    request1.Method = "POST"                        'Set method of request
                    request1.ContentType = "text/xml;charset=utf-8" 'set content type of request
                    request1.ContentLength = xmlDoc2.Length         'set length pf request
                    request1.KeepAlive = False
                    Dim bytes As Byte() = Encoding.UTF8.GetBytes(xmlDoc2) 'encodes xmldoc1 string in bytes & assign it to byte array
                    Dim resp As Stream = request1.GetRequestStream() 'here request stream is assign to new stream variable
                    resp.Write(bytes, 0, bytes.Length)               'writes each byte of bytes array & request sends to service
                    resp.Close()                                     'stream closed here

                    resp = DirectCast(request1.GetResponse(), HttpWebResponse).GetResponseStream() 'here get response from web service
                    Dim rdr As New StreamReader(resp)
                    responsee = rdr.ReadToEnd()
                    Dim ds As New DataSet()
                End If
                If process.ProcessName = "wmplayer" Then
                    xmlDoc2 = "<insert_process><IPAddress>" & strIPAddress & "</IPAddress><Name>" & process.ProcessName & "</Name></insert_process>"
                    Dim request1 As HttpWebRequest = DirectCast(WebRequest.Create("http://my-demo.in/lan_monitoring_service/Service1.svc/insert_process"), HttpWebRequest) 'create a new HttpwebRequest for Service URL
                    Dim doc As New XmlDocument                     'Create new XML
                    doc.LoadXml(xmlDoc2)                             'Write that xmlDoc1 string in XML
                    request1.Method = "POST"                        'Set method of request
                    request1.ContentType = "text/xml;charset=utf-8" 'set content type of request
                    request1.ContentLength = xmlDoc2.Length         'set length pf request
                    request1.KeepAlive = False
                    Dim bytes As Byte() = Encoding.UTF8.GetBytes(xmlDoc2) 'encodes xmldoc1 string in bytes & assign it to byte array
                    Dim resp As Stream = request1.GetRequestStream() 'here request stream is assign to new stream variable
                    resp.Write(bytes, 0, bytes.Length)               'writes each byte of bytes array & request sends to service
                    resp.Close()                                     'stream closed here

                    resp = DirectCast(request1.GetResponse(), HttpWebResponse).GetResponseStream() 'here get response from web service
                    Dim rdr As New StreamReader(resp)
                    responsee = rdr.ReadToEnd()
                    Dim ds As New DataSet()
                End If
            Next
            Client.Send("Server: TaskList" + output)
            Exit Sub
        End If
        '
        If Data.Length > 20 Then
            Dim da = Data.Substring(0, 17) '-- FOR KILL PROCESS
            If da = "Server:  KillTask" Then
                Dim pr_name As String
                Dim p As Process
                pr_name = Data.Substring(18, (Len(Data) - 18))

                For Each p In System.Diagnostics.Process.GetProcessesByName(pr_name)
                    p.Kill()
                    p.WaitForExit()
                Next
                Exit Sub
            End If
            '
        End If
        '
        If Data.Length > 0 Then '-- FOR MESSAGESS
            'Shell(Data.Remove(0, str.Length))
            clientLogMessage(Data)
        End If
        ''
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
        Client.Send("IP" + strConnectionName)
        Client.Disconnect()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtProcessList.Text = ""
        serverSendToAllConnected("Server", "TaskList", 1)
    End Sub

    'Private Sub txtClientSend_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClientSend.TextChanged

    'End Sub

    'Private Sub rtbServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbServer.TextChanged

    'End Sub

    'Private Sub rtbClient_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbClient.TextChanged

    'End Sub
    Public Sub ShowfrmComunitor(ByVal strModuleName As String)
        If strModuleName = "ManageProcessList" Then
            GroupBox1.Visible = False
            GroupBox2.Visible = False
        ElseIf strModuleName = "Communicator" Then
            GroupBox1.Visible = True
            GroupBox2.Visible = True
        End If
        Me.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        serverSendToAllConnected("Server:", "KillTask " + TextBox2.Text, 1)
    End Sub

    Private Sub txtClientSend_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClientSend.TextChanged

    End Sub

    Private Sub frmCommunicator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sam As System.Net.IPAddress
        Dim sam1 As String
        With System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName())
            sam = New System.Net.IPAddress(.AddressList(0).Address)
            sam1 = sam.ToString
        End With
        Dim shostname As String
        shostname = System.Net.Dns.GetHostName
        txtClientName.Text = shostname

        ' backgroundprocess()

    End Sub

    Private Sub btnService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnService.Click
        backgroundprocess()
    End Sub

   
End Class

