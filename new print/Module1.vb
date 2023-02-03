Module Module1
    Public Sub create_css()
        Dim html As String = ""
        html += ":root { padding:" & My.Settings.padding_root & "px; direction:" & My.Settings.direction & "; width: " & My.Settings.page_width & "%;}" & vbNewLine
        html += "h1    { padding-top:" & My.Settings.padding_top_h1 & "px; padding-bottom:" & My.Settings.padding_bottom_h1 & "px;  padding-right:10px;  padding-left:10px;    text-align:" & My.Settings.text_align_h1 & ";  font-size:" & My.Settings.font_size_h1 & "pt;  font-weight:" & My.Settings.font_weight_h1 & ";  font-family:" & My.Settings.font_family_h1 & ";}" & vbNewLine
        html += "h4    { padding-top:" & My.Settings.padding_top_h4 & "px;   padding-right:10px;  padding-left:10px;    font-size:" & My.Settings.font_size_h4 & "pt;  font-weight:" & My.Settings.font_weight_h4 & ";  font-family:" & My.Settings.font_family_h4 & ";}" & vbNewLine
        html += "h5    { padding-top:" & My.Settings.padding_top_h5 & "px;   padding-right:10px;  padding-left:10px;    font-size:" & My.Settings.font_size_h5 & "pt;  font-weight:" & My.Settings.font_weight_h5 & ";  font-family:" & My.Settings.font_family_h5 & ";}" & vbNewLine
        html += "div {text-align:justify;width:100%;}" & vbNewLine
        html += "div.one  {margin-top:" & My.Settings.margin_div_one_top & "px;}" & vbNewLine
        html += "div.tow  {padding-top:" & My.Settings.padding_div_tow_top & "px;  padding-bottom:" & My.Settings.padding_div_tow_bottom & "px;}" & vbNewLine
        html += "div.thre {margin-top:" & My.Settings.margin_div_thre_top & "px;   margin-bottom:" & My.Settings.margin_div_thre_bottom & "px;}" & vbNewLine
        html += "div.four {margin-top:" & My.Settings.padding_div_four_top & "px;border: " & My.Settings.border_div_four & "px solid black; }" & vbNewLine
        html += "img.top  { height:" & My.Settings.img_top_height & "px;  width:100%;}" & vbNewLine
        html += "img.log  {height:" & My.Settings.img_log_height & "px;  width:" & My.Settings.img_log_width & "px;}" & vbNewLine
        html += "img.footer {height:" & My.Settings.img_footer_height & "px;  width:100%;}" & vbNewLine
        html += "p.one {    padding-right:10px;  padding-left:10px;  font-size:" & My.Settings.font_size_p_one & "pt;text-align:" & My.Settings.text_p_one_align & ";font-weight:" & My.Settings.font_weight_p_one & ";  font-family:" & My.Settings.font_family_p_one & ";}" & vbNewLine
        html += "p.tow {    padding-right:10px;  padding-left:10px;  font-size:" & My.Settings.font_size_p_tow & "pt;  font-family:" & My.Settings.font_family_p_tow & ";font-weight:" & My.Settings.font_weight_p_tow & ";}" & vbNewLine
        html += "table{ font-size:" & My.Settings.font_size_table & "pt;  text-align:center;  font-family:" & My.Settings.font_family_table & ";}" & vbNewLine
        html += "table.one{ margin-top: " & My.Settings.margin_top_table_one & "px;   border: " & My.Settings.border_table_one & "px solid black;    width: 100%;	height: " & My.Settings.height_table_one & "px}" & vbNewLine
        html += "table.tow{ border:" & My.Settings.border_table_tow & "px solid black;    width: 100%;}" & vbNewLine
        html += "th.tow{ background-color: rgb(" & My.Settings.th_tow_color.R & "," & My.Settings.th_tow_color.G & "," & My.Settings.th_tow_color.B & ");  border: " & My.Settings.td_tow_border & "px solid black;}" & vbNewLine
        html += "td.tow{ border: " & My.Settings.td_tow_border & "px solid black;}" & vbNewLine
        html += "tr.tow{border: " & My.Settings.tr_tow_border & "px solid black;}" & vbNewLine
        html += "tr.tow:nth-child(even) {background-color: rgb(" & My.Settings.tr_tow_color.R & "," & My.Settings.tr_tow_color.G & "," & My.Settings.tr_tow_color.B & ");}" & vbNewLine
        ' html += "#container { min-height:100%;   position:relative;}" & vbNewLine
        ' html += "#footer { position:absolute; bottom:5px}" & vbNewLine
        Dim fs As New IO.FileStream(Application.StartupPath & "\print_files\print_setting\css\styles.css", IO.FileMode.Create)
        Dim sw As New IO.StreamWriter(fs)
        sw.Write(html)
        sw.Close()
        fs.Close()
    End Sub
End Module
