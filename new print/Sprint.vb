Public Class Sprint
    Public Shared Sub print(ByVal lang As Integer, ByVal grid As DataGridView, ByVal titel As String, ByVal titel2 As String, ByVal details As String, ByVal t1 As String, ByVal t2 As String, ByVal t3 As String, ByVal b1 As String, ByVal b2 As String, ByVal b3 As String, ByVal pic As Byte())
        Dim p_form As New Form1(lang, grid, titel, titel2, details, t1, t2, t3, b1, b2, b3, pic)
        p_form.Show()
    End Sub

End Class
