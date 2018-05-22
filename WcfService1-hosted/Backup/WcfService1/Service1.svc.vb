' NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in Web.config and in the associated .svc file.

Imports System.Collections.Generic
Imports System.Text
Imports System.Data.SqlClient
Imports System.Linq
Imports System.IO
Imports System.IO.Path
Imports System.Web
Imports System.ServiceModel.Activation
Imports System.Web.AspNetHostingPermissionAttribute
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Xml
Imports System.Xml.Linq
Imports System.Web.UI.Page
Imports System.Runtime.Serialization
Imports System.Net.Mail
Imports System.Net

Public Class Service1
    Implements IService1
    Public xmldoc As New XmlDataDocument()
    Public xmlnode As XmlNodeList
    Dim conn As SqlConnection
    Dim comm As SqlCommand
    Public ds As Data.DataSet
    Public da As SqlDataAdapter
    Public cs As String = System.Configuration.ConfigurationSettings.AppSettings.Item("connection_string")
    Public Sub New()
    End Sub


    Function Get_process(ByVal xmlstring As XElement) As XElement Implements IService1.Get_process
        Dim image As XElement = <Processlist></Processlist>
        Dim getlist As String = xmlstring.Element("getlist")

        'If getlist = 1 Then
        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "select * from Kill_process_list where IPAddress='" & getlist & "'"
        da.SelectCommand.CommandType = CommandType.Text
        ds = New Data.DataSet()
        da.Fill(ds, "killlist")
        If ds.Tables("killlist").Rows.Count > 0 Then
            Dim IPAddress As String = ds.Tables("killlist").Rows(0).Item("IPAddress").ToString()
            Dim name As String = ds.Tables("killlist").Rows(0).Item("name").ToString()
            Dim manage As String = ds.Tables("killlist").Rows(0).Item("manage").ToString()
            image.Add(New XElement("IPAddress", IPAddress), New XElement("name", name), New XElement("manage", manage))
            Return (image)
        Else
            image.Add(New XElement("IPAddress", 0), New XElement("name", 0), New XElement("manage", 0))
        End If
        'End If
        Return (image)
    End Function

    Function insert_process(ByVal xmlstring As XElement) As XElement Implements IService1.insert_process
        Dim image As XElement = <insert_process></insert_process>
        Dim ipadd As String = xmlstring.Elements("IPAddress").Value
        Dim name As String = xmlstring.Elements("Name").Value

        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "select * from ProcessList where IPAddress='" & ipadd & "' and name='" & name & "'"
        da.SelectCommand.CommandType = CommandType.Text
        ds = New Data.DataSet()
        da.Fill(ds, "check")
        If ds.Tables("check").Rows.Count = 0 Then
            conn = New SqlConnection(cs)
            conn.Open()
            da = New SqlDataAdapter
            da.SelectCommand = New SqlCommand
            da.SelectCommand.Connection = conn
            da.SelectCommand.CommandText = "Insert into ProcessList(IPAddress,name,date)values(@ip,@name,@date)"
            da.SelectCommand.CommandType = CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@ip", ipadd)
            da.SelectCommand.Parameters.AddWithValue("@name", name)
            da.SelectCommand.Parameters.AddWithValue("@date", Now.AddMinutes(330))
            da.SelectCommand.ExecuteNonQuery()
            SendNotification(name, ipadd)
        End If
        Return (image)
    End Function

    Private Sub SendNotification(ByVal name As String, ByVal ip As String)
        'Dim PhoneNo As String = "9562193888435"
        Dim Email As String = "sprerak789@gmail.com"
        'Dim strHostName As String = System.Windows.Forms.SystemInformation.ComputerName
        Dim strIPAddress As String = ip
        'strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        'Using cl As New WebClient
        '    cl.DownloadString("http://login.smsgatewayhub.com/smsapi/pushsms.aspx?user=chintan&pwd=776308&to=" + PhoneNo + "&sid=WEBSMS&msg=IP:" + strIPAddress + " and Process: " + name + "%&fl=0")
        'End Using

        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential("project.tpo@gmail.com", "AB1234cd@")
            SmtpServer.EnableSsl = True
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New MailAddress("project.tpo@gmail.com")
            mail.To.Add(Email)
            mail.Subject = "Alert"
            mail.Body = "IP:" + strIPAddress + " and Process: " + name + ""
            SmtpServer.Send(mail)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
        Return String.Format("You entered: {0}", value)
    End Function

    Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
        If composite.BoolValue Then
            composite.StringValue = (composite.StringValue & "Suffix")
        End If
        Return composite
    End Function

End Class
