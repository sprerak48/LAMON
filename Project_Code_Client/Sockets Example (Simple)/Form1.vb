Public Class Form1

    Private Sub MessageToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MessageToolStripMenuItem.Click

    End Sub

    Private Sub ProcessManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessManagementToolStripMenuItem.Click

    End Sub

    Private Sub ViewProcessListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewProcessListToolStripMenuItem.Click
        'frmCommunicator.ShowfrmComunitor("ManageProcessList")
    End Sub

    Private Sub KillProcessToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KillProcessToolStripMenuItem.Click
        frmProcessManagement_Kill.Show()
    End Sub

    Private Sub ViewUsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewUsersToolStripMenuItem.Click
        frmIpList.Show()
    End Sub

    Private Sub ComputerManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComputerManagementToolStripMenuItem.Click
        machine_command.ShowDialog()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        'frmCommunicator.Show()
        'frmCommunicator.ShowfrmComunitor("Communicator")
    End Sub
End Class
