Imports System.Data.SqlClient
Partial Class Kill
    Inherits System.Web.UI.Page
    Dim conn As SqlConnection
    Dim comm As SqlCommand
    Public da As SqlDataAdapter
    Public ds As Data.DataSet
    Public cs As String = System.Configuration.ConfigurationSettings.AppSettings.Item("connection_string")
    Dim p_id As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        p_id = Request.QueryString("p_id")

        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "select  * from ProcessList where p_id=" & p_id & ""
        da.SelectCommand.CommandType = Data.CommandType.Text
        ds = New Data.DataSet()
        da.Fill(ds, "list")
        Dim IP As String = ds.Tables("list").Rows(0).Item("IPAddress").ToString()
        Dim name As String = ds.Tables("list").Rows(0).Item("name").ToString()

        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "Truncate table Kill_process_list "
        da.SelectCommand.CommandType = Data.CommandType.Text
        da.SelectCommand.ExecuteNonQuery()

        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "insert into Kill_process_list(IPAddress,name)values(@IP,@name)"
        da.SelectCommand.CommandType = Data.CommandType.Text
        da.SelectCommand.Parameters.AddWithValue("@IP", IP)
        da.SelectCommand.Parameters.AddWithValue("@name", name)
        da.SelectCommand.ExecuteNonQuery()


        conn = New SqlConnection(cs)
        conn.Open()
        da = New SqlDataAdapter
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = conn
        da.SelectCommand.CommandText = "delete from ProcessList where p_id=" & p_id & ""
        da.SelectCommand.CommandType = Data.CommandType.Text
        da.SelectCommand.ExecuteNonQuery()

        Response.Redirect("Home.aspx?msg=kill")
    End Sub
End Class
