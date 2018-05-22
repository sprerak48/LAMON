Public Class frmProcessManagement_Kill
    Dim MachineName As String
    Dim ProcessName As String
    Dim p As Process
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lstProcesses.Items.Clear() 'lstProcess is a ListBox and First "Imports System.Diagnostics" in top of the application
        lstProcesses.DisplayMember = "ProcessName"
        
        ProcessName = "NotePad"
        MachineName = "10.1.1.3"
        'Dim ipByName As Process() = Process.GetProcesses("127.0.0.1")
        'lstProcesses.Items.Add(ipByName)
        For Each p In Process.GetProcesses("127.0.0.1")
            lstProcesses.Items.Add(p)
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim pr_name As String

        pr_name = lstProcesses.GetItemText(lstProcesses.SelectedItem)

        For Each p In System.Diagnostics.Process.GetProcessesByName(pr_name)
            p.Kill()
            p.WaitForExit()
        Next
        lstProcesses.Items.Clear()
        For Each p In Process.GetProcesses("127.0.0.1")
            lstProcesses.Items.Add(p)
        Next
    End Sub
End Class