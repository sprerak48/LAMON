Public Class Login

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUserName.Text = "Admin" And txtPassword.Text = "ADMIN" Then
            If IsNumeric(txtMobileNo.Text) = False Or Len(txtMobileNo.Text) <> 10 Then
                MsgBox("Please Provide Correct Mobile Number")
                txtMobileNo.Text = ""
                txtMobileNo.Focus()
                Exit Sub
            End If
            frmCommunicator.frmCommShow(txtMobileNo.Text)
            Me.Hide()
        Else
            MsgBox("Please Provide Correct UserName Or Password")
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtUserName.Focus()
    End Sub
End Class