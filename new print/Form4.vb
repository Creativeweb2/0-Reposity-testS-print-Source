Imports System.IO
Imports System.Data.SqlClient
Public Class Form4

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ms = New MemoryStream()
        Me.PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg) ' Use appropriate format here
        Dim bytes = ms.ToArray()
        Dim str, str1, str2, str3, tit1, tit2, t1, b1 As String
        '------------------------------------
        str1 = "<table style='width: 100%; border-style: solid ' border='1'><tr><td width=30% bgcolor=rgb(157,235,190)>Sum Daen  </td><td>12000</td></tr><tr><td bgcolor=rgb(157,235,190)>Cell 3</td><td>Cell 4</td></tr></table> "
        str2 = "<table style='width: 100%; border-style: solid ' border='1'><tr><td width=30% bgcolor=rgb(157,235,190)>Sum Daen  </td><td>12000</td></tr><tr><td bgcolor=rgb(157,235,190)>Cell 3</td><td>Cell 4</td></tr></table> "
        str3 = "<table style='width: 100%; border-style: solid ' border='1'><tr><td width=30% bgcolor=rgb(157,235,190)>Sum Daen  </td><td>12000</td></tr><tr><td bgcolor=rgb(157,235,190)>Cell 3</td><td>Cell 4</td></tr></table> "
        ''----------------------------------
        'str1 = "<p class='tow'> line 1 : 12000 <br/> line 2 : 5000<br/>line 3 : 2580  <br/> </p> "
        'str2 = "<p class='tow'> line 1 : 1500  <br/> line 2 : 6000<br/>line 3 : 4646  <br/> </p> "
        ' str3 = "<p class='tow'> line 1 : 1600  <br/> line 2 : 9000<br/>line 3 : 45679 <br/></p> "
        '---------------------------------------

        tit1 = "<h1><span style='color:rgb(15,122,230);font-size:14px;'>Salers </span> Reporter </h1>"
        'tit1 = "<h1>Salers Reporter </h1>"
        '--------------------------------------------------
        tit2 = " <span style='color:rgb(15,122,230);font-size:14px;'>Date From: </span> 2018-1-1  <span style='color:rgb(15,122,230);font-size:14px;'>to</span>  2018-12-31"
        ' tit2 = "<table style='width: 80%; border-style: solid ' border='1'><tr><td width=20% bgcolor=rgb(157,235,190)>date from :</td><td>2018-1-1</td><td width=10% bgcolor=rgb(157,235,190)> TO </td><td>2018-12-31</td></tr></table> "
        '-------------------------------------------------
        t1 = "<h4> <span style='color:rgb(15,122,230);font-size:18px;font-bold:900px'>S</span>omar <span style='color:rgb(15,122,230);font-size:18px;font-bold:900px'>S</span>oft for <span style='color:rgb(15,122,230);font-size:18px;font-bold:900px'>P</span>rograming </h4>"
        ' t1="t1"
        '-----------------------------------
        b1 = "<h6> <span style='color:rgb(15,122,230);font-size:18px;font-bold:900px'>S</span>omar <span style='color:rgb(15,122,230);font-size:18px;font-bold:900px'>S</span>oft for <span style='color:rgb(15,122,230);font-size:18px;font-bold:900px'>P</span>rograming </h6>"
        ' b1="b1"
        str = "<div class='row'>    <div class='col' >" & str1 & "</div>    <div class='col'>" & str2 & "</div>    <div class='col'>" & str3 & "</div></div>"

        Sprint.print(1, Me.DataGridView1, tit1, tit2, str, t1, "t2", "t3", b1, "b2", "b3", bytes)
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtSet As DataSet = New DataSet
        Dim dTable As DataTable = Nothing
        Try
            Dim DBCon As New SqlConnection
            Dim DBCmd As SqlCommand = New SqlCommand
            DBCon.ConnectionString = "Data Source=.\sqlexpress;Initial Catalog=ACCOUNTDATA2;Integrated Security=True;Pooling=False"
            DBCon.Open()
            If DBCon.State = ConnectionState.Closed Then
                Exit Sub
            End If

            DBCmd.CommandText = "select * from tab1"
            DBCmd.CommandTimeout = 250
            DBCmd.Connection = DBCon
            DBCmd.ExecuteScalar()
            Dim dtAdaptor As SqlDataAdapter = New SqlDataAdapter(DBCmd)
            dtSet.Clear()
            dtAdaptor.Fill(dtSet)

            dTable = dtSet.Tables(0)
            DBCon.Close()
            Me.DataGridView1.DataSource = dTable

        Catch ex As Exception

        End Try
    End Sub
End Class