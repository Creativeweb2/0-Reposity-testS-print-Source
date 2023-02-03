Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Drawing.Printing
Imports System.Globalization
Public Class Form1
    Dim gridview As DataGridView
    Dim ntitel, ntitel2, ndetails, nt1, nt2, nt3, nb1, nb2, nb3 As String
    Public Sub New(ByVal lang As Integer, ByVal grid As DataGridView, ByVal titel As String, ByVal titel2 As String, ByVal details As String, ByVal t1 As String, ByVal t2 As String, ByVal t3 As String, ByVal b1 As String, ByVal b2 As String, ByVal b3 As String, ByVal pic As Byte())
        Dim s As String
        Select Case lang
            Case 0
                s = "ar-SY"
            Case 1

                s = "en-US"
            Case 3
                s = "ar-IQ"
        End Select
        Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo(s)
        Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(s)
        Try
            Me.InitializeComponent()
            Me.ntitel = titel
            Me.ntitel2 = titel2
            Me.ndetails = details
            Me.nt1 = t1
            Me.nt2 = t2
            Me.nt3 = t3
            Me.nb1 = b1
            Me.nb2 = b2
            Me.nb3 = b3
            Me.gridview = grid
            Dim log As Image = Nothing
            Dim imageData As Byte() = pic
            If Not imageData Is Nothing Then
                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    log = Image.FromStream(ms, True)
                    log.Save(Application.StartupPath & "\print_files\print_setting\img\log.jpg")
                End Using
            End If
            Dim i As Integer
            Dim pkInstalledPrinters As String
            For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
                pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)
                Me.ComboBox1.Items.Add(pkInstalledPrinters)
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.OpenFileDialog1.InitialDirectory = "C:\"
            Me.OpenFileDialog1.RestoreDirectory = True
            Me.OpenFileDialog1.Filter = "Image File (*.jpg;)|*.jpg;"
            If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                File.Copy(Me.OpenFileDialog1.FileName, Application.StartupPath & "\print_files\print_setting\img\top.jpg", True)
                MsgBox("ok")
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If

        If e.KeyCode = Keys.F5 Then
            Me.Button4.PerformClick()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.OpenFileDialog1.InitialDirectory = "C:\"
            Me.OpenFileDialog1.RestoreDirectory = True
            Me.OpenFileDialog1.Filter = "Image File (*.jpg;)|*.jpg;"
            If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                File.Copy(Me.OpenFileDialog1.FileName, Application.StartupPath & "\print_files\print_setting\img\footer.jpg", True)
                MsgBox("ok")
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString())
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Cursor = Cursors.WaitCursor
        save_setting()
        create_css()
        Dim select_col As New List(Of String)
        Dim enumerator As IEnumerator
        Dim data As Byte()
        Dim ms As MemoryStream
        Dim alim As String = "center"
        Try
            enumerator = Me.CheckedListBox1.CheckedItems.GetEnumerator
            Do While enumerator.MoveNext
                select_col.Add(RuntimeHelpers.GetObjectValue(enumerator.Current).ToString)
            Loop
        Finally
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        Dim x As String
        Dim img As Image
        Try

            Dim html As String = ""
            html += "<html dir='" & My.Settings.direction & "'><head><meta charset='utf-8' /><meta http-equiv='X-UA-Compatible' content='IE=edge'>" & vbNewLine
            html += "<meta name='viewport' content='width=device-width, initial-scale=1.0'>" & vbNewLine
            html += "<title>By Eng Somar Hammoud</title>" & vbNewLine
            html += "<link rel='stylesheet' href='print_setting/bootstrap/css/bootstrap.min.css'>" & vbNewLine
            html += "<link rel='stylesheet' href='print_setting/css/styles.css'>" & vbNewLine
            html += "</head> <body> " & vbNewLine
            '--------------------------------------top
            If Me.RadioButton6.Checked = True Then
                If File.Exists(Application.StartupPath & "\print_files\print_setting\img\top.jpg") Then
                    html += "<img class='top' src='print_setting/img/top.jpg' alt='' >"
                Else
                    html += "<img class='top' src='print_setting/default_img/top.jpg' alt='' >"
                End If
            Else
                html += "<table class='one'>" & vbNewLine
                html += "<tr class='one'>" + vbNewLine
                html += "<td class='one' width= 70%>" + vbNewLine
                html += "<div class='one'>" + vbNewLine
                html += String.Format("<h4>{0}</h4>", Me.nt1) + vbNewLine
                html += String.Format("<h4>{0}</h4>", Me.nt2) + vbNewLine
                html += String.Format("<h4>{0}</h4>", Me.nt3) + vbNewLine
                html += "</div></td>" + vbNewLine

                If File.Exists(Application.StartupPath & "\print_files\print_setting\img\log.jpg") Then
                    html += "<td class='one' align=left ><img class='log' src='print_setting/img/log.jpg'alt='' ></td>" + vbNewLine
                Else
                    html += "<td class='one' align=left ><img class='log' src='print_setting/default_img/log.jpg'alt='' ></td>" + vbNewLine
                End If

                html += "</tr></table> "
            End If
            '-------------------------------
            If Me.CheckBox2.Checked Then
                html += "<hr />" + vbNewLine
            End If
            '--------------------------------------
            html += String.Format("<h1>{0}</h1>", Me.ntitel) & vbNewLine

            html += "<div class='tow'>" + vbNewLine
            html += String.Format("<p class='one'>{0}</p>", Me.ntitel2)
            html += "</div>" + vbNewLine

            html += "<table class='tow'>" & vbNewLine
            html += "<tr>" + vbNewLine
            For Each col As DataGridViewColumn In gridview.Columns
                If col.Visible = True AndAlso select_col.Contains(col.HeaderText) Then
                    html += String.Format("<th class='tow'>{0}</th>", col.HeaderText) + vbNewLine
                End If
            Next
            html += "</tr>" + vbNewLine
            '---------------------------------------------------
            If Me.RadioButton1.Checked Then
                For Each dr As DataGridViewRow In gridview.Rows
                    html += "<tr class='tow'>" + vbNewLine
                    For Each cel As DataGridViewCell In dr.Cells
                        If cel.Visible = True AndAlso select_col.Contains(cel.OwningColumn.HeaderText) Then
                            If cel.ValueType.Name = "Image" Or cel.ValueType.Name = "Byte[]" Then
                                If cel.ValueType.Name = "Byte[]" Then
                                    Try
                                        data = DirectCast(cel.Value, Byte())
                                        If Not (data Is Nothing) Then
                                            ms = New System.IO.MemoryStream(data)
                                            img = System.Drawing.Image.FromStream(ms)
                                            data = Nothing
                                            Try
                                                img.Save(String.Format(Application.StartupPath & "\print_files\print_setting\img\{0}.jpg", dr.Index))
                                                html += String.Format("<td class='tow' ><img src='print_setting/img/" & dr.Index & ".jpg'alt='' height='20' width='20'></td>", Color.WhiteSmoke.Name) + vbNewLine

                                            Catch ex As Exception
                                                html += String.Format("<td class='tow' ><img src='print_setting/img/" & dr.Index & ".jpg'alt='' height='20' width='20'></td>", Color.WhiteSmoke.Name) + vbNewLine

                                            End Try
                                            img.Dispose()
                                        End If
                                    Catch ex As Exception
                                        html += String.Format("<td class='tow'>{0}</td>", "") + vbNewLine
                                    End Try


                                End If
                                If cel.ValueType.Name = "Image" Then
                                    Try
                                        img = gridview.Item(gridview.Columns(cel.ColumnIndex).Name, dr.Index).Value
                                        Try
                                            img.Save(String.Format(Application.StartupPath & "\print_files\print_setting\img\{0}.jpg", dr.Index))
                                            html += String.Format("<td class='tow' ><img src='print_setting/img/" & dr.Index & ".jpg'alt='' height='20' width='20'></td>", Color.WhiteSmoke.Name) + vbNewLine

                                        Catch ex As Exception
                                            html += String.Format("<td class='tow' ><img src='print_setting/img/" & dr.Index & ".jpg'alt='' height='20' width='20'></td>", Color.WhiteSmoke.Name) + vbNewLine

                                        End Try
                                        img.Dispose()

                                    Catch ex As Exception
                                        html += String.Format("<td class='tow'>{0}</td>", "") + vbNewLine
                                    End Try
                                End If

                            Else
                                Try
                                    x = String.Format("{0:" & gridview.Columns(cel.ColumnIndex).DefaultCellStyle.Format & "}", cel.Value)
                                Catch ex As Exception
                                    x = ""
                                End Try

                                Select Case gridview.Columns(cel.ColumnIndex).DefaultCellStyle.Alignment
                                    Case 1, 16, 256
                                        alim = "right"
                                    Case 2, 32, 512
                                        alim = "center"
                                    Case 4, 64, 1024
                                        alim = "left"
                                    Case Else
                                        alim = "center"
                                End Select


                                html += String.Format("<td  style='text-align: " & alim & "' class='tow' >{0}</td>", x) + vbNewLine
                            End If

                        End If
                    Next
                    html += "</tr>" + vbNewLine
                Next
            Else
                For Each dr As DataGridViewRow In gridview.SelectedRows
                    html += "<tr class='tow'>" + vbNewLine
                    For Each cel As DataGridViewCell In dr.Cells
                        If cel.Visible = True AndAlso select_col.Contains(cel.OwningColumn.HeaderText) Then
                            If cel.ValueType.Name = "Image" Then
                                img = gridview.Item("n_lock", dr.Index).Value
                                img.Save(String.Format(Application.StartupPath & "\print_files\print_setting\img\{0}.jpg", dr.Index))
                                html += String.Format("<td class='tow' ><img src='print_setting/img/" & dr.Index & ".jpg'alt='' height='20' width='20'></td>", Color.WhiteSmoke.Name) + vbNewLine

                            Else
                                Try
                                    x = String.Format("{0:" & gridview.Columns(cel.ColumnIndex).DefaultCellStyle.Format & "}", cel.Value)
                                Catch ex As Exception
                                    x = ""
                                End Try

                                Select Case gridview.Columns(cel.ColumnIndex).DefaultCellStyle.Alignment
                                    Case 1, 16, 256
                                        alim = "right"
                                    Case 2, 32, 512
                                        alim = "center"
                                    Case 4, 64, 1024
                                        alim = "left"
                                    Case Else
                                        alim = "center"
                                End Select

                                html += String.Format("<td style='text-align: " & alim & "' class='tow'>{0}</td>", x) + vbNewLine
                            End If

                        End If
                    Next
                    html += "</tr>" + vbNewLine
                Next
            End If
            html += "</table>"
            '-------------------------------
            If Me.CheckBox3.Checked Then
                html += "<hr />" + vbNewLine
            End If
            '--------------------------------------
            html += "<div  class='ther'>" + vbNewLine
            html += String.Format("<p class='tow'>{0}</p>", Me.ndetails)
            html += "</div>" + vbNewLine
            '-------------------------------
            If Me.CheckBox4.Checked Then
                html += "<hr />" + vbNewLine
            End If
            '--------------------------------------
            html += "<div  class='four'>" + vbNewLine
            If Me.RadioButton8.Checked = True Then
                If File.Exists(Application.StartupPath & "\print_files\print_setting\img\footer.jpg") Then
                    html += "<img class='footer'  src='print_setting/img/footer.jpg' alt='' >"
                Else
                    html += "<img class='footer'  src='print_setting/default_img/footer.jpg' alt='' >"
                End If
            Else
                html += String.Format("<h5 >{0}</h5>", Me.nb1)
                html += String.Format("<h5 >{0}</h5>", Me.nb2)
                html += String.Format("<h5 >{0}</h5>", Me.nb3)
            End If
            html += "</div>" + vbNewLine
            html += "<script src='print_setting/js/jquery.min.js'></script><script src='print_setting/bootstrap/js/bootstrap.min.js'></script></body></html>"

            '-----------------------------

            Dim fs As New IO.FileStream(Application.StartupPath & "\print_files\s.html", IO.FileMode.Create)
            Dim sw As New IO.StreamWriter(fs)
            sw.Write(html)
            sw.Close()
            fs.Close()
            If My.Settings.webbrowser = False Then
                'Dim f As New Form3
                'f.Show()
                Me.WebBrowser1.Navigate(Application.StartupPath & "\print_files\s.html")

                While Me.WebBrowser1.ReadyState <> 4
                    Application.DoEvents()
                    Threading.Thread.Sleep(100)
                End While

                Me.WebBrowser1.ShowPrintPreviewDialog()
            Else

                Dim s As String = Application.StartupPath & "\print_files\s.html"
                If File.Exists(s) Then
                    Dim psi As New ProcessStartInfo()
                    With psi
                        .FileName = s
                        .UseShellExecute = True
                    End With
                    Try
                        Process.Start(psi)
                    Catch ex As Exception
                        MsgBox("لا يوجد برنامج افتراضي للتشغيل")
                        Exit Sub
                    End Try
                Else
                    MsgBox("الملف غير متوفر")
                End If
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked Then
            For i As Integer = 0 To Me.CheckedListBox1.Items.Count - 1
                Me.CheckedListBox1.SetItemChecked(i, True)
            Next
        Else
            For i As Integer = 0 To Me.CheckedListBox1.Items.Count - 1
                Me.CheckedListBox1.SetItemChecked(i, False)
            Next

        End If
    End Sub


    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        save_setting()

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.RadioButton1.Checked = My.Settings.all_row
        Me.RadioButton6.Checked = My.Settings.hedar
        Me.RadioButton8.Checked = My.Settings.footer
        Me.CheckBox2.Checked = My.Settings.line1
        Me.CheckBox3.Checked = My.Settings.line2
        Me.CheckBox4.Checked = My.Settings.line3
        Me.CheckBox5.Checked = My.Settings.webbrowser
        Me.ComboBox1.Text = My.Settings.printer
        If My.Settings.direction = "rtl" Then
            Me.RadioButton4.Checked = True
        Else
            Me.RadioButton3.Checked = True
        End If

        For Each col As DataGridViewColumn In Me.gridview.Columns
            If col.Visible = True Then
                Me.CheckedListBox1.Items.Add(col.HeaderText, True)
            End If
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim f As New Form2
        f.Show()
    End Sub
    Private Sub save_setting()
        My.Settings.all_row = Me.RadioButton1.Checked
        My.Settings.hedar = Me.RadioButton6.Checked
        My.Settings.footer = Me.RadioButton8.Checked
        My.Settings.line1 = Me.CheckBox2.Checked
        My.Settings.line2 = Me.CheckBox3.Checked
        My.Settings.line3 = Me.CheckBox4.Checked
        If Me.RadioButton4.Checked = True Then
            My.Settings.direction = "rtl"
        Else
            My.Settings.direction = "ltr"
        End If
        My.Settings.webbrowser = Me.CheckBox5.Checked
        My.Settings.printer = Me.ComboBox1.Text
        SetDefaultPrinter(My.Settings.printer)
        My.Settings.Save()

    End Sub
    Private Declare Function SetDefaultPrinter Lib "winspool.drv" Alias "SetDefaultPrinterA" (ByVal pszPrinter As String) As Long

End Class
