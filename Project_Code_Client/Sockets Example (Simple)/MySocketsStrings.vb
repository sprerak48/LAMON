Public Module MySocketsStrings

    Public Function getRealStringFromBytes(ByRef Bytes() As Byte) As String
        If Bytes Is Nothing Then Return Nothing
        If Bytes.Length = 0 Then Return Nothing

        Dim Chars(Bytes.Length - 1) As Char

        For i As Integer = 0 To Bytes.Length - 1
            Chars(i) = Chr(Bytes(i))
        Next

        Return Chars
    End Function

    Public Function getBytesFromRealString(ByRef Input As String) As Byte()
        If Input.Length = 0 Then Return Nothing

        Dim Bytes(Input.Length - 1) As Byte
        Dim Chars() As Char = Input.ToCharArray()

        For i As Integer = 0 To Chars.Length - 1
            Bytes(i) = Asc(Chars(i))
        Next

        Return Bytes
    End Function

End Module
