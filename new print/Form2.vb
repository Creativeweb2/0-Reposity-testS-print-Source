Public Class Form2

    Private Sub Bh1_font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bh1_font.Click
        Try
            Me.FontDialog1.ShowDialog()
            My.Settings.font_size_h1 = Me.FontDialog1.Font.Size
            My.Settings.font_family_h1 = Me.FontDialog1.Font.Name
            My.Settings.Save()
            Me.Label23.Font = New Font(My.Settings.font_family_h1, My.Settings.font_size_h1)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bth_color.Click
        Try
            Me.ColorDialog1.ShowDialog()
            My.Settings.th_tow_color = Me.ColorDialog1.Color
            My.Settings.Save()
            Me.Bth_color.BackColor = My.Settings.th_tow_color
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        My.Settings.padding_root = Me.Troot_padding.Text
        My.Settings.margin_top_table_one = Me.Ttable_one_top.Text
        My.Settings.margin_div_one_top = Me.Tdiv_one_top.Text
        My.Settings.padding_top_h4 = Me.Th4_top.Text
        My.Settings.height_table_one = Me.Ttable_one_height.Text
        My.Settings.border_table_one = Me.Ttable_one_border.Text
        My.Settings.img_log_height = Me.Timg_log_heigth.Text
        My.Settings.img_log_width = Me.Timg_log_width.Text
        My.Settings.img_top_height = Me.Timg_top_heigth.Text
        My.Settings.font_weight_h4 = Me.Th4_font_bold.Text
        My.Settings.padding_top_h1 = Me.Th1_top.Text
        My.Settings.padding_bottom_h1 = Me.Th1_bottom.Text
        My.Settings.text_align_h1 = Me.Ch1_align.Text
        My.Settings.font_weight_h1 = Me.Th1_font_bold.Text
        My.Settings.padding_div_tow_top = Me.Tdiv_tow_top.Text
        My.Settings.padding_div_tow_bottom = Me.Tdiv_tow_bottom.Text
        My.Settings.text_p_one_align = Me.Cp_one_align.Text
        My.Settings.font_weight_p_one = Me.Tp_one_font_bold.Text
        My.Settings.border_table_tow = Me.Ttable_tow_border.Text
        My.Settings.td_tow_border = Me.Ttable_tow_td.Text
        My.Settings.tr_tow_border = Me.Ttr_border.Text
        My.Settings.margin_div_thre_top = Me.Tdiv_thre_top.Text
        My.Settings.margin_div_thre_bottom = Me.Tdiv_thre_bottom.Text
        My.Settings.font_weight_p_tow = Me.Tp_tow_bold.Text
        My.Settings.padding_div_four_top = Me.Tdiv_four_top.Text
        My.Settings.padding_top_h5 = Me.Th5_top.Text
        My.Settings.img_footer_height = Me.Timg_footer_hieght.Text
        My.Settings.font_weight_h5 = Me.Th5_bold.Text
        My.Settings.border_div_four = Me.border_div_four.Text
        My.Settings.page_width = Me.Tpage_width.Text
        create_css()
        MsgBox("ok")
        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Troot_padding.Text = My.Settings.padding_root
        Me.Ttable_one_top.Text = My.Settings.margin_top_table_one
        Me.Tdiv_one_top.Text = My.Settings.margin_div_one_top
        Me.Th4_top.Text = My.Settings.padding_top_h4
        Me.Ttable_one_height.Text = My.Settings.height_table_one
        Me.Ttable_one_border.Text = My.Settings.border_table_one
        Me.Timg_log_heigth.Text = My.Settings.img_log_height
        Me.Timg_log_width.Text = My.Settings.img_log_width
        Me.Timg_top_heigth.Text = My.Settings.img_top_height
        Me.Th4_font_bold.Text = My.Settings.font_weight_h4
        Me.Th1_top.Text = My.Settings.padding_top_h1
        Me.Th1_bottom.Text = My.Settings.padding_bottom_h1
        Me.Ch1_align.Text = My.Settings.text_align_h1
        Me.Th1_font_bold.Text = My.Settings.font_weight_h1
        Me.Tdiv_tow_top.Text = My.Settings.padding_div_tow_top
        Me.Tdiv_tow_bottom.Text = My.Settings.padding_div_tow_bottom
        Me.Cp_one_align.Text = My.Settings.text_p_one_align
        Me.Tp_one_font_bold.Text = My.Settings.font_weight_p_one
        Me.Ttable_tow_border.Text = My.Settings.border_table_tow
        Me.Ttable_tow_td.Text = My.Settings.td_tow_border
        Me.Ttr_border.Text = My.Settings.tr_tow_border
        Me.Tdiv_thre_top.Text = My.Settings.margin_div_thre_top
        Me.Tdiv_thre_bottom.Text = My.Settings.margin_div_thre_bottom
        Me.Tp_tow_bold.Text = My.Settings.font_weight_p_tow
        Me.Tdiv_four_top.Text = My.Settings.padding_div_four_top
        Me.Th5_top.Text = My.Settings.padding_top_h5
        Me.Timg_footer_hieght.Text = My.Settings.img_footer_height
        Me.Th5_bold.Text = My.Settings.font_weight_h5
        Me.Bth_color.BackColor = My.Settings.th_tow_color
        Me.Btr_color.BackColor = My.Settings.tr_tow_color
        Me.border_div_four.Text = My.Settings.border_div_four
        Me.Tpage_width.Text = My.Settings.page_width
        'Me.Bh4_font.Font = New Font(My.Settings.font_family_h4, My.Settings.font_size_h4)
        '  Me.Bh1_font.Font = New Font(My.Settings.font_family_h1, My.Settings.font_size_h1)
        ' Me.Bh5_font.Font = New Font(My.Settings.font_family_h5, My.Settings.font_size_h5)
        ' Me.Btable_tow_font.Font = New Font(My.Settings.font_family_table, My.Settings.font_size_table)
        ' Me.Bp_tow_font.Font = New Font(My.Settings.font_family_p_tow, My.Settings.font_size_p_tow)

    End Sub
    

    Private Sub Bh4_font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bh4_font.Click
        Try
            Me.FontDialog1.ShowDialog()
            My.Settings.font_size_h4 = Me.FontDialog1.Font.Size
            My.Settings.font_family_h4 = Me.FontDialog1.Font.Name
            My.Settings.Save()
            Me.Label23.Font = New Font(My.Settings.font_family_h4, My.Settings.font_size_h4)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bp_one_font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bp_one_font.Click
        Try
            Me.FontDialog1.ShowDialog()
            My.Settings.font_size_p_one = Me.FontDialog1.Font.Size
            My.Settings.font_family_p_one = Me.FontDialog1.Font.Name
            My.Settings.Save()
            Me.Label23.Font = New Font(My.Settings.font_family_p_one, My.Settings.font_size_p_one)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btable_tow_font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btable_tow_font.Click
        Try
            Me.FontDialog1.ShowDialog()
            My.Settings.font_size_table = Me.FontDialog1.Font.Size
            My.Settings.font_family_table = Me.FontDialog1.Font.Name
            My.Settings.Save()
            Me.Label23.Font = New Font(My.Settings.font_family_table, My.Settings.font_size_table)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btr_color_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btr_color.Click
        Try
            Me.ColorDialog1.ShowDialog()
            My.Settings.tr_tow_color = Me.ColorDialog1.Color
            My.Settings.Save()
            Me.Btr_color.BackColor = My.Settings.tr_tow_color
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bp_tow_font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bp_tow_font.Click
        Try
            Me.FontDialog1.ShowDialog()
            My.Settings.font_size_p_tow = Me.FontDialog1.Font.Size
            My.Settings.font_family_p_tow = Me.FontDialog1.Font.Name
            My.Settings.Save()
            Me.Label23.Font = New Font(My.Settings.font_family_p_tow, My.Settings.font_size_p_tow)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bh5_font_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bh5_font.Click
        Try
            Me.FontDialog1.ShowDialog()
            My.Settings.font_size_h5 = Me.FontDialog1.Font.Size
            My.Settings.font_family_h5 = Me.FontDialog1.Font.Name
            My.Settings.Save()
            Me.Label23.Font = New Font(My.Settings.font_family_h5, My.Settings.font_size_h5)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()

        End If
    End Sub
End Class