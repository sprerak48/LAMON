Imports System.Data.SqlClient
Partial Class Login
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection
    Dim comm As SqlCommand
    Public da As SqlDataAdapter
    Public ds As Data.DataSet
    Public cs As String = System.Configuration.ConfigurationSettings.AppSettings.Item("connection_string")

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim u As String = txtUsername.Text
        Dim p As String = txtPassword.Text
        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "select Top 1 * from Login where username='" & u & "' and Password='" & p & "'"
        da.SelectCommand.CommandType = Data.CommandType.Text
        ds = New Data.DataSet()
        da.Fill(ds, "login")
        If ds.Tables("login").Rows.Count = 0 Then
            lblShow.Text = "Invalid Username And Password"
            txtUsername.Text = String.Empty
            txtPassword.Text = String.Empty
            txtUsername.Focus()
        Else
            Dim id As Integer = ds.Tables("login").Rows(0).Item(id)
            Session("aid") = id
            Response.Redirect("Home.aspx")
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("msg") = "logout" Then
            Session("aid") = Nothing
        End If
    End Sub
End Class
