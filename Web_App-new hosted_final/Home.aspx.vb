Imports System.Data.SqlClient
Partial Class Home
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection
    Dim comm As SqlCommand
    Public da As SqlDataAdapter
    Public ds As Data.DataSet
    Public cs As String = System.Configuration.ConfigurationSettings.AppSettings.Item("connection_string")
    Dim p_id As Integer
    Public manage As String
    Protected Sub btnlogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlogout.Click
        Response.Redirect("Login.aspx?msg=logout")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("aid") = Nothing Then
            Response.Redirect("Login.aspx?msg=logout")
        End If
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As System.EventArgs) Handles btnSubmit.Click

        If RadioButton1.Checked = True Then
            manage = "Shutdown"
        ElseIf RadioButton2.Checked = True Then
            manage = "Restart"
        ElseIf RadioButton3.Checked = True Then
            manage = "Logoff"
        End If

        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "select ipaddress from Kill_process_list where ipaddress='" & DropDownList1.SelectedValue & "'"
        da.SelectCommand.CommandType = Data.CommandType.Text
        ds = New Data.DataSet()
        da.Fill(ds, "check")
        If ds.Tables("check").Rows.Count = 0 Then
            conn = New SqlConnection(cs)
            conn.Open()
            da = New SqlDataAdapter
            da.SelectCommand = New SqlCommand
            da.SelectCommand.Connection = conn
            da.SelectCommand.CommandText = "insert into Kill_process_list(ipaddress,manage)values(@ip,@manage)"
            da.SelectCommand.CommandType = Data.CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@ip", DropDownList1.SelectedValue)
            da.SelectCommand.Parameters.AddWithValue("@manage", manage)
            da.SelectCommand.ExecuteNonQuery()
        Else
            conn = New SqlConnection(cs)
            conn.Open()
            da = New SqlDataAdapter
            da.SelectCommand = New SqlCommand
            da.SelectCommand.Connection = conn
            da.SelectCommand.CommandText = "update Kill_process_list set manage=@manage where IPAddress=@ip"
            da.SelectCommand.CommandType = Data.CommandType.Text
            da.SelectCommand.Parameters.AddWithValue("@ip", DropDownList1.SelectedValue)
            da.SelectCommand.Parameters.AddWithValue("@manage", manage)
            da.SelectCommand.ExecuteNonQuery()
        End If
        Response.Redirect("Home.aspx?msg=manage")
    End Sub

    Protected Sub btnRefresh_Click(sender As Object, e As System.EventArgs) Handles btnRefresh.Click
        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "truncate table processlist"
        da.SelectCommand.CommandType = Data.CommandType.Text
        da.SelectCommand.ExecuteNonQuery()

        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "truncate table Kill_process_list"
        da.SelectCommand.CommandType = Data.CommandType.Text
        da.SelectCommand.ExecuteNonQuery()

        Response.Redirect("Home.aspx")
    End Sub
End Class
