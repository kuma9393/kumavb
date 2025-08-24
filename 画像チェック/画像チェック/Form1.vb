Imports System.IO
Imports System.Text

Public Class Form1
    Private Sub データ表示_Click(sender As Object, e As EventArgs) Handles データ表示.Click
        ' 固定ファイルパス
        Dim filePath As String = "C:\画像検査AI\画像検査AI\output.csv"

        ' ファイルの存在確認
        If Not File.Exists(filePath) Then
            MessageBox.Show("CSVファイルが見つかりません。" & vbCrLf & filePath, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' CSVをすべての行として読み込む（Shift-JISなども可）
            Dim lines() As String = File.ReadAllLines(filePath, Encoding.UTF8)

            ' 空チェック
            If lines.Length = 0 Then
                MessageBox.Show("CSVファイルが空です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' DataGridView 初期化
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            ' ヘッダ（1行目）
            Dim headers() As String = lines(0).Split(","c)
            ' No列を最初に追加
            DataGridView1.Columns.Add("No", "No")
            For Each header As String In headers
                DataGridView1.Columns.Add(header, header)
            Next

            ' データ行
            For i As Integer = 1 To lines.Length - 1
                If Not String.IsNullOrWhiteSpace(lines(i)) Then
                    Dim values() As String = lines(i).Split(","c)

                    ' 最初の列にNo（連番）を追加するため、新しい配列を作る
                    Dim newRow(values.Length) As String ' 元の +1列分のサイズ
                    newRow(0) = i.ToString() ' No列（1から始まる）

                    ' 残りのデータをコピー
                    For j As Integer = 0 To values.Length - 1
                        newRow(j + 1) = values(j)
                    Next

                    DataGridView1.Rows.Add(newRow)
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("読み込みエラー：" & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub 画像チェック_Click(sender As Object, e As EventArgs) Handles 画像チェック.Click
        Try
            Dim DateFile As String
            DateFile = TextBox1.Text
            If DateFile.Length <> 8 Then
                MessageBox.Show("日付は8桁で入力してください")
                Return
            End If

            ' 実行するEXEファイルのフルパス
            Dim exePath As String = "C:\画像検査AI\dist\analysis.exe"

            ' ProcessStartInfoを使ってプロセスを設定
            Dim psi As New ProcessStartInfo()
            psi.FileName = exePath
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.CreateNoWindow = True ' コンソールウィンドウを表示しない
            psi.Arguments = DateFile

            ' プロセスを開始
            Dim proc As Process = Process.Start(psi)

            ' 出力とエラーを読み取る
            Dim output As String = proc.StandardOutput.ReadToEnd()
            Dim errorOutput As String = proc.StandardError.ReadToEnd()

            ' プロセス終了を待つ
            proc.WaitForExit()

            ' 出力を表示
            MessageBox.Show("画像チェックが完了しました")

            'MessageBox.Show("出力:" & vbCrLf & output, "実行結果")

            If Not String.IsNullOrWhiteSpace(errorOutput) Then
                MessageBox.Show("エラー:" & vbCrLf & errorOutput, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("実行時エラー: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' フォームロード時に現在の日付を表示
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = DateTime.Now.ToString("yyyyMMdd") ' yyyy/MM/dd形式で表示
    End Sub
End Class
