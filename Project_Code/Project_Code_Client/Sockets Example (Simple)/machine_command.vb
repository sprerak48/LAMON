﻿Public Class machine_command

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Shutdown.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim command As String
        command = "Shutdown -l"
        Shell(command)
    End Sub
End Class